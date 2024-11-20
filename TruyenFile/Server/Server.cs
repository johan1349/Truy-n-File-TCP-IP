using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data;
using System.Threading.Tasks;

namespace TCPDataTransferServer
{
    public partial class ServerForm : Form
    {
        private TcpListener server;

        public ServerForm()
        {
            InitializeComponent();

        }

        private void bt_start_server_Click(object sender, EventArgs e)
        {
            _ = StartServer();
            lbl_status.Text = "Server started... ";
        }

        private async Task StartServer()
        {
            try
            {
                string ipAddress = tb_server_ip.Text;
                int port = int.Parse(tb_server_port.Text);

                server = new TcpListener(IPAddress.Parse(ipAddress), port);
                server.Start();

                Invoke(new Action(() => lbl_status.Text = "Waiting for connection..."));

                while (true)
                {
                    TcpClient client = await server.AcceptTcpClientAsync();
                    Invoke(new Action(() => lbl_status.Text = "Client connected."));
                    _ = Task.Run(() => ReceiveFileInChunksAsync(client));
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid IP or Port format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex)
            {
                Invoke(new Action(() => MessageBox.Show("Unexpected Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)));
            }
        }

        private async Task ReceiveFileInChunksAsync(TcpClient client)
        {
            string directoryPath = @"D:\Receive";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            using (NetworkStream stream = client.GetStream())
            {
                try
                {
                    // Read file name
                    byte[] fileNameLengthBuffer = new byte[4];
                    await stream.ReadAsync(fileNameLengthBuffer, 0, fileNameLengthBuffer.Length);
                    int fileNameLength = BitConverter.ToInt32(fileNameLengthBuffer, 0);

                    byte[] fileNameBuffer = new byte[fileNameLength];
                    await stream.ReadAsync(fileNameBuffer, 0, fileNameBuffer.Length);
                    string fileName = Encoding.UTF8.GetString(fileNameBuffer);

                    // Read file size
                    byte[] fileSizeBuffer = new byte[8];
                    await stream.ReadAsync(fileSizeBuffer, 0, fileSizeBuffer.Length);
                    long fileSize = BitConverter.ToInt64(fileSizeBuffer, 0);

                    string filePath = Path.Combine(directoryPath, fileName);
                    long existingFileSize = 0;

                    if (File.Exists(filePath))
                    {
                        FileInfo existingFile = new FileInfo(filePath);
                        existingFileSize = existingFile.Length;
                    }

                    // Send last position to client
                    byte[] lastPositionBuffer = BitConverter.GetBytes(existingFileSize);
                    await stream.WriteAsync(lastPositionBuffer, 0, lastPositionBuffer.Length);

                    // Determine buffer size based on file size
                    int bufferSize;
                    if (fileSize <= 100 * 1024 * 1024) // File <= 100 MB
                        bufferSize = 1024 * 1024; // 1 MB
                    else if (fileSize <= 1024 * 1024 * 1024) // File <= 1 GB
                        bufferSize = 10 * 1024 * 1024; // 10 MB
                    else // File > 1 GB
                        bufferSize = 50 * 1024 * 1024; // 50 MB

                    long totalBytesReceived = existingFileSize;

                    using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.None, bufferSize, true))
                    {
                        byte[] buffer = new byte[bufferSize];
                        int bytesRead;

                        while (totalBytesReceived < fileSize && (bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await fs.WriteAsync(buffer, 0, bytesRead);
                            totalBytesReceived += bytesRead;

                            // Update progress bar
                            int progress = (int)((double)totalBytesReceived / fileSize * 100);
                            Invoke(new Action(() => UpdateProgressBar(progress)));
                        }
                    }

                    Invoke(new Action(() => AddFileToDataGrid(fileName, fileSize)));
                    MessageBox.Show($"File '{fileName}' received successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    client.Close();
                }
            }
        }



        private void AddFileToDataGrid(string fileName, long fileSize)
        {
            double fileSizeInMB = fileSize / (1024.0 * 1024.0);
            dgv_receivedFiles.Rows.Add(fileName, $"{fileSizeInMB:F2} MB", DateTime.Now.ToString("g"));
        }

        private void UpdateProgressBar(int progress)
        {
            if (progress >= pb_upload.Minimum && progress <= pb_upload.Maximum)
            {
                pb_upload.Value = progress;
                pb_upload.Refresh();
                if (progress == 100)
                {
                    lbl_status.Text = "File transfer completed successfully!";
                }
            }
        }

    }
}
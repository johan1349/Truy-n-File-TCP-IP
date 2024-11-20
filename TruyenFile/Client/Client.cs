using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPDataTransferClient
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        private async void bt_send_files_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] files = openFileDialog.FileNames;
                    foreach (string file in files)
                    {
                        await SendFileInChunksAsync(file);
                    }
                }
            }
        }

        private async Task SendFileInChunksAsync(string filePath)
        {
            try
            {
                string ipAddress = tb_client_ip.Text;
                int port = int.Parse(tb_client_port.Text);

                using (TcpClient client = new TcpClient(ipAddress, port))
                using (NetworkStream stream = client.GetStream())
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    long fileSize = fileInfo.Length;
                    string fileName = fileInfo.Name;

                    // Send file name
                    byte[] fileNameBytes = Encoding.UTF8.GetBytes(fileName);
                    byte[] fileNameLength = BitConverter.GetBytes(fileNameBytes.Length);
                    await stream.WriteAsync(fileNameLength, 0, fileNameLength.Length);
                    await stream.WriteAsync(fileNameBytes, 0, fileNameBytes.Length);

                    // Send file size
                    byte[] fileSizeBytes = BitConverter.GetBytes(fileSize);
                    await stream.WriteAsync(fileSizeBytes, 0, fileSizeBytes.Length);

                    // Read the last position from the server
                    byte[] lastPositionBuffer = new byte[8];
                    await stream.ReadAsync(lastPositionBuffer, 0, lastPositionBuffer.Length);
                    long lastPosition = BitConverter.ToInt64(lastPositionBuffer, 0);

                    // Determine buffer size based on file size
                    int bufferSize;
                    if (fileSize <= 100 * 1024 * 1024) // File <= 100 MB
                        bufferSize = 1024 * 1024; // 1 MB
                    else if (fileSize <= 1024 * 1024 * 1024) // File <= 1 GB
                        bufferSize = 10 * 1024 * 1024; // 10 MB
                    else // File > 1 GB
                        bufferSize = 50 * 1024 * 1024; // 50 MB

                    // Send file content
                    byte[] buffer = new byte[bufferSize];
                    long totalBytesSent = lastPosition;
                    DateTime startTime = DateTime.Now;

                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        fs.Seek(lastPosition, SeekOrigin.Begin);
                        int bytesRead;
                        while ((bytesRead = await fs.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await stream.WriteAsync(buffer, 0, bytesRead);
                            totalBytesSent += bytesRead;

                            // Update progress
                            int progress = (int)((double)totalBytesSent / fileSize * 100);
                            TimeSpan elapsedTime = DateTime.Now - startTime;
                            double transferRate = totalBytesSent / elapsedTime.TotalSeconds; // bytes per second
                            double estimatedTimeRemaining = (fileSize - totalBytesSent) / transferRate;

                            Invoke(new Action(() => UpdateProgress(fileName, progress, estimatedTimeRemaining)));
                        }
                    }

                    if (totalBytesSent == fileSize)
                    {
                        string status = "Completed";
                        Invoke(new Action(() =>
                        {
                            dgv_filesStatus.Rows.Add(fileName, $"{fileSize / (1024.0 * 1024.0):F2} MB", status);
                        }));
                        MessageBox.Show($"File '{fileName}' sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        LogError($"File transfer incomplete for '{fileName}'. {totalBytesSent}/{fileSize} bytes sent.");
                        MessageBox.Show($"File transfer incomplete. Please retry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid IP or Port format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                LogError($"Error: {ex.Message}");
                MessageBox.Show($"Error sending file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void UpdateProgress(string fileName, int progress, double estimatedTimeRemaining)
        {
            lbl_status.Text = $"Sending {fileName}: {progress}% - Estimated time remaining: {TimeSpan.FromSeconds(estimatedTimeRemaining):hh\\:mm\\:ss}";
            pb_upload.Value = progress;
        }
        private void LogError(string message)
        {
            string logFilePath = "transfer_errors.log";
            try
            {
                using (StreamWriter sw = new StreamWriter(logFilePath, true))
                {
                    sw.WriteLine($"[{DateTime.Now}] {message}");
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Failed to write to log file.", "Logging Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

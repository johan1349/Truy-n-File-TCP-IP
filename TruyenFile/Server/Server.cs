using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Server
{
     class Server
    {
        IPEndPoint end;
        Socket sock;
        public Server()
        {
            end = new IPEndPoint(IPAddress.Any, 999);
            sock = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            sock.Bind(end);
        }
        public static string path;
        public static string MessageCurrent = "Stopped";
        //    public void StartServer()
        //    {
        //        try
        //        {
        //            MessageCurrent = "Starting ....";
        //            sock.Listen(100);
        //            MessageCurrent = "it works and looks for files";
        //            Socket clientSock = sock.Accept();
        //            byte[] clientData = new byte[1024 * 20000];
        //            int receiveByteLen = clientSock.Receive(clientData);
        //            MessageCurrent = "Receiving file....";
        //            int fNameLen = BitConverter.ToInt32(clientData, 0);     
        //            string fName = Encoding.ASCII.GetString(clientData, 4, fNameLen);
        //            BinaryWriter write = new BinaryWriter(File.Open(path + "/" + fName , FileMode.Append));
        //            write.Write(clientData, 4 + fNameLen, receiveByteLen - 4 - fNameLen);
        //            MessageCurrent = " saving file";
        //            write.Close();
        //            clientSock.Close();
        //            MessageCurrent = "the file was recived";

        //        }catch(Exception ex)
        //        {
        //            MessageCurrent = "Error " + ex.Message;
        //        }
        //    }
        //}
        public void StartServer()
        {
            try
            {
                MessageCurrent = "Starting ....";
                sock.Listen(100);
                MessageCurrent = "It works and looks for files";
                Socket clientSock = sock.Accept();
                byte[] clientData = new byte[1024 * 20000];
                int receiveByteLen = clientSock.Receive(clientData);
                MessageCurrent = "Receiving file....";
                int fNameLen = BitConverter.ToInt32(clientData, 0);
                string fName = Encoding.ASCII.GetString(clientData, 4, fNameLen);

                // Kiểm tra và xử lý tên file để loại bỏ các ký tự không hợp lệ
                fName = SanitizeFileName(fName);

                // Đảm bảo đường dẫn tồn tại
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // Ghi file
                using (BinaryWriter write = new BinaryWriter(File.Open(Path.Combine(path, fName), FileMode.Append)))
                {
                    write.Write(clientData, 4 + fNameLen, receiveByteLen - 4 - fNameLen);
                    write.Close();
                }

                MessageCurrent = "Saving file";
                clientSock.Close();
                MessageCurrent = "The file was received";
            }
            catch (Exception ex)
            {
                MessageCurrent = "Error: " + ex.Message;
            }
        }

        private string SanitizeFileName(string fileName)
        {
            // Lấy danh sách các ký tự không hợp lệ cho tên tệp
            char[] invalidChars = Path.GetInvalidFileNameChars();
            foreach (char c in invalidChars)
            {
                fileName = fileName.Replace(c.ToString(), ""); // Loại bỏ các ký tự không hợp lệ
            }
            return fileName;
        }
    }
}


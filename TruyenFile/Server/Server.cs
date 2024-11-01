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
        public static string MessageCurrent = "Dừng";
       
        public void StartServer()
        {
            try
            {
                MessageCurrent = "Bắt đầu";
                sock.Listen(100);
                MessageCurrent = "Server đã sẳn sàng để nhận file";
                Socket clientSock = sock.Accept();
                byte[] clientData = new byte[1024 * 20000];
                int receiveByteLen = clientSock.Receive(clientData);
                MessageCurrent = "Đang nhận file";
                int fNameLen = BitConverter.ToInt32(clientData, 0);
                string fName = Encoding.ASCII.GetString(clientData, 4, fNameLen);

                fName = SanitizeFileName(fName);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }


                BinaryWriter write = new BinaryWriter(File.Open(Path.Combine(path, fName), FileMode.Append));
                {
                    write.Write(clientData, 4 + fNameLen, receiveByteLen - 4 - fNameLen);
                    write.Close();
                }

                MessageCurrent = "Lưu file";
                clientSock.Close();
                MessageCurrent = "File đã được lưu tại " + path;
            }
            catch (Exception ex)
            {
                MessageCurrent = "Lỗi: " + ex.Message;
            }
        }

        private string SanitizeFileName(string fileName)
        {
            char[] invalidChars = Path.GetInvalidFileNameChars();
            foreach (char c in invalidChars)
            {
                fileName = fileName.Replace(c.ToString(), ""); 
            }
            return fileName;
        }
    }
}


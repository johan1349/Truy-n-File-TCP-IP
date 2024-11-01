using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        public static string path;
        public Form1()
        {
            InitializeComponent();
            Server.path = "D:\\LapTrinhMang\\Recieve";
        }

        public static string MessageCurrent = "Stopped";
        private void Form1_Load(object sender, EventArgs e)
        {
            if (Server.path.Length > 0)
            {
                backgroundWorker1.RunWorkerAsync();

            }
            else
            {
                MessageBox.Show("Không thể nhận file");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = Server.MessageCurrent ;
        }
        Server server = new Server();

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            server.StartServer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String OpenPath = Server.path.Replace(@"\\",@"\");
            try
            {
                if (!string.IsNullOrEmpty(OpenPath) && Directory.Exists(OpenPath))
                {
                    Process.Start("explorer.exe", OpenPath);
                }
                else
                {
                    MessageBox.Show("Thư mục không tồn tại hoặc chưa được chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}

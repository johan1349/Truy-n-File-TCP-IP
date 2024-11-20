using System.Windows.Forms;

namespace TCPDataTransferServer
{
    partial class ServerForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button bt_start_server;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.ProgressBar pb_upload;
        private System.Windows.Forms.DataGridView dgv_receivedFiles;

        private System.Windows.Forms.TextBox tb_server_ip;
        private System.Windows.Forms.TextBox tb_server_port;
        private System.Windows.Forms.Label lbl_server_ip;
        private System.Windows.Forms.Label lbl_server_port;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tb_server_ip = new System.Windows.Forms.TextBox();
            this.tb_server_port = new System.Windows.Forms.TextBox();
            this.lbl_server_ip = new System.Windows.Forms.Label();
            this.lbl_server_port = new System.Windows.Forms.Label();
            this.bt_start_server = new System.Windows.Forms.Button();
            this.lbl_status = new System.Windows.Forms.Label();
            this.pb_upload = new System.Windows.Forms.ProgressBar();
            this.dgv_receivedFiles = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_receivedFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_server_ip
            // 
            this.tb_server_ip.Location = new System.Drawing.Point(120, 57);
            this.tb_server_ip.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_server_ip.Name = "tb_server_ip";
            this.tb_server_ip.Size = new System.Drawing.Size(223, 26);
            this.tb_server_ip.TabIndex = 5;
            this.tb_server_ip.Text = "127.0.0.1";
            // 
            // tb_server_port
            // 
            this.tb_server_port.Location = new System.Drawing.Point(480, 57);
            this.tb_server_port.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_server_port.Name = "tb_server_port";
            this.tb_server_port.Size = new System.Drawing.Size(148, 26);
            this.tb_server_port.TabIndex = 7;
            this.tb_server_port.Text = "8080";
            // 
            // lbl_server_ip
            // 
            this.lbl_server_ip.AutoSize = true;
            this.lbl_server_ip.Location = new System.Drawing.Point(18, 62);
            this.lbl_server_ip.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_server_ip.Name = "lbl_server_ip";
            this.lbl_server_ip.Size = new System.Drawing.Size(78, 20);
            this.lbl_server_ip.TabIndex = 4;
            this.lbl_server_ip.Text = "Server IP:";
            // 
            // lbl_server_port
            // 
            this.lbl_server_port.AutoSize = true;
            this.lbl_server_port.Location = new System.Drawing.Point(375, 62);
            this.lbl_server_port.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_server_port.Name = "lbl_server_port";
            this.lbl_server_port.Size = new System.Drawing.Size(92, 20);
            this.lbl_server_port.TabIndex = 6;
            this.lbl_server_port.Text = "Server Port:";
            // 
            // bt_start_server
            // 
            this.bt_start_server.Location = new System.Drawing.Point(18, 18);
            this.bt_start_server.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bt_start_server.Name = "bt_start_server";
            this.bt_start_server.Size = new System.Drawing.Size(150, 35);
            this.bt_start_server.TabIndex = 0;
            this.bt_start_server.Text = "Start Server";
            this.bt_start_server.UseVisualStyleBackColor = true;
            this.bt_start_server.Click += new System.EventHandler(this.bt_start_server_Click);
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(18, 110);
            this.lbl_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(56, 20);
            this.lbl_status.TabIndex = 1;
            this.lbl_status.Text = "Status";
            // 
            // pb_upload
            // 
            this.pb_upload.Location = new System.Drawing.Point(22, 145);
            this.pb_upload.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pb_upload.Name = "pb_upload";
            this.pb_upload.Size = new System.Drawing.Size(750, 35);
            this.pb_upload.TabIndex = 2;
            // 
            // dgv_receivedFiles
            // 
            this.dgv_receivedFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_receivedFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgv_receivedFiles.Location = new System.Drawing.Point(22, 203);
            this.dgv_receivedFiles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgv_receivedFiles.Name = "dgv_receivedFiles";
            this.dgv_receivedFiles.RowHeadersWidth = 62;
            this.dgv_receivedFiles.Size = new System.Drawing.Size(750, 308);
            this.dgv_receivedFiles.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "File Name";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "File Size (MB)";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Status";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 534);
            this.Controls.Add(this.lbl_server_ip);
            this.Controls.Add(this.tb_server_ip);
            this.Controls.Add(this.lbl_server_port);
            this.Controls.Add(this.tb_server_port);
            this.Controls.Add(this.dgv_receivedFiles);
            this.Controls.Add(this.pb_upload);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.bt_start_server);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TCP Server";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_receivedFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}

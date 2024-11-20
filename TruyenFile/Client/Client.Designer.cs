using System.Windows.Forms;

namespace TCPDataTransferClient
{
    partial class ClientForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button bt_send_files;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.ProgressBar pb_upload;
        private System.Windows.Forms.DataGridView dgv_filesStatus;
        private System.Windows.Forms.TextBox tb_client_ip;
        private System.Windows.Forms.TextBox tb_client_port;
        private System.Windows.Forms.Label lbl_client_ip;
        private System.Windows.Forms.Label lbl_client_port;

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
            this.tb_client_ip = new System.Windows.Forms.TextBox();
            this.tb_client_port = new System.Windows.Forms.TextBox();
            this.lbl_client_ip = new System.Windows.Forms.Label();
            this.lbl_client_port = new System.Windows.Forms.Label();
            this.bt_send_files = new System.Windows.Forms.Button();
            this.lbl_status = new System.Windows.Forms.Label();
            this.pb_upload = new System.Windows.Forms.ProgressBar();
            this.dgv_filesStatus = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_filesStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_client_ip
            // 
            this.tb_client_ip.Location = new System.Drawing.Point(120, 57);
            this.tb_client_ip.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_client_ip.Name = "tb_client_ip";
            this.tb_client_ip.Size = new System.Drawing.Size(223, 26);
            this.tb_client_ip.TabIndex = 5;
            this.tb_client_ip.Text = "127.0.0.1";
            // 
            // tb_client_port
            // 
            this.tb_client_port.Location = new System.Drawing.Point(480, 57);
            this.tb_client_port.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_client_port.Name = "tb_client_port";
            this.tb_client_port.Size = new System.Drawing.Size(148, 26);
            this.tb_client_port.TabIndex = 7;
            this.tb_client_port.Text = "8080";
            // 
            // lbl_client_ip
            // 
            this.lbl_client_ip.AutoSize = true;
            this.lbl_client_ip.Location = new System.Drawing.Point(18, 62);
            this.lbl_client_ip.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_client_ip.Name = "lbl_client_ip";
            this.lbl_client_ip.Size = new System.Drawing.Size(78, 20);
            this.lbl_client_ip.TabIndex = 4;
            this.lbl_client_ip.Text = "Server IP:";
            // 
            // lbl_client_port
            // 
            this.lbl_client_port.AutoSize = true;
            this.lbl_client_port.Location = new System.Drawing.Point(375, 62);
            this.lbl_client_port.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_client_port.Name = "lbl_client_port";
            this.lbl_client_port.Size = new System.Drawing.Size(92, 20);
            this.lbl_client_port.TabIndex = 6;
            this.lbl_client_port.Text = "Server Port:";
            // 
            // bt_send_files
            // 
            this.bt_send_files.Location = new System.Drawing.Point(18, 18);
            this.bt_send_files.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bt_send_files.Name = "bt_send_files";
            this.bt_send_files.Size = new System.Drawing.Size(150, 35);
            this.bt_send_files.TabIndex = 0;
            this.bt_send_files.Text = "Send Files";
            this.bt_send_files.UseVisualStyleBackColor = true;
            this.bt_send_files.Click += new System.EventHandler(this.bt_send_files_Click);
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(14, 107);
            this.lbl_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(56, 20);
            this.lbl_status.TabIndex = 1;
            this.lbl_status.Text = "Status";
            // 
            // pb_upload
            // 
            this.pb_upload.Location = new System.Drawing.Point(13, 143);
            this.pb_upload.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pb_upload.Name = "pb_upload";
            this.pb_upload.Size = new System.Drawing.Size(600, 35);
            this.pb_upload.TabIndex = 2;
            // 
            // dgv_filesStatus
            // 
            this.dgv_filesStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_filesStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgv_filesStatus.Location = new System.Drawing.Point(13, 188);
            this.dgv_filesStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgv_filesStatus.Name = "dgv_filesStatus";
            this.dgv_filesStatus.RowHeadersWidth = 62;
            this.dgv_filesStatus.Size = new System.Drawing.Size(600, 231);
            this.dgv_filesStatus.TabIndex = 3;
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
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 445);
            this.Controls.Add(this.lbl_client_ip);
            this.Controls.Add(this.tb_client_ip);
            this.Controls.Add(this.lbl_client_port);
            this.Controls.Add(this.tb_client_port);
            this.Controls.Add(this.dgv_filesStatus);
            this.Controls.Add(this.pb_upload);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.bt_send_files);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TCP Client";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_filesStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}

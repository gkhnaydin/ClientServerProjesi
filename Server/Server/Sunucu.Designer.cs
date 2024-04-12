namespace Server
{
    partial class Sunucu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listMessage = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btStop = new System.Windows.Forms.Button();
            this.teIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tePort = new System.Windows.Forms.NumericUpDown();
            this.btStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tePort)).BeginInit();
            this.SuspendLayout();
            // 
            // listMessage
            // 
            this.listMessage.HorizontalScrollbar = true;
            this.listMessage.Location = new System.Drawing.Point(12, 100);
            this.listMessage.Name = "listMessage";
            this.listMessage.ScrollAlwaysVisible = true;
            this.listMessage.Size = new System.Drawing.Size(560, 199);
            this.listMessage.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "PORT:";
            // 
            // btStop
            // 
            this.btStop.Enabled = false;
            this.btStop.Location = new System.Drawing.Point(472, 28);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(100, 23);
            this.btStop.TabIndex = 6;
            this.btStop.Text = "Durdur";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // teIp
            // 
            this.teIp.Location = new System.Drawing.Point(211, 30);
            this.teIp.Name = "teIp";
            this.teIp.Size = new System.Drawing.Size(158, 20);
            this.teIp.TabIndex = 8;
            this.teIp.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "IP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Sunucuya Gelen Mesajlar";
            // 
            // tePort
            // 
            this.tePort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tePort.Location = new System.Drawing.Point(58, 28);
            this.tePort.Maximum = new decimal(new int[] {
            25000,
            0,
            0,
            0});
            this.tePort.Name = "tePort";
            this.tePort.Size = new System.Drawing.Size(100, 24);
            this.tePort.TabIndex = 34;
            this.tePort.Value = new decimal(new int[] {
            11008,
            0,
            0,
            0});
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(375, 28);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(91, 23);
            this.btStart.TabIndex = 35;
            this.btStart.Text = "Başlat";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // Sunucu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 315);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.tePort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.teIp);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Sunucu";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Sunucu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tePort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.TextBox teIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown tePort;
        private System.Windows.Forms.Button btStart;
    }
}


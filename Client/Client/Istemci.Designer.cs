namespace Server
{
    partial class Client
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
            this.btConnectServer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.teIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btNotConnected = new System.Windows.Forms.Button();
            this.tePortNumber = new System.Windows.Forms.NumericUpDown();
            this.teMessage = new System.Windows.Forms.TextBox();
            this.btGonder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tePortNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // listMessage
            // 
            this.listMessage.HorizontalScrollbar = true;
            this.listMessage.Location = new System.Drawing.Point(12, 73);
            this.listMessage.Name = "listMessage";
            this.listMessage.ScrollAlwaysVisible = true;
            this.listMessage.Size = new System.Drawing.Size(560, 173);
            this.listMessage.TabIndex = 0;
            // 
            // btConnectServer
            // 
            this.btConnectServer.Location = new System.Drawing.Point(336, 30);
            this.btConnectServer.Name = "btConnectServer";
            this.btConnectServer.Size = new System.Drawing.Size(100, 23);
            this.btConnectServer.TabIndex = 1;
            this.btConnectServer.Text = "Baglan";
            this.btConnectServer.UseVisualStyleBackColor = true;
            this.btConnectServer.Click += new System.EventHandler(this.btConnectServer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "PORT";
            // 
            // teIp
            // 
            this.teIp.Location = new System.Drawing.Point(188, 30);
            this.teIp.Name = "teIp";
            this.teIp.Size = new System.Drawing.Size(137, 20);
            this.teIp.TabIndex = 6;
            this.teIp.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "IP";
            // 
            // btNotConnected
            // 
            this.btNotConnected.Location = new System.Drawing.Point(472, 30);
            this.btNotConnected.Name = "btNotConnected";
            this.btNotConnected.Size = new System.Drawing.Size(100, 23);
            this.btNotConnected.TabIndex = 8;
            this.btNotConnected.Text = "Baglantiyi Kes";
            this.btNotConnected.UseVisualStyleBackColor = true;
            this.btNotConnected.Click += new System.EventHandler(this.btNotConnectServer_Click);
            // 
            // tePortNumber
            // 
            this.tePortNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tePortNumber.Location = new System.Drawing.Point(55, 27);
            this.tePortNumber.Maximum = new decimal(new int[] {
            25000,
            0,
            0,
            0});
            this.tePortNumber.Name = "tePortNumber";
            this.tePortNumber.Size = new System.Drawing.Size(100, 24);
            this.tePortNumber.TabIndex = 35;
            this.tePortNumber.Value = new decimal(new int[] {
            11008,
            0,
            0,
            0});
            // 
            // teMessage
            // 
            this.teMessage.Location = new System.Drawing.Point(12, 264);
            this.teMessage.Name = "teMessage";
            this.teMessage.Size = new System.Drawing.Size(560, 20);
            this.teMessage.TabIndex = 36;
            // 
            // btGonder
            // 
            this.btGonder.Location = new System.Drawing.Point(472, 290);
            this.btGonder.Name = "btGonder";
            this.btGonder.Size = new System.Drawing.Size(100, 23);
            this.btGonder.TabIndex = 37;
            this.btGonder.Text = "Gönder";
            this.btGonder.UseVisualStyleBackColor = true;
            this.btGonder.Click += new System.EventHandler(this.btGonder_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 326);
            this.Controls.Add(this.btGonder);
            this.Controls.Add(this.teMessage);
            this.Controls.Add(this.tePortNumber);
            this.Controls.Add(this.btNotConnected);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.teIp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btConnectServer);
            this.Controls.Add(this.listMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Client";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Client_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tePortNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listMessage;
        private System.Windows.Forms.Button btConnectServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox teIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btNotConnected;
        private System.Windows.Forms.NumericUpDown tePortNumber;
        private System.Windows.Forms.TextBox teMessage;
        private System.Windows.Forms.Button btGonder;
    }
}


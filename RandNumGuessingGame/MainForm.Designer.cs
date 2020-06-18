namespace RNGG
{
    partial class MainForm
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
            this.btnClient = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnServer = new System.Windows.Forms.Button();
            this.joinPort = new System.Windows.Forms.TextBox();
            this.joinIP = new System.Windows.Forms.TextBox();
            this.joinUsername = new System.Windows.Forms.TextBox();
            this.hostPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnClient
            // 
            this.btnClient.BackColor = System.Drawing.Color.Black;
            this.btnClient.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClient.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClient.Location = new System.Drawing.Point(14, 33);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(139, 49);
            this.btnClient.TabIndex = 3;
            this.btnClient.Text = "Join an existing conversation";
            this.btnClient.UseVisualStyleBackColor = false;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            this.btnClient.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnClient_MouseDown);
            this.btnClient.MouseLeave += new System.EventHandler(this.btnClient_MouseLeave);
            this.btnClient.MouseHover += new System.EventHandler(this.btnClient_MouseHover);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Black;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnExit.Location = new System.Drawing.Point(284, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(54, 32);
            this.btnExit.TabIndex = 6;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnExit_MouseDown);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            this.btnExit.MouseHover += new System.EventHandler(this.btnExit_MouseHover);
            // 
            // btnServer
            // 
            this.btnServer.BackColor = System.Drawing.Color.Black;
            this.btnServer.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServer.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnServer.Location = new System.Drawing.Point(179, 104);
            this.btnServer.Name = "btnServer";
            this.btnServer.Size = new System.Drawing.Size(139, 49);
            this.btnServer.TabIndex = 5;
            this.btnServer.Text = "Host a new conversation";
            this.btnServer.UseVisualStyleBackColor = false;
            this.btnServer.Click += new System.EventHandler(this.btnServer_Click);
            this.btnServer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnServer_MouseDown);
            this.btnServer.MouseLeave += new System.EventHandler(this.btnServer_MouseLeave);
            this.btnServer.MouseHover += new System.EventHandler(this.btnServer_MouseHover);
            // 
            // joinPort
            // 
            this.joinPort.BackColor = System.Drawing.Color.Black;
            this.joinPort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.joinPort.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.joinPort.Location = new System.Drawing.Point(108, 19);
            this.joinPort.MaxLength = 5;
            this.joinPort.Name = "joinPort";
            this.joinPort.Size = new System.Drawing.Size(45, 13);
            this.joinPort.TabIndex = 2;
            this.joinPort.Text = "65535";
            this.joinPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // joinIP
            // 
            this.joinIP.BackColor = System.Drawing.Color.Black;
            this.joinIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.joinIP.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.joinIP.Location = new System.Drawing.Point(14, 19);
            this.joinIP.Name = "joinIP";
            this.joinIP.Size = new System.Drawing.Size(98, 13);
            this.joinIP.TabIndex = 1;
            this.joinIP.Text = "localhost";
            this.joinIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // joinUsername
            // 
            this.joinUsername.BackColor = System.Drawing.Color.Black;
            this.joinUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.joinUsername.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.joinUsername.Location = new System.Drawing.Point(14, 83);
            this.joinUsername.Name = "joinUsername";
            this.joinUsername.Size = new System.Drawing.Size(139, 13);
            this.joinUsername.TabIndex = 0;
            this.joinUsername.Text = "Username";
            this.joinUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hostPort
            // 
            this.hostPort.BackColor = System.Drawing.Color.Black;
            this.hostPort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hostPort.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.hostPort.Location = new System.Drawing.Point(282, 105);
            this.hostPort.MaxLength = 5;
            this.hostPort.Name = "hostPort";
            this.hostPort.Size = new System.Drawing.Size(35, 13);
            this.hostPort.TabIndex = 4;
            this.hostPort.Text = "65535";
            this.hostPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(350, 165);
            this.Controls.Add(this.btnClient);
            this.Controls.Add(this.hostPort);
            this.Controls.Add(this.joinUsername);
            this.Controls.Add(this.joinIP);
            this.Controls.Add(this.joinPort);
            this.Controls.Add(this.btnServer);
            this.Controls.Add(this.btnExit);
            this.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.Text = "Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnServer;
        private System.Windows.Forms.TextBox joinPort;
        private System.Windows.Forms.TextBox joinIP;
        private System.Windows.Forms.TextBox joinUsername;
        private System.Windows.Forms.TextBox hostPort;
    }
}
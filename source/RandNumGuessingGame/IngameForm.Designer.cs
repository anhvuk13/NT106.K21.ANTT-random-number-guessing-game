namespace RNGG
{
    partial class IngameForm
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
            this.components = new System.ComponentModel.Container();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.TextBox();
            this.conversation = new System.Windows.Forms.RichTextBox();
            this.btnReady = new System.Windows.Forms.Button();
            this.answer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.playerNum = new System.Windows.Forms.Label();
            this.btnAutoPlaySingleTurn = new System.Windows.Forms.Button();
            this.btnAutoplayWholeGame = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pic3 = new System.Windows.Forms.PictureBox();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.range = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.luckyNumber = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Black;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSend.Location = new System.Drawing.Point(641, 61);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(124, 29);
            this.btnSend.TabIndex = 1;
            this.btnSend.TabStop = false;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            this.btnSend.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSend_MouseDown);
            this.btnSend.MouseLeave += new System.EventHandler(this.btnSend_MouseLeave);
            this.btnSend.MouseHover += new System.EventHandler(this.btnSend_MouseHover);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Black;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClear.Location = new System.Drawing.Point(641, 99);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(124, 29);
            this.btnClear.TabIndex = 1;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnClear_MouseDown);
            this.btnClear.MouseLeave += new System.EventHandler(this.btnClear_MouseLeave);
            this.btnClear.MouseHover += new System.EventHandler(this.btnClear_MouseHover);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Black;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnExit.Location = new System.Drawing.Point(641, 388);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(124, 29);
            this.btnExit.TabIndex = 1;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnExit_MouseDown);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            this.btnExit.MouseHover += new System.EventHandler(this.btnExit_MouseHover);
            // 
            // message
            // 
            this.message.BackColor = System.Drawing.Color.Black;
            this.message.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.message.Location = new System.Drawing.Point(268, 63);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(367, 29);
            this.message.TabIndex = 0;
            this.message.KeyDown += new System.Windows.Forms.KeyEventHandler(this.message_KeyDown);
            // 
            // conversation
            // 
            this.conversation.BackColor = System.Drawing.Color.Black;
            this.conversation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conversation.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.conversation.Location = new System.Drawing.Point(142, 99);
            this.conversation.Name = "conversation";
            this.conversation.ReadOnly = true;
            this.conversation.Size = new System.Drawing.Size(493, 318);
            this.conversation.TabIndex = 0;
            this.conversation.TabStop = false;
            this.conversation.Text = "The compitition will begin after all competitors are Ready!\n>>> Waiting for playe" +
    "rs...\n";
            // 
            // btnReady
            // 
            this.btnReady.BackColor = System.Drawing.Color.Black;
            this.btnReady.FlatAppearance.BorderSize = 0;
            this.btnReady.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReady.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReady.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnReady.Location = new System.Drawing.Point(524, 31);
            this.btnReady.Name = "btnReady";
            this.btnReady.Size = new System.Drawing.Size(241, 29);
            this.btnReady.TabIndex = 0;
            this.btnReady.TabStop = false;
            this.btnReady.Text = "Ready!";
            this.btnReady.UseVisualStyleBackColor = false;
            this.btnReady.Click += new System.EventHandler(this.btnReady_Click);
            this.btnReady.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnReady_MouseDown);
            this.btnReady.MouseLeave += new System.EventHandler(this.btnReady_MouseLeave);
            this.btnReady.MouseHover += new System.EventHandler(this.btnReady_MouseHover);
            // 
            // answer
            // 
            this.answer.BackColor = System.Drawing.Color.Black;
            this.answer.Enabled = false;
            this.answer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answer.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.answer.Location = new System.Drawing.Point(268, 28);
            this.answer.MaxLength = 3;
            this.answer.Name = "answer";
            this.answer.Size = new System.Drawing.Size(37, 29);
            this.answer.TabIndex = 1;
            this.answer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.answer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.answer_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(138, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Your Answer:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(209, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Chat:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Black;
            this.btnSubmit.Enabled = false;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSubmit.Location = new System.Drawing.Point(311, 29);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(76, 29);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.TabStop = false;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            this.btnSubmit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSubmit_MouseDown);
            this.btnSubmit.MouseLeave += new System.EventHandler(this.btnSubmit_MouseLeave);
            this.btnSubmit.MouseHover += new System.EventHandler(this.btnSubmit_MouseHover);
            // 
            // playerNum
            // 
            this.playerNum.Dock = System.Windows.Forms.DockStyle.Top;
            this.playerNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerNum.Location = new System.Drawing.Point(0, 0);
            this.playerNum.Name = "playerNum";
            this.playerNum.Size = new System.Drawing.Size(778, 26);
            this.playerNum.TabIndex = 7;
            this.playerNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAutoPlaySingleTurn
            // 
            this.btnAutoPlaySingleTurn.BackColor = System.Drawing.Color.Black;
            this.btnAutoPlaySingleTurn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAutoPlaySingleTurn.Enabled = false;
            this.btnAutoPlaySingleTurn.FlatAppearance.BorderSize = 0;
            this.btnAutoPlaySingleTurn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoPlaySingleTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoPlaySingleTurn.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAutoPlaySingleTurn.Location = new System.Drawing.Point(0, 0);
            this.btnAutoPlaySingleTurn.Margin = new System.Windows.Forms.Padding(0);
            this.btnAutoPlaySingleTurn.Name = "btnAutoPlaySingleTurn";
            this.btnAutoPlaySingleTurn.Size = new System.Drawing.Size(125, 16);
            this.btnAutoPlaySingleTurn.TabIndex = 9;
            this.btnAutoPlaySingleTurn.TabStop = false;
            this.btnAutoPlaySingleTurn.Text = "Autoplay a Single Turn";
            this.btnAutoPlaySingleTurn.UseVisualStyleBackColor = false;
            this.btnAutoPlaySingleTurn.Click += new System.EventHandler(this.btnAutoPlaySingleTurn_Click);
            // 
            // btnAutoplayWholeGame
            // 
            this.btnAutoplayWholeGame.BackColor = System.Drawing.Color.Black;
            this.btnAutoplayWholeGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAutoplayWholeGame.Enabled = false;
            this.btnAutoplayWholeGame.FlatAppearance.BorderSize = 0;
            this.btnAutoplayWholeGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoplayWholeGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoplayWholeGame.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAutoplayWholeGame.Location = new System.Drawing.Point(0, 16);
            this.btnAutoplayWholeGame.Margin = new System.Windows.Forms.Padding(0);
            this.btnAutoplayWholeGame.Name = "btnAutoplayWholeGame";
            this.btnAutoplayWholeGame.Size = new System.Drawing.Size(125, 16);
            this.btnAutoplayWholeGame.TabIndex = 10;
            this.btnAutoplayWholeGame.TabStop = false;
            this.btnAutoplayWholeGame.Text = "Autoplay the Entire Game";
            this.btnAutoplayWholeGame.UseVisualStyleBackColor = false;
            this.btnAutoplayWholeGame.Click += new System.EventHandler(this.btnAutoplayWholeGame_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnAutoPlaySingleTurn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAutoplayWholeGame, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(397, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(125, 32);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // pic3
            // 
            this.pic3.Image = global::RNGG.Properties.Resources.a;
            this.pic3.InitialImage = global::RNGG.Properties.Resources.a;
            this.pic3.Location = new System.Drawing.Point(12, 291);
            this.pic3.Name = "pic3";
            this.pic3.Size = new System.Drawing.Size(124, 124);
            this.pic3.TabIndex = 11;
            this.pic3.TabStop = false;
            // 
            // pic2
            // 
            this.pic2.Image = global::RNGG.Properties.Resources.a;
            this.pic2.Location = new System.Drawing.Point(12, 159);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(124, 124);
            this.pic2.TabIndex = 10;
            this.pic2.TabStop = false;
            // 
            // pic1
            // 
            this.pic1.Image = global::RNGG.Properties.Resources.a;
            this.pic1.Location = new System.Drawing.Point(12, 29);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(124, 124);
            this.pic1.TabIndex = 9;
            this.pic1.TabStop = false;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(641, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Range:";
            // 
            // range
            // 
            this.range.AutoSize = true;
            this.range.Enabled = false;
            this.range.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.range.Location = new System.Drawing.Point(683, 216);
            this.range.Name = "range";
            this.range.Size = new System.Drawing.Size(82, 17);
            this.range.TabIndex = 13;
            this.range.Text = "[999, 999]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(641, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Lucky Number:";
            // 
            // luckyNumber
            // 
            this.luckyNumber.AutoSize = true;
            this.luckyNumber.Enabled = false;
            this.luckyNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.luckyNumber.Location = new System.Drawing.Point(730, 322);
            this.luckyNumber.Name = "luckyNumber";
            this.luckyNumber.Size = new System.Drawing.Size(35, 17);
            this.luckyNumber.TabIndex = 15;
            this.luckyNumber.Text = "999";
            // 
            // IngameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(778, 429);
            this.Controls.Add(this.luckyNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.range);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pic3);
            this.Controls.Add(this.pic2);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.playerNum);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.answer);
            this.Controls.Add(this.btnReady);
            this.Controls.Add(this.conversation);
            this.Controls.Add(this.message);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "IngameForm";
            this.Text = "Anonymous";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox message;
        public System.Windows.Forms.RichTextBox conversation;
        private System.Windows.Forms.Button btnReady;
        private System.Windows.Forms.TextBox answer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label playerNum;
        private System.Windows.Forms.Button btnAutoPlaySingleTurn;
        private System.Windows.Forms.Button btnAutoplayWholeGame;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.PictureBox pic2;
        private System.Windows.Forms.PictureBox pic3;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label range;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label luckyNumber;
    }
}
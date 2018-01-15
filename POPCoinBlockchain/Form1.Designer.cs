namespace POPCoinBlockchain
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInstallLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lstProgress = new System.Windows.Forms.ListBox();
            this.btnLoadBlockchain = new System.Windows.Forms.Button();
            this.btnChooseInstallDir = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDonationAddr = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(532, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "This app installs most of the POPCoin blockchain on your computer, so your wallet" +
    " doesn\'t have to spend hours syncing with the network. ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(429, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "It is safe to remove this application after using it, the blockchain files it ins" +
    "talled will remain.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Install to:";
            // 
            // txtInstallLocation
            // 
            this.txtInstallLocation.Location = new System.Drawing.Point(12, 113);
            this.txtInstallLocation.Name = "txtInstallLocation";
            this.txtInstallLocation.Size = new System.Drawing.Size(505, 20);
            this.txtInstallLocation.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(535, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "(This should be the data folder for the POPCoin wallet.  Typically Users\\yourname" +
    "\\AppData\\Roaming\\POPCoin)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Progress";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(15, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(537, 1);
            this.label6.TabIndex = 7;
            // 
            // lstProgress
            // 
            this.lstProgress.FormattingEnabled = true;
            this.lstProgress.Location = new System.Drawing.Point(12, 245);
            this.lstProgress.Name = "lstProgress";
            this.lstProgress.Size = new System.Drawing.Size(540, 147);
            this.lstProgress.TabIndex = 9;
            // 
            // btnLoadBlockchain
            // 
            this.btnLoadBlockchain.Location = new System.Drawing.Point(187, 169);
            this.btnLoadBlockchain.Name = "btnLoadBlockchain";
            this.btnLoadBlockchain.Size = new System.Drawing.Size(139, 23);
            this.btnLoadBlockchain.TabIndex = 10;
            this.btnLoadBlockchain.Text = "Load Blockchain Files";
            this.btnLoadBlockchain.UseVisualStyleBackColor = true;
            this.btnLoadBlockchain.Click += new System.EventHandler(this.btnLoadBlockchain_Click);
            // 
            // btnChooseInstallDir
            // 
            this.btnChooseInstallDir.Location = new System.Drawing.Point(524, 113);
            this.btnChooseInstallDir.Name = "btnChooseInstallDir";
            this.btnChooseInstallDir.Size = new System.Drawing.Size(27, 23);
            this.btnChooseInstallDir.TabIndex = 12;
            this.btnChooseInstallDir.Text = "...";
            this.btnChooseInstallDir.UseVisualStyleBackColor = true;
            this.btnChooseInstallDir.Click += new System.EventHandler(this.btnChooseInstallDir_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 401);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "by Krank.";
            // 
            // txtDonationAddr
            // 
            this.txtDonationAddr.BackColor = System.Drawing.SystemColors.Control;
            this.txtDonationAddr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDonationAddr.Location = new System.Drawing.Point(343, 401);
            this.txtDonationAddr.Name = "txtDonationAddr";
            this.txtDonationAddr.ReadOnly = true;
            this.txtDonationAddr.Size = new System.Drawing.Size(213, 13);
            this.txtDonationAddr.TabIndex = 14;
            this.txtDonationAddr.TabStop = false;
            this.txtDonationAddr.Text = "QcjY9d25iGjkymRmvuBaV5xFqc3mUrKNdG";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(290, 401);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "POPCoin:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 216);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(534, 23);
            this.progressBar1.TabIndex = 16;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 423);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDonationAddr);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnChooseInstallDir);
            this.Controls.Add(this.btnLoadBlockchain);
            this.Controls.Add(this.lstProgress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtInstallLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "POPCoin Blockchain Installer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInstallLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstProgress;
        private System.Windows.Forms.Button btnLoadBlockchain;
        private System.Windows.Forms.Button btnChooseInstallDir;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDonationAddr;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
    }
}


namespace UI
{
    partial class frmUserMainMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.depositsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transfersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.depositToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.withdrawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.showTotalAmountSavedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUserID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCurrentMoneySaved = new System.Windows.Forms.Label();
            this.lblTotalMoneySaved = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transactionsToolStripMenuItem,
            this.depositToolStripMenuItem,
            this.withdrawToolStripMenuItem,
            this.savingsToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1056, 72);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // transactionsToolStripMenuItem
            // 
            this.transactionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.depositsToolStripMenuItem,
            this.expensesToolStripMenuItem,
            this.transfersToolStripMenuItem,
            this.allToolStripMenuItem});
            this.transactionsToolStripMenuItem.Image = global::UI.Properties.Resources.transaction64;
            this.transactionsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            this.transactionsToolStripMenuItem.Size = new System.Drawing.Size(168, 68);
            this.transactionsToolStripMenuItem.Text = "Transactions";
            // 
            // depositsToolStripMenuItem
            // 
            this.depositsToolStripMenuItem.Image = global::UI.Properties.Resources.deposit321;
            this.depositsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.depositsToolStripMenuItem.Name = "depositsToolStripMenuItem";
            this.depositsToolStripMenuItem.Size = new System.Drawing.Size(164, 38);
            this.depositsToolStripMenuItem.Text = "Deposits";
            this.depositsToolStripMenuItem.Click += new System.EventHandler(this.depositsToolStripMenuItem_Click);
            // 
            // expensesToolStripMenuItem
            // 
            this.expensesToolStripMenuItem.Image = global::UI.Properties.Resources.Withdraw321;
            this.expensesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.expensesToolStripMenuItem.Name = "expensesToolStripMenuItem";
            this.expensesToolStripMenuItem.Size = new System.Drawing.Size(164, 38);
            this.expensesToolStripMenuItem.Text = "Expenses";
            this.expensesToolStripMenuItem.Click += new System.EventHandler(this.expensesToolStripMenuItem_Click);
            // 
            // transfersToolStripMenuItem
            // 
            this.transfersToolStripMenuItem.Image = global::UI.Properties.Resources.transaction322;
            this.transfersToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.transfersToolStripMenuItem.Name = "transfersToolStripMenuItem";
            this.transfersToolStripMenuItem.Size = new System.Drawing.Size(164, 38);
            this.transfersToolStripMenuItem.Text = "Transfers";
            this.transfersToolStripMenuItem.Click += new System.EventHandler(this.transfersToolStripMenuItem_Click);
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Image = global::UI.Properties.Resources.transaction321;
            this.allToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(164, 38);
            this.allToolStripMenuItem.Text = "All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.allToolStripMenuItem_Click);
            // 
            // depositToolStripMenuItem
            // 
            this.depositToolStripMenuItem.Image = global::UI.Properties.Resources.deposit64;
            this.depositToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.depositToolStripMenuItem.Name = "depositToolStripMenuItem";
            this.depositToolStripMenuItem.Size = new System.Drawing.Size(139, 68);
            this.depositToolStripMenuItem.Text = "Deposit";
            this.depositToolStripMenuItem.Click += new System.EventHandler(this.depositToolStripMenuItem_Click);
            // 
            // withdrawToolStripMenuItem
            // 
            this.withdrawToolStripMenuItem.Image = global::UI.Properties.Resources.Withdraw64;
            this.withdrawToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.withdrawToolStripMenuItem.Name = "withdrawToolStripMenuItem";
            this.withdrawToolStripMenuItem.Size = new System.Drawing.Size(151, 68);
            this.withdrawToolStripMenuItem.Text = "Withdraw";
            this.withdrawToolStripMenuItem.Click += new System.EventHandler(this.withdrawToolStripMenuItem_Click);
            // 
            // savingsToolStripMenuItem
            // 
            this.savingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.showTotalAmountSavedToolStripMenuItem});
            this.savingsToolStripMenuItem.Image = global::UI.Properties.Resources.Savings64;
            this.savingsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.savingsToolStripMenuItem.Name = "savingsToolStripMenuItem";
            this.savingsToolStripMenuItem.Size = new System.Drawing.Size(137, 68);
            this.savingsToolStripMenuItem.Text = "Savings";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::UI.Properties.Resources.Manage_savings32;
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(278, 38);
            this.toolStripMenuItem1.Text = "Manage Saving Goals";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::UI.Properties.Resources.Add_saving32;
            this.toolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(278, 38);
            this.toolStripMenuItem2.Text = "Add New Saving Goal";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // showTotalAmountSavedToolStripMenuItem
            // 
            this.showTotalAmountSavedToolStripMenuItem.Image = global::UI.Properties.Resources.Savings32;
            this.showTotalAmountSavedToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showTotalAmountSavedToolStripMenuItem.Name = "showTotalAmountSavedToolStripMenuItem";
            this.showTotalAmountSavedToolStripMenuItem.Size = new System.Drawing.Size(278, 38);
            this.showTotalAmountSavedToolStripMenuItem.Text = "Show Total Amount Saved";
            this.showTotalAmountSavedToolStripMenuItem.Click += new System.EventHandler(this.showTotalAmountSavedToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem,
            this.signOutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.settingsToolStripMenuItem.Image = global::UI.Properties.Resources.settings64;
            this.settingsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(140, 68);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Image = global::UI.Properties.Resources.settings32;
            this.changePasswordToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(236, 38);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Image = global::UI.Properties.Resources.logout32;
            this.signOutToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(236, 38);
            this.signOutToolStripMenuItem.Text = "Sign out";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click_1);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::UI.Properties.Resources.cancel_32;
            this.exitToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(236, 38);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::UI.Properties.Resources.UserMM;
            this.pictureBox1.Location = new System.Drawing.Point(0, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1056, 493);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTotalMoneySaved);
            this.panel1.Controls.Add(this.lblCurrentMoneySaved);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblBalance);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblUsername);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblUserID);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(26, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(502, 437);
            this.panel1.TabIndex = 3;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.ForeColor = System.Drawing.Color.Black;
            this.lblUserID.Location = new System.Drawing.Point(279, 33);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(36, 25);
            this.lblUserID.TabIndex = 16;
            this.lblUserID.Text = "??";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "UserID:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.Black;
            this.lblUsername.Location = new System.Drawing.Point(279, 107);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(36, 25);
            this.lblUsername.TabIndex = 18;
            this.lblUsername.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "Username:";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.Black;
            this.lblBalance.Location = new System.Drawing.Point(279, 181);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(36, 25);
            this.lblBalance.TabIndex = 35;
            this.lblBalance.Text = "??";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 25);
            this.label3.TabIndex = 34;
            this.label3.Text = "Balance:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 25);
            this.label1.TabIndex = 36;
            this.label1.Text = "Current Money Saved:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 329);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 25);
            this.label4.TabIndex = 37;
            this.label4.Text = "Total Money Saved:";
            // 
            // lblCurrentMoneySaved
            // 
            this.lblCurrentMoneySaved.AutoSize = true;
            this.lblCurrentMoneySaved.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentMoneySaved.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentMoneySaved.Location = new System.Drawing.Point(279, 255);
            this.lblCurrentMoneySaved.Name = "lblCurrentMoneySaved";
            this.lblCurrentMoneySaved.Size = new System.Drawing.Size(36, 25);
            this.lblCurrentMoneySaved.TabIndex = 38;
            this.lblCurrentMoneySaved.Text = "??";
            // 
            // lblTotalMoneySaved
            // 
            this.lblTotalMoneySaved.AutoSize = true;
            this.lblTotalMoneySaved.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMoneySaved.ForeColor = System.Drawing.Color.Black;
            this.lblTotalMoneySaved.Location = new System.Drawing.Point(279, 329);
            this.lblTotalMoneySaved.Name = "lblTotalMoneySaved";
            this.lblTotalMoneySaved.Size = new System.Drawing.Size(36, 25);
            this.lblTotalMoneySaved.TabIndex = 39;
            this.lblTotalMoneySaved.Text = "??";
            // 
            // frmUserMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 565);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmUserMainMenu";
            this.Text = "User Main Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmUserMainMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem depositToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem withdrawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem showTotalAmountSavedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem depositsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transfersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalMoneySaved;
        private System.Windows.Forms.Label lblCurrentMoneySaved;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label3;
    }
}
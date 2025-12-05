namespace UI
{
    partial class frmManageSavingGoals
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
            this.txtFilterBy = new System.Windows.Forms.TextBox();
            this.btnChooseDate = new System.Windows.Forms.Button();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvSavingGoals = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewSavingGoalInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteGoalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddSavingGoal = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbIsCompleted = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSavingGoals)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilterBy
            // 
            this.txtFilterBy.Location = new System.Drawing.Point(305, 257);
            this.txtFilterBy.Name = "txtFilterBy";
            this.txtFilterBy.Size = new System.Drawing.Size(179, 22);
            this.txtFilterBy.TabIndex = 17;
            this.txtFilterBy.TextChanged += new System.EventHandler(this.txtFilterBy_TextChanged);
            this.txtFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterBy_KeyPress);
            // 
            // btnChooseDate
            // 
            this.btnChooseDate.Location = new System.Drawing.Point(500, 256);
            this.btnChooseDate.Name = "btnChooseDate";
            this.btnChooseDate.Size = new System.Drawing.Size(121, 24);
            this.btnChooseDate.TabIndex = 18;
            this.btnChooseDate.Text = "Choose Date";
            this.btnChooseDate.UseVisualStyleBackColor = true;
            this.btnChooseDate.Visible = false;
            this.btnChooseDate.Click += new System.EventHandler(this.btnChooseDate_Click);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Category",
            "Target amount or less than",
            "Current amount or less than",
            "Start date",
            "End date",
            "Is Completed"});
            this.cbFilterBy.Location = new System.Drawing.Point(114, 256);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(172, 24);
            this.cbFilterBy.TabIndex = 16;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 25);
            this.label3.TabIndex = 28;
            this.label3.Text = "Filter By";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(1015, 635);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(109, 41);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecords.Location = new System.Drawing.Point(155, 643);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(36, 25);
            this.lblNumberOfRecords.TabIndex = 27;
            this.lblNumberOfRecords.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 643);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 25);
            this.label2.TabIndex = 26;
            this.label2.Text = "No. Records:";
            // 
            // dgvSavingGoals
            // 
            this.dgvSavingGoals.AllowUserToAddRows = false;
            this.dgvSavingGoals.AllowUserToDeleteRows = false;
            this.dgvSavingGoals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSavingGoals.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSavingGoals.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvSavingGoals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSavingGoals.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvSavingGoals.Location = new System.Drawing.Point(12, 303);
            this.dgvSavingGoals.Name = "dgvSavingGoals";
            this.dgvSavingGoals.ReadOnly = true;
            this.dgvSavingGoals.RowHeadersWidth = 51;
            this.dgvSavingGoals.RowTemplate.Height = 24;
            this.dgvSavingGoals.Size = new System.Drawing.Size(1112, 326);
            this.dgvSavingGoals.TabIndex = 25;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewSavingGoalInfoToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.deleteGoalToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(192, 118);
            // 
            // viewSavingGoalInfoToolStripMenuItem
            // 
            this.viewSavingGoalInfoToolStripMenuItem.Image = global::UI.Properties.Resources.info32;
            this.viewSavingGoalInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewSavingGoalInfoToolStripMenuItem.Name = "viewSavingGoalInfoToolStripMenuItem";
            this.viewSavingGoalInfoToolStripMenuItem.Size = new System.Drawing.Size(191, 38);
            this.viewSavingGoalInfoToolStripMenuItem.Text = "View Goal Info";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Image = global::UI.Properties.Resources.update32;
            this.updateToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(191, 38);
            this.updateToolStripMenuItem.Text = "Update Goal";
            // 
            // deleteGoalToolStripMenuItem
            // 
            this.deleteGoalToolStripMenuItem.Image = global::UI.Properties.Resources.Delete_saving32;
            this.deleteGoalToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteGoalToolStripMenuItem.Name = "deleteGoalToolStripMenuItem";
            this.deleteGoalToolStripMenuItem.Size = new System.Drawing.Size(191, 38);
            this.deleteGoalToolStripMenuItem.Text = "Delete Goal";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(341, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(457, 58);
            this.label1.TabIndex = 23;
            this.label1.Text = "Manage Saving Goals";
            // 
            // btnAddSavingGoal
            // 
            this.btnAddSavingGoal.Image = global::UI.Properties.Resources.Add_saving32;
            this.btnAddSavingGoal.Location = new System.Drawing.Point(1046, 221);
            this.btnAddSavingGoal.Name = "btnAddSavingGoal";
            this.btnAddSavingGoal.Size = new System.Drawing.Size(78, 71);
            this.btnAddSavingGoal.TabIndex = 21;
            this.btnAddSavingGoal.UseVisualStyleBackColor = true;
            this.btnAddSavingGoal.Click += new System.EventHandler(this.btnAddSavingGoal_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.Savings512;
            this.pictureBox1.Location = new System.Drawing.Point(486, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 136);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // cbIsCompleted
            // 
            this.cbIsCompleted.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsCompleted.FormattingEnabled = true;
            this.cbIsCompleted.Items.AddRange(new object[] {
            "None",
            "Yes",
            "No"});
            this.cbIsCompleted.Location = new System.Drawing.Point(305, 255);
            this.cbIsCompleted.Name = "cbIsCompleted";
            this.cbIsCompleted.Size = new System.Drawing.Size(93, 24);
            this.cbIsCompleted.TabIndex = 29;
            this.cbIsCompleted.SelectedIndexChanged += new System.EventHandler(this.cbIsCompleted_SelectedIndexChanged);
            // 
            // frmManageSavingGoals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 692);
            this.Controls.Add(this.cbIsCompleted);
            this.Controls.Add(this.txtFilterBy);
            this.Controls.Add(this.btnAddSavingGoal);
            this.Controls.Add(this.btnChooseDate);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvSavingGoals);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmManageSavingGoals";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Saving Goals";
            this.Load += new System.EventHandler(this.frmManageSavingGoals_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSavingGoals)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtFilterBy;
        private System.Windows.Forms.Button btnAddSavingGoal;
        private System.Windows.Forms.Button btnChooseDate;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvSavingGoals;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewSavingGoalInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteGoalToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbIsCompleted;
    }
}
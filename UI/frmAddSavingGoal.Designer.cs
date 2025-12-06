namespace UI
{
    partial class frmAddSavingGoal
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCategories = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGoalName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGoalDescription = new System.Windows.Forms.TextBox();
            this.txtTargetAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.btnChooseStartDate = new System.Windows.Forms.Button();
            this.btnChooseEndDate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClearStartingDate = new System.Windows.Forms.Button();
            this.btnClearEndingDate = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Palatino Linotype", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(167, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(469, 58);
            this.lblTitle.TabIndex = 24;
            this.lblTitle.Text = "Add New Saving Goal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 25);
            this.label3.TabIndex = 29;
            this.label3.Text = "Category:";
            // 
            // cbCategories
            // 
            this.cbCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategories.FormattingEnabled = true;
            this.cbCategories.Location = new System.Drawing.Point(145, 94);
            this.cbCategories.Name = "cbCategories";
            this.cbCategories.Size = new System.Drawing.Size(228, 24);
            this.cbCategories.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 25);
            this.label2.TabIndex = 31;
            this.label2.Text = "Goal Name:";
            // 
            // txtGoalName
            // 
            this.txtGoalName.Location = new System.Drawing.Point(145, 146);
            this.txtGoalName.Multiline = true;
            this.txtGoalName.Name = "txtGoalName";
            this.txtGoalName.Size = new System.Drawing.Size(228, 81);
            this.txtGoalName.TabIndex = 32;
            this.txtGoalName.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyString);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 25);
            this.label4.TabIndex = 33;
            this.label4.Text = "Description:";
            // 
            // txtGoalDescription
            // 
            this.txtGoalDescription.Location = new System.Drawing.Point(145, 264);
            this.txtGoalDescription.Multiline = true;
            this.txtGoalDescription.Name = "txtGoalDescription";
            this.txtGoalDescription.Size = new System.Drawing.Size(228, 146);
            this.txtGoalDescription.TabIndex = 34;
            // 
            // txtTargetAmount
            // 
            this.txtTargetAmount.Location = new System.Drawing.Point(576, 95);
            this.txtTargetAmount.Name = "txtTargetAmount";
            this.txtTargetAmount.Size = new System.Drawing.Size(179, 22);
            this.txtTargetAmount.TabIndex = 35;
            this.txtTargetAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTargetAmount_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(390, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 25);
            this.label5.TabIndex = 36;
            this.label5.Text = "Target Amount:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(407, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 25);
            this.label6.TabIndex = 37;
            this.label6.Text = "Starting Date:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(415, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 25);
            this.label7.TabIndex = 38;
            this.label7.Text = "Ending Date:";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Enabled = false;
            this.txtStartDate.Location = new System.Drawing.Point(576, 173);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(179, 22);
            this.txtStartDate.TabIndex = 39;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Enabled = false;
            this.txtEndDate.Location = new System.Drawing.Point(576, 232);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(179, 22);
            this.txtEndDate.TabIndex = 40;
            // 
            // btnChooseStartDate
            // 
            this.btnChooseStartDate.Location = new System.Drawing.Point(420, 281);
            this.btnChooseStartDate.Name = "btnChooseStartDate";
            this.btnChooseStartDate.Size = new System.Drawing.Size(136, 49);
            this.btnChooseStartDate.TabIndex = 41;
            this.btnChooseStartDate.Text = "Choose Starting Date";
            this.btnChooseStartDate.UseVisualStyleBackColor = true;
            this.btnChooseStartDate.Click += new System.EventHandler(this.btnChooseStartDate_Click);
            // 
            // btnChooseEndDate
            // 
            this.btnChooseEndDate.Location = new System.Drawing.Point(601, 281);
            this.btnChooseEndDate.Name = "btnChooseEndDate";
            this.btnChooseEndDate.Size = new System.Drawing.Size(136, 49);
            this.btnChooseEndDate.TabIndex = 42;
            this.btnChooseEndDate.Text = "Choose Ending Date";
            this.btnChooseEndDate.UseVisualStyleBackColor = true;
            this.btnChooseEndDate.Click += new System.EventHandler(this.btnChooseEndDate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(652, 460);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(136, 49);
            this.btnSave.TabIndex = 43;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(500, 460);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(136, 49);
            this.btnClose.TabIndex = 44;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClearStartingDate
            // 
            this.btnClearStartingDate.Location = new System.Drawing.Point(420, 336);
            this.btnClearStartingDate.Name = "btnClearStartingDate";
            this.btnClearStartingDate.Size = new System.Drawing.Size(136, 49);
            this.btnClearStartingDate.TabIndex = 45;
            this.btnClearStartingDate.Text = "Clear Starting Date";
            this.btnClearStartingDate.UseVisualStyleBackColor = true;
            this.btnClearStartingDate.Click += new System.EventHandler(this.btnClearStartingDate_Click);
            // 
            // btnClearEndingDate
            // 
            this.btnClearEndingDate.Location = new System.Drawing.Point(601, 336);
            this.btnClearEndingDate.Name = "btnClearEndingDate";
            this.btnClearEndingDate.Size = new System.Drawing.Size(136, 49);
            this.btnClearEndingDate.TabIndex = 46;
            this.btnClearEndingDate.Text = "Clear Ending Date";
            this.btnClearEndingDate.UseVisualStyleBackColor = true;
            this.btnClearEndingDate.Click += new System.EventHandler(this.btnClearEndingDate_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddSavingGoal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 521);
            this.Controls.Add(this.btnClearEndingDate);
            this.Controls.Add(this.btnClearStartingDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnChooseEndDate);
            this.Controls.Add(this.btnChooseStartDate);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTargetAmount);
            this.Controls.Add(this.txtGoalDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtGoalName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCategories);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddSavingGoal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Saving Goal";
            this.Load += new System.EventHandler(this.frmAddSavingGoal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCategories;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGoalName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGoalDescription;
        private System.Windows.Forms.TextBox txtTargetAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.Button btnChooseStartDate;
        private System.Windows.Forms.Button btnChooseEndDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClearStartingDate;
        private System.Windows.Forms.Button btnClearEndingDate;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
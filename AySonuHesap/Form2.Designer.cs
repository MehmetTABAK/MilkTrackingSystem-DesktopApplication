namespace AySonuHesap
{
    partial class Form2
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
            this.peopleAddLabel = new System.Windows.Forms.Label();
            this.peopleAddTextBox = new System.Windows.Forms.TextBox();
            this.peopleListDataGridView = new System.Windows.Forms.DataGridView();
            this.peopleAddButton = new System.Windows.Forms.Button();
            this.peopleAddGroupBox = new System.Windows.Forms.GroupBox();
            this.peopleDeleteGroupBox = new System.Windows.Forms.GroupBox();
            this.peopleDeleteTextBox = new System.Windows.Forms.TextBox();
            this.peopleDeleteButton = new System.Windows.Forms.Button();
            this.peopleDeleteLabel = new System.Windows.Forms.Label();
            this.peopleUpdateGroupBox = new System.Windows.Forms.GroupBox();
            this.peopleUpdateTextBoxOldName = new System.Windows.Forms.TextBox();
            this.peopleUpdateTextBoxNewName = new System.Windows.Forms.TextBox();
            this.peopleUpdateTextBoxLabel = new System.Windows.Forms.Label();
            this.peopleUpdateButton = new System.Windows.Forms.Button();
            this.peopleUpdateComboBoxLabel = new System.Windows.Forms.Label();
            this.peopleListLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.peopleListDataGridView)).BeginInit();
            this.peopleAddGroupBox.SuspendLayout();
            this.peopleDeleteGroupBox.SuspendLayout();
            this.peopleUpdateGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // peopleAddLabel
            // 
            this.peopleAddLabel.AutoSize = true;
            this.peopleAddLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.peopleAddLabel.Location = new System.Drawing.Point(45, 31);
            this.peopleAddLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.peopleAddLabel.Name = "peopleAddLabel";
            this.peopleAddLabel.Size = new System.Drawing.Size(112, 20);
            this.peopleAddLabel.TabIndex = 24;
            this.peopleAddLabel.Text = "Kişi Adı Soyadı";
            // 
            // peopleAddTextBox
            // 
            this.peopleAddTextBox.Location = new System.Drawing.Point(18, 70);
            this.peopleAddTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.peopleAddTextBox.Multiline = true;
            this.peopleAddTextBox.Name = "peopleAddTextBox";
            this.peopleAddTextBox.Size = new System.Drawing.Size(176, 31);
            this.peopleAddTextBox.TabIndex = 16;
            this.peopleAddTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // peopleListDataGridView
            // 
            this.peopleListDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.peopleListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.peopleListDataGridView.Location = new System.Drawing.Point(488, 57);
            this.peopleListDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.peopleListDataGridView.Name = "peopleListDataGridView";
            this.peopleListDataGridView.RowHeadersWidth = 51;
            this.peopleListDataGridView.RowTemplate.Height = 24;
            this.peopleListDataGridView.Size = new System.Drawing.Size(722, 646);
            this.peopleListDataGridView.TabIndex = 15;
            this.peopleListDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.peopleListDataGridView_CellContentClick);
            // 
            // peopleAddButton
            // 
            this.peopleAddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.peopleAddButton.Location = new System.Drawing.Point(49, 124);
            this.peopleAddButton.Margin = new System.Windows.Forms.Padding(2);
            this.peopleAddButton.Name = "peopleAddButton";
            this.peopleAddButton.Size = new System.Drawing.Size(107, 56);
            this.peopleAddButton.TabIndex = 14;
            this.peopleAddButton.Text = "Kaydet";
            this.peopleAddButton.UseVisualStyleBackColor = true;
            this.peopleAddButton.Click += new System.EventHandler(this.peopleAddButton_Click);
            // 
            // peopleAddGroupBox
            // 
            this.peopleAddGroupBox.BackColor = System.Drawing.Color.Coral;
            this.peopleAddGroupBox.Controls.Add(this.peopleAddButton);
            this.peopleAddGroupBox.Controls.Add(this.peopleAddTextBox);
            this.peopleAddGroupBox.Controls.Add(this.peopleAddLabel);
            this.peopleAddGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.peopleAddGroupBox.Location = new System.Drawing.Point(20, 113);
            this.peopleAddGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.peopleAddGroupBox.Name = "peopleAddGroupBox";
            this.peopleAddGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.peopleAddGroupBox.Size = new System.Drawing.Size(213, 197);
            this.peopleAddGroupBox.TabIndex = 29;
            this.peopleAddGroupBox.TabStop = false;
            this.peopleAddGroupBox.Text = "Kişi Ekle";
            // 
            // peopleDeleteGroupBox
            // 
            this.peopleDeleteGroupBox.BackColor = System.Drawing.Color.Coral;
            this.peopleDeleteGroupBox.Controls.Add(this.peopleDeleteTextBox);
            this.peopleDeleteGroupBox.Controls.Add(this.peopleDeleteButton);
            this.peopleDeleteGroupBox.Controls.Add(this.peopleDeleteLabel);
            this.peopleDeleteGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.peopleDeleteGroupBox.Location = new System.Drawing.Point(250, 113);
            this.peopleDeleteGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.peopleDeleteGroupBox.Name = "peopleDeleteGroupBox";
            this.peopleDeleteGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.peopleDeleteGroupBox.Size = new System.Drawing.Size(213, 197);
            this.peopleDeleteGroupBox.TabIndex = 30;
            this.peopleDeleteGroupBox.TabStop = false;
            this.peopleDeleteGroupBox.Text = "Kişi Sil";
            // 
            // peopleDeleteTextBox
            // 
            this.peopleDeleteTextBox.Enabled = false;
            this.peopleDeleteTextBox.Location = new System.Drawing.Point(22, 70);
            this.peopleDeleteTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.peopleDeleteTextBox.Multiline = true;
            this.peopleDeleteTextBox.Name = "peopleDeleteTextBox";
            this.peopleDeleteTextBox.ReadOnly = true;
            this.peopleDeleteTextBox.Size = new System.Drawing.Size(176, 31);
            this.peopleDeleteTextBox.TabIndex = 27;
            this.peopleDeleteTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // peopleDeleteButton
            // 
            this.peopleDeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.peopleDeleteButton.Location = new System.Drawing.Point(62, 124);
            this.peopleDeleteButton.Margin = new System.Windows.Forms.Padding(2);
            this.peopleDeleteButton.Name = "peopleDeleteButton";
            this.peopleDeleteButton.Size = new System.Drawing.Size(107, 56);
            this.peopleDeleteButton.TabIndex = 26;
            this.peopleDeleteButton.Text = "Sil";
            this.peopleDeleteButton.UseVisualStyleBackColor = true;
            this.peopleDeleteButton.Click += new System.EventHandler(this.peopleDeleteButton_Click);
            // 
            // peopleDeleteLabel
            // 
            this.peopleDeleteLabel.AutoSize = true;
            this.peopleDeleteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.peopleDeleteLabel.Location = new System.Drawing.Point(58, 31);
            this.peopleDeleteLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.peopleDeleteLabel.Name = "peopleDeleteLabel";
            this.peopleDeleteLabel.Size = new System.Drawing.Size(100, 20);
            this.peopleDeleteLabel.TabIndex = 25;
            this.peopleDeleteLabel.Text = "Silinecek Kişi";
            // 
            // peopleUpdateGroupBox
            // 
            this.peopleUpdateGroupBox.BackColor = System.Drawing.Color.Coral;
            this.peopleUpdateGroupBox.Controls.Add(this.peopleUpdateTextBoxOldName);
            this.peopleUpdateGroupBox.Controls.Add(this.peopleUpdateTextBoxNewName);
            this.peopleUpdateGroupBox.Controls.Add(this.peopleUpdateTextBoxLabel);
            this.peopleUpdateGroupBox.Controls.Add(this.peopleUpdateButton);
            this.peopleUpdateGroupBox.Controls.Add(this.peopleUpdateComboBoxLabel);
            this.peopleUpdateGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.peopleUpdateGroupBox.Location = new System.Drawing.Point(146, 333);
            this.peopleUpdateGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.peopleUpdateGroupBox.Name = "peopleUpdateGroupBox";
            this.peopleUpdateGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.peopleUpdateGroupBox.Size = new System.Drawing.Size(213, 284);
            this.peopleUpdateGroupBox.TabIndex = 31;
            this.peopleUpdateGroupBox.TabStop = false;
            this.peopleUpdateGroupBox.Text = "Kişi Güncelle";
            // 
            // peopleUpdateTextBoxOldName
            // 
            this.peopleUpdateTextBoxOldName.Enabled = false;
            this.peopleUpdateTextBoxOldName.Location = new System.Drawing.Point(18, 62);
            this.peopleUpdateTextBoxOldName.Margin = new System.Windows.Forms.Padding(2);
            this.peopleUpdateTextBoxOldName.Multiline = true;
            this.peopleUpdateTextBoxOldName.Name = "peopleUpdateTextBoxOldName";
            this.peopleUpdateTextBoxOldName.ReadOnly = true;
            this.peopleUpdateTextBoxOldName.Size = new System.Drawing.Size(176, 31);
            this.peopleUpdateTextBoxOldName.TabIndex = 29;
            this.peopleUpdateTextBoxOldName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // peopleUpdateTextBoxNewName
            // 
            this.peopleUpdateTextBoxNewName.Location = new System.Drawing.Point(21, 139);
            this.peopleUpdateTextBoxNewName.Margin = new System.Windows.Forms.Padding(2);
            this.peopleUpdateTextBoxNewName.Multiline = true;
            this.peopleUpdateTextBoxNewName.Name = "peopleUpdateTextBoxNewName";
            this.peopleUpdateTextBoxNewName.Size = new System.Drawing.Size(176, 32);
            this.peopleUpdateTextBoxNewName.TabIndex = 27;
            this.peopleUpdateTextBoxNewName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // peopleUpdateTextBoxLabel
            // 
            this.peopleUpdateTextBoxLabel.AutoSize = true;
            this.peopleUpdateTextBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.peopleUpdateTextBoxLabel.Location = new System.Drawing.Point(52, 106);
            this.peopleUpdateTextBoxLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.peopleUpdateTextBoxLabel.Name = "peopleUpdateTextBoxLabel";
            this.peopleUpdateTextBoxLabel.Size = new System.Drawing.Size(112, 20);
            this.peopleUpdateTextBoxLabel.TabIndex = 28;
            this.peopleUpdateTextBoxLabel.Text = "Kişi Adı Soyadı";
            // 
            // peopleUpdateButton
            // 
            this.peopleUpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.peopleUpdateButton.Location = new System.Drawing.Point(56, 196);
            this.peopleUpdateButton.Margin = new System.Windows.Forms.Padding(2);
            this.peopleUpdateButton.Name = "peopleUpdateButton";
            this.peopleUpdateButton.Size = new System.Drawing.Size(107, 56);
            this.peopleUpdateButton.TabIndex = 26;
            this.peopleUpdateButton.Text = "Güncelle";
            this.peopleUpdateButton.UseVisualStyleBackColor = true;
            this.peopleUpdateButton.Click += new System.EventHandler(this.peopleUpdateButton_Click);
            // 
            // peopleUpdateComboBoxLabel
            // 
            this.peopleUpdateComboBoxLabel.AutoSize = true;
            this.peopleUpdateComboBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.peopleUpdateComboBoxLabel.Location = new System.Drawing.Point(40, 34);
            this.peopleUpdateComboBoxLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.peopleUpdateComboBoxLabel.Name = "peopleUpdateComboBoxLabel";
            this.peopleUpdateComboBoxLabel.Size = new System.Drawing.Size(143, 20);
            this.peopleUpdateComboBoxLabel.TabIndex = 25;
            this.peopleUpdateComboBoxLabel.Text = "Güncellenecek Kişi";
            // 
            // peopleListLabel
            // 
            this.peopleListLabel.AutoSize = true;
            this.peopleListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.peopleListLabel.Location = new System.Drawing.Point(798, 11);
            this.peopleListLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.peopleListLabel.Name = "peopleListLabel";
            this.peopleListLabel.Size = new System.Drawing.Size(88, 31);
            this.peopleListLabel.TabIndex = 32;
            this.peopleListLabel.Text = "Kişiler";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 714);
            this.Controls.Add(this.peopleListLabel);
            this.Controls.Add(this.peopleUpdateGroupBox);
            this.Controls.Add(this.peopleDeleteGroupBox);
            this.Controls.Add(this.peopleAddGroupBox);
            this.Controls.Add(this.peopleListDataGridView);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kişiler";
            ((System.ComponentModel.ISupportInitialize)(this.peopleListDataGridView)).EndInit();
            this.peopleAddGroupBox.ResumeLayout(false);
            this.peopleAddGroupBox.PerformLayout();
            this.peopleDeleteGroupBox.ResumeLayout(false);
            this.peopleDeleteGroupBox.PerformLayout();
            this.peopleUpdateGroupBox.ResumeLayout(false);
            this.peopleUpdateGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label peopleAddLabel;
        private System.Windows.Forms.TextBox peopleAddTextBox;
        private System.Windows.Forms.DataGridView peopleListDataGridView;
        private System.Windows.Forms.Button peopleAddButton;
        private System.Windows.Forms.GroupBox peopleAddGroupBox;
        private System.Windows.Forms.GroupBox peopleDeleteGroupBox;
        private System.Windows.Forms.Button peopleDeleteButton;
        private System.Windows.Forms.Label peopleDeleteLabel;
        private System.Windows.Forms.GroupBox peopleUpdateGroupBox;
        private System.Windows.Forms.TextBox peopleUpdateTextBoxNewName;
        private System.Windows.Forms.Label peopleUpdateTextBoxLabel;
        private System.Windows.Forms.Button peopleUpdateButton;
        private System.Windows.Forms.Label peopleUpdateComboBoxLabel;
        private System.Windows.Forms.Label peopleListLabel;
        private System.Windows.Forms.TextBox peopleDeleteTextBox;
        private System.Windows.Forms.TextBox peopleUpdateTextBoxOldName;
    }
}
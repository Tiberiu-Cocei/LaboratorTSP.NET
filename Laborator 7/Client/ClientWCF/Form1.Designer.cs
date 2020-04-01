namespace ClientWCF
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
            this.changeButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.chooseFileButton = new System.Windows.Forms.Button();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.fileDescriptionBox = new System.Windows.Forms.TextBox();
            this.filePathBox = new System.Windows.Forms.TextBox();
            this.addFileButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.propertyDescButton = new System.Windows.Forms.Button();
            this.fileView = new System.Windows.Forms.ListView();
            this.fileId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileToDelete = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.propertyView = new System.Windows.Forms.ListView();
            this.descriptionId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.propertyDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.searchButton = new System.Windows.Forms.Button();
            this.propertyDeleteButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveFileButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(189, 294);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(87, 23);
            this.changeButton.TabIndex = 3;
            this.changeButton.Text = "Change File";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(282, 294);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(77, 23);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Delete File(s)";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(461, 294);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(84, 23);
            this.confirmButton.TabIndex = 5;
            this.confirmButton.Text = "Confirm Delete";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // chooseFileButton
            // 
            this.chooseFileButton.Location = new System.Drawing.Point(27, 367);
            this.chooseFileButton.Name = "chooseFileButton";
            this.chooseFileButton.Size = new System.Drawing.Size(87, 23);
            this.chooseFileButton.TabIndex = 6;
            this.chooseFileButton.Text = "Choose File";
            this.chooseFileButton.UseVisualStyleBackColor = true;
            this.chooseFileButton.Click += new System.EventHandler(this.chooseFileButton_Click);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(768, 368);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(268, 20);
            this.nameBox.TabIndex = 7;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // fileDescriptionBox
            // 
            this.fileDescriptionBox.Location = new System.Drawing.Point(267, 394);
            this.fileDescriptionBox.Multiline = true;
            this.fileDescriptionBox.Name = "fileDescriptionBox";
            this.fileDescriptionBox.Size = new System.Drawing.Size(423, 26);
            this.fileDescriptionBox.TabIndex = 8;
            this.fileDescriptionBox.TextChanged += new System.EventHandler(this.fileDescriptionBox_TextChanged);
            // 
            // filePathBox
            // 
            this.filePathBox.Location = new System.Drawing.Point(267, 368);
            this.filePathBox.Multiline = true;
            this.filePathBox.Name = "filePathBox";
            this.filePathBox.ReadOnly = true;
            this.filePathBox.Size = new System.Drawing.Size(423, 20);
            this.filePathBox.TabIndex = 9;
            this.filePathBox.TextChanged += new System.EventHandler(this.filePathBox_TextChanged);
            // 
            // addFileButton
            // 
            this.addFileButton.Location = new System.Drawing.Point(120, 367);
            this.addFileButton.Name = "addFileButton";
            this.addFileButton.Size = new System.Drawing.Size(87, 23);
            this.addFileButton.TabIndex = 10;
            this.addFileButton.Text = "Add File";
            this.addFileButton.UseVisualStyleBackColor = true;
            this.addFileButton.Click += new System.EventHandler(this.addFileButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(27, 336);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(461, 20);
            this.textBox1.TabIndex = 11;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // propertyDescButton
            // 
            this.propertyDescButton.Location = new System.Drawing.Point(494, 335);
            this.propertyDescButton.Name = "propertyDescButton";
            this.propertyDescButton.Size = new System.Drawing.Size(80, 23);
            this.propertyDescButton.TabIndex = 12;
            this.propertyDescButton.Text = "Add Property";
            this.propertyDescButton.UseVisualStyleBackColor = true;
            this.propertyDescButton.Click += new System.EventHandler(this.propertyDescButton_Click);
            // 
            // fileView
            // 
            this.fileView.CheckBoxes = true;
            this.fileView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileId,
            this.fileName,
            this.fileDescription,
            this.filePath,
            this.fileSize,
            this.fileDate,
            this.fileToDelete});
            this.fileView.GridLines = true;
            this.fileView.HideSelection = false;
            this.fileView.Location = new System.Drawing.Point(27, 12);
            this.fileView.Name = "fileView";
            this.fileView.Size = new System.Drawing.Size(774, 276);
            this.fileView.TabIndex = 13;
            this.fileView.UseCompatibleStateImageBehavior = false;
            this.fileView.View = System.Windows.Forms.View.Details;
            this.fileView.SelectedIndexChanged += new System.EventHandler(this.fileView_SelectedIndexChanged);
            // 
            // fileId
            // 
            this.fileId.Text = "Id";
            this.fileId.Width = 50;
            // 
            // fileName
            // 
            this.fileName.Text = "Name";
            this.fileName.Width = 100;
            // 
            // fileDescription
            // 
            this.fileDescription.Text = "Description";
            this.fileDescription.Width = 160;
            // 
            // filePath
            // 
            this.filePath.Text = "Path";
            this.filePath.Width = 225;
            // 
            // fileSize
            // 
            this.fileSize.Text = "Size";
            this.fileSize.Width = 75;
            // 
            // fileDate
            // 
            this.fileDate.Text = "Date";
            this.fileDate.Width = 100;
            // 
            // fileToDelete
            // 
            this.fileToDelete.Text = "To Delete";
            // 
            // propertyView
            // 
            this.propertyView.CheckBoxes = true;
            this.propertyView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.descriptionId,
            this.propertyDescription});
            this.propertyView.GridLines = true;
            this.propertyView.HideSelection = false;
            this.propertyView.Location = new System.Drawing.Point(824, 12);
            this.propertyView.Name = "propertyView";
            this.propertyView.Size = new System.Drawing.Size(255, 276);
            this.propertyView.TabIndex = 14;
            this.propertyView.UseCompatibleStateImageBehavior = false;
            this.propertyView.View = System.Windows.Forms.View.Details;
            this.propertyView.SelectedIndexChanged += new System.EventHandler(this.propertyView_SelectedIndexChanged);
            // 
            // descriptionId
            // 
            this.descriptionId.Text = "Id";
            this.descriptionId.Width = 50;
            // 
            // propertyDescription
            // 
            this.propertyDescription.Text = "Description";
            this.propertyDescription.Width = 200;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(27, 294);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 15;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // propertyDeleteButton
            // 
            this.propertyDeleteButton.Location = new System.Drawing.Point(981, 294);
            this.propertyDeleteButton.Name = "propertyDeleteButton";
            this.propertyDeleteButton.Size = new System.Drawing.Size(98, 23);
            this.propertyDeleteButton.TabIndex = 16;
            this.propertyDeleteButton.Text = "Delete Properties";
            this.propertyDeleteButton.UseVisualStyleBackColor = true;
            this.propertyDeleteButton.Click += new System.EventHandler(this.propertyDeleteButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(365, 294);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(90, 23);
            this.cancelButton.TabIndex = 17;
            this.cancelButton.Text = "Cancel Delete";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 372);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "File Path";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(708, 371);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "File Name";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(182, 400);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "File Description";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(108, 294);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(75, 23);
            this.openFileButton.TabIndex = 21;
            this.openFileButton.Text = "Open File";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(282, 436);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(561, 330);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // saveFileButton
            // 
            this.saveFileButton.Location = new System.Drawing.Point(551, 294);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(75, 23);
            this.saveFileButton.TabIndex = 23;
            this.saveFileButton.Text = "Save To ";
            this.saveFileButton.UseVisualStyleBackColor = true;
            this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 808);
            this.Controls.Add(this.saveFileButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.propertyDeleteButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.propertyView);
            this.Controls.Add(this.fileView);
            this.Controls.Add(this.propertyDescButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.addFileButton);
            this.Controls.Add(this.filePathBox);
            this.Controls.Add(this.fileDescriptionBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.chooseFileButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.changeButton);
            this.Name = "GUI";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button chooseFileButton;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox fileDescriptionBox;
        private System.Windows.Forms.TextBox filePathBox;
        private System.Windows.Forms.Button addFileButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button propertyDescButton;
        private System.Windows.Forms.ListView fileView;
        private System.Windows.Forms.ListView propertyView;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ColumnHeader fileName;
        private System.Windows.Forms.ColumnHeader fileDescription;
        private System.Windows.Forms.ColumnHeader filePath;
        private System.Windows.Forms.ColumnHeader fileSize;
        private System.Windows.Forms.ColumnHeader fileDate;
        private System.Windows.Forms.ColumnHeader fileToDelete;
        private System.Windows.Forms.ColumnHeader propertyDescription;
        private System.Windows.Forms.Button propertyDeleteButton;
        private System.Windows.Forms.ColumnHeader fileId;
        private System.Windows.Forms.ColumnHeader descriptionId;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button saveFileButton;
    }
}


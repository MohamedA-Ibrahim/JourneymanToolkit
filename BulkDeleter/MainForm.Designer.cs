namespace BulkDeleter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.lstFileNames = new System.Windows.Forms.ListBox();
            this.btnCleanFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMarkMissingLines = new System.Windows.Forms.Button();
            this.btnChangeFilenames = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblStatus.Location = new System.Drawing.Point(8, 352);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(63, 19);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status: ";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectFile.ForeColor = System.Drawing.Color.Black;
            this.btnSelectFile.Location = new System.Drawing.Point(546, 55);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(122, 40);
            this.btnSelectFile.TabIndex = 1;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // txtFile
            // 
            this.txtFile.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFile.Location = new System.Drawing.Point(7, 55);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(459, 27);
            this.txtFile.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Step 2 : Select the directory where the files are located";
            // 
            // txtFolder
            // 
            this.txtFolder.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolder.Location = new System.Drawing.Point(10, 261);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(459, 27);
            this.txtFolder.TabIndex = 2;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectFolder.ForeColor = System.Drawing.Color.Black;
            this.btnSelectFolder.Location = new System.Drawing.Point(546, 253);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(122, 40);
            this.btnSelectFolder.TabIndex = 1;
            this.btnSelectFolder.Text = "Select Folder";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // lstFileNames
            // 
            this.lstFileNames.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFileNames.FormattingEnabled = true;
            this.lstFileNames.ItemHeight = 16;
            this.lstFileNames.Location = new System.Drawing.Point(7, 88);
            this.lstFileNames.Name = "lstFileNames";
            this.lstFileNames.Size = new System.Drawing.Size(459, 132);
            this.lstFileNames.TabIndex = 3;
            // 
            // btnCleanFolder
            // 
            this.btnCleanFolder.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnCleanFolder.Enabled = false;
            this.btnCleanFolder.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCleanFolder.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnCleanFolder.Location = new System.Drawing.Point(265, 306);
            this.btnCleanFolder.Name = "btnCleanFolder";
            this.btnCleanFolder.Size = new System.Drawing.Size(159, 43);
            this.btnCleanFolder.TabIndex = 1;
            this.btnCleanFolder.Text = "Delete Unused Files";
            this.btnCleanFolder.UseVisualStyleBackColor = false;
            this.btnCleanFolder.Click += new System.EventHandler(this.btnCleanFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Step 1 :  Select the file";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.Black;
            this.lblCount.Location = new System.Drawing.Point(472, 143);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(57, 19);
            this.lblCount.TabIndex = 0;
            this.lblCount.Text = "Count:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelectFile);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.lstFileNames);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtFolder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFile);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblCount);
            this.groupBox1.Controls.Add(this.btnMarkMissingLines);
            this.groupBox1.Controls.Add(this.btnChangeFilenames);
            this.groupBox1.Controls.Add(this.btnCleanFolder);
            this.groupBox1.Controls.Add(this.btnSelectFolder);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(686, 374);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Check unused audio files and mark unrecorded lines";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(430, 318);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "OR";
            // 
            // btnMarkMissingLines
            // 
            this.btnMarkMissingLines.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnMarkMissingLines.Enabled = false;
            this.btnMarkMissingLines.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarkMissingLines.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnMarkMissingLines.Location = new System.Drawing.Point(10, 306);
            this.btnMarkMissingLines.Name = "btnMarkMissingLines";
            this.btnMarkMissingLines.Size = new System.Drawing.Size(159, 43);
            this.btnMarkMissingLines.TabIndex = 1;
            this.btnMarkMissingLines.Text = "Mark Missing Lines";
            this.btnMarkMissingLines.UseVisualStyleBackColor = false;
            this.btnMarkMissingLines.Click += new System.EventHandler(this.btnMarkMissingLines_Click);
            // 
            // btnChangeFilenames
            // 
            this.btnChangeFilenames.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnChangeFilenames.Enabled = false;
            this.btnChangeFilenames.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeFilenames.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnChangeFilenames.Location = new System.Drawing.Point(468, 306);
            this.btnChangeFilenames.Name = "btnChangeFilenames";
            this.btnChangeFilenames.Size = new System.Drawing.Size(148, 43);
            this.btnChangeFilenames.TabIndex = 1;
            this.btnChangeFilenames.Text = "Change Filenames";
            this.btnChangeFilenames.UseVisualStyleBackColor = false;
            this.btnChangeFilenames.Click += new System.EventHandler(this.btnChangeFilenames_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(705, 394);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bulk Deleter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.ListBox lstFileNames;
        private System.Windows.Forms.Button btnCleanFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMarkMissingLines;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnChangeFilenames;
    }
}


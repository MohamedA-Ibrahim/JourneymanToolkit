
namespace JourneymanToolkit
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
            this.btnBulkDeleter = new System.Windows.Forms.Button();
            this.btnLabelsRename = new System.Windows.Forms.Button();
            this.btnRetakesFormatter = new System.Windows.Forms.Button();
            this.btnExtractPerfectLines = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBulkDeleter
            // 
            this.btnBulkDeleter.BackColor = System.Drawing.Color.DarkCyan;
            this.btnBulkDeleter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnBulkDeleter.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnBulkDeleter.Location = new System.Drawing.Point(27, 56);
            this.btnBulkDeleter.Name = "btnBulkDeleter";
            this.btnBulkDeleter.Size = new System.Drawing.Size(248, 105);
            this.btnBulkDeleter.TabIndex = 0;
            this.btnBulkDeleter.Text = "Bulk Delete";
            this.btnBulkDeleter.UseVisualStyleBackColor = false;
            this.btnBulkDeleter.Click += new System.EventHandler(this.btnBulkDeleter_Click);
            // 
            // btnLabelsRename
            // 
            this.btnLabelsRename.BackColor = System.Drawing.Color.DarkCyan;
            this.btnLabelsRename.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnLabelsRename.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnLabelsRename.Location = new System.Drawing.Point(311, 56);
            this.btnLabelsRename.Name = "btnLabelsRename";
            this.btnLabelsRename.Size = new System.Drawing.Size(265, 105);
            this.btnLabelsRename.TabIndex = 0;
            this.btnLabelsRename.Text = "Labels Rename";
            this.btnLabelsRename.UseVisualStyleBackColor = false;
            this.btnLabelsRename.Click += new System.EventHandler(this.btnLabelsRename_Click);
            // 
            // btnRetakesFormatter
            // 
            this.btnRetakesFormatter.BackColor = System.Drawing.Color.DarkCyan;
            this.btnRetakesFormatter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnRetakesFormatter.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnRetakesFormatter.Location = new System.Drawing.Point(601, 56);
            this.btnRetakesFormatter.Name = "btnRetakesFormatter";
            this.btnRetakesFormatter.Size = new System.Drawing.Size(249, 105);
            this.btnRetakesFormatter.TabIndex = 0;
            this.btnRetakesFormatter.Text = "Retakes Formatter";
            this.btnRetakesFormatter.UseVisualStyleBackColor = false;
            this.btnRetakesFormatter.Click += new System.EventHandler(this.btnRetakesFormatter_Click);
            // 
            // btnExtractPerfectLines
            // 
            this.btnExtractPerfectLines.BackColor = System.Drawing.Color.DarkCyan;
            this.btnExtractPerfectLines.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnExtractPerfectLines.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnExtractPerfectLines.Location = new System.Drawing.Point(311, 239);
            this.btnExtractPerfectLines.Name = "btnExtractPerfectLines";
            this.btnExtractPerfectLines.Size = new System.Drawing.Size(265, 105);
            this.btnExtractPerfectLines.TabIndex = 0;
            this.btnExtractPerfectLines.Text = "Extract Perfect Lines";
            this.btnExtractPerfectLines.UseVisualStyleBackColor = false;
            this.btnExtractPerfectLines.Click += new System.EventHandler(this.btnExtractPerfectLines_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 428);
            this.Controls.Add(this.btnRetakesFormatter);
            this.Controls.Add(this.btnExtractPerfectLines);
            this.Controls.Add(this.btnLabelsRename);
            this.Controls.Add(this.btnBulkDeleter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Journeyman Toolkit";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBulkDeleter;
        private System.Windows.Forms.Button btnLabelsRename;
        private System.Windows.Forms.Button btnRetakesFormatter;
        private System.Windows.Forms.Button btnExtractPerfectLines;
    }
}


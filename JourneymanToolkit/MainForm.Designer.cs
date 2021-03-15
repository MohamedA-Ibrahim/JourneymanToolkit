
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnOldLinesManagement = new System.Windows.Forms.Button();
            this.btnLabelsRename = new System.Windows.Forms.Button();
            this.btnRetakesFormatter = new System.Windows.Forms.Button();
            this.btnSecondCheckAutomation = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOldLinesManagement
            // 
            this.btnOldLinesManagement.BackColor = System.Drawing.SystemColors.Control;
            this.btnOldLinesManagement.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnOldLinesManagement.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOldLinesManagement.Location = new System.Drawing.Point(249, 40);
            this.btnOldLinesManagement.Name = "btnOldLinesManagement";
            this.btnOldLinesManagement.Size = new System.Drawing.Size(237, 58);
            this.btnOldLinesManagement.TabIndex = 1;
            this.btnOldLinesManagement.Text = "Old Lines Management";
            this.MyToolTip.SetToolTip(this.btnOldLinesManagement, "Remove unused audio files in a folder and mark missing lines in the excel sheet");
            this.btnOldLinesManagement.UseVisualStyleBackColor = false;
            this.btnOldLinesManagement.Click += new System.EventHandler(this.btnOldLinesManagement_Click);
            // 
            // btnLabelsRename
            // 
            this.btnLabelsRename.BackColor = System.Drawing.SystemColors.Control;
            this.btnLabelsRename.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnLabelsRename.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLabelsRename.Location = new System.Drawing.Point(6, 40);
            this.btnLabelsRename.Name = "btnLabelsRename";
            this.btnLabelsRename.Size = new System.Drawing.Size(237, 58);
            this.btnLabelsRename.TabIndex = 0;
            this.btnLabelsRename.Text = "Labels Rename";
            this.MyToolTip.SetToolTip(this.btnLabelsRename, "Rename some labels in the labeltrack  for consistency and trim spaces at the end " +
        "of each label");
            this.btnLabelsRename.UseVisualStyleBackColor = false;
            this.btnLabelsRename.Click += new System.EventHandler(this.btnLabelsRename_Click);
            // 
            // btnRetakesFormatter
            // 
            this.btnRetakesFormatter.BackColor = System.Drawing.SystemColors.Control;
            this.btnRetakesFormatter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnRetakesFormatter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRetakesFormatter.Location = new System.Drawing.Point(249, 40);
            this.btnRetakesFormatter.Name = "btnRetakesFormatter";
            this.btnRetakesFormatter.Size = new System.Drawing.Size(237, 58);
            this.btnRetakesFormatter.TabIndex = 1;
            this.btnRetakesFormatter.Text = "Retakes Formatter";
            this.MyToolTip.SetToolTip(this.btnRetakesFormatter, "Format the base sheet of the excel file and create a new reformatted sheet for VA" +
        "s");
            this.btnRetakesFormatter.UseVisualStyleBackColor = false;
            this.btnRetakesFormatter.Click += new System.EventHandler(this.btnRetakesFormatter_Click);
            // 
            // btnSecondCheckAutomation
            // 
            this.btnSecondCheckAutomation.BackColor = System.Drawing.SystemColors.Control;
            this.btnSecondCheckAutomation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnSecondCheckAutomation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSecondCheckAutomation.Location = new System.Drawing.Point(6, 40);
            this.btnSecondCheckAutomation.Name = "btnSecondCheckAutomation";
            this.btnSecondCheckAutomation.Size = new System.Drawing.Size(237, 58);
            this.btnSecondCheckAutomation.TabIndex = 0;
            this.btnSecondCheckAutomation.Text = "Second Check Automation";
            this.MyToolTip.SetToolTip(this.btnSecondCheckAutomation, "After finishing the second check, you had to copy Perfect and Bad lines into new " +
        "sheets to separate them.\r\nInstead of doing this process manually, you can now us" +
        "e this tool to do it for you.");
            this.btnSecondCheckAutomation.UseVisualStyleBackColor = false;
            this.btnSecondCheckAutomation.Click += new System.EventHandler(this.btnSecondCheckAutomation_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSecondCheckAutomation);
            this.groupBox1.Controls.Add(this.btnRetakesFormatter);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkCyan;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tools for the Journeyman";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLabelsRename);
            this.groupBox2.Controls.Add(this.btnOldLinesManagement);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.DarkCyan;
            this.groupBox2.Location = new System.Drawing.Point(12, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(514, 121);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tools for managing the old submissions";
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnSecondCheckAutomation;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 319);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Journeyman Toolkit";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOldLinesManagement;
        private System.Windows.Forms.Button btnLabelsRename;
        private System.Windows.Forms.Button btnRetakesFormatter;
        private System.Windows.Forms.Button btnSecondCheckAutomation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolTip MyToolTip;
    }
}


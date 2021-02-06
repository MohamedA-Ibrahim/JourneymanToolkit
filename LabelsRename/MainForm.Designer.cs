
namespace LabelsRename
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnSelectTxtFile = new System.Windows.Forms.Button();
            this.lstLabelTracks = new System.Windows.Forms.ListBox();
            this.lblTracksCount = new System.Windows.Forms.Label();
            this.btnClearList = new System.Windows.Forms.Button();
            this.btnRemoveSelected = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRemoveSelected);
            this.groupBox2.Controls.Add(this.btnClearList);
            this.groupBox2.Controls.Add(this.btnRename);
            this.groupBox2.Controls.Add(this.btnSelectTxtFile);
            this.groupBox2.Controls.Add(this.lstLabelTracks);
            this.groupBox2.Controls.Add(this.lblTracksCount);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(686, 356);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rename labels in label tracks";
            // 
            // btnRename
            // 
            this.btnRename.BackColor = System.Drawing.Color.Crimson;
            this.btnRename.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRename.ForeColor = System.Drawing.Color.White;
            this.btnRename.Location = new System.Drawing.Point(477, 133);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(192, 40);
            this.btnRename.TabIndex = 1;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = false;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnSelectTxtFile
            // 
            this.btnSelectTxtFile.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectTxtFile.ForeColor = System.Drawing.Color.Black;
            this.btnSelectTxtFile.Location = new System.Drawing.Point(477, 34);
            this.btnSelectTxtFile.Name = "btnSelectTxtFile";
            this.btnSelectTxtFile.Size = new System.Drawing.Size(192, 40);
            this.btnSelectTxtFile.TabIndex = 1;
            this.btnSelectTxtFile.Text = "Select Files";
            this.btnSelectTxtFile.UseVisualStyleBackColor = true;
            this.btnSelectTxtFile.Click += new System.EventHandler(this.btnSelectTxtFile_Click);
            // 
            // lstLabelTracks
            // 
            this.lstLabelTracks.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLabelTracks.FormattingEnabled = true;
            this.lstLabelTracks.ItemHeight = 16;
            this.lstLabelTracks.Location = new System.Drawing.Point(12, 34);
            this.lstLabelTracks.Name = "lstLabelTracks";
            this.lstLabelTracks.Size = new System.Drawing.Size(459, 308);
            this.lstLabelTracks.TabIndex = 3;
            // 
            // lblTracksCount
            // 
            this.lblTracksCount.AutoSize = true;
            this.lblTracksCount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTracksCount.ForeColor = System.Drawing.Color.Black;
            this.lblTracksCount.Location = new System.Drawing.Point(477, 102);
            this.lblTracksCount.Name = "lblTracksCount";
            this.lblTracksCount.Size = new System.Drawing.Size(57, 19);
            this.lblTracksCount.TabIndex = 0;
            this.lblTracksCount.Text = "Count:";
            // 
            // btnClearList
            // 
            this.btnClearList.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearList.ForeColor = System.Drawing.Color.Black;
            this.btnClearList.Location = new System.Drawing.Point(481, 293);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(192, 40);
            this.btnClearList.TabIndex = 1;
            this.btnClearList.Text = "Remove All";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // btnRemoveSelected
            // 
            this.btnRemoveSelected.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveSelected.ForeColor = System.Drawing.Color.Black;
            this.btnRemoveSelected.Location = new System.Drawing.Point(481, 237);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(192, 40);
            this.btnRemoveSelected.TabIndex = 1;
            this.btnRemoveSelected.Text = "Remove Selected File";
            this.btnRemoveSelected.UseVisualStyleBackColor = true;
            this.btnRemoveSelected.Click += new System.EventHandler(this.btnRemoveSelected_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 379);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Labels Rename";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnSelectTxtFile;
        private System.Windows.Forms.ListBox lstLabelTracks;
        private System.Windows.Forms.Label lblTracksCount;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.Button btnRemoveSelected;
    }
}


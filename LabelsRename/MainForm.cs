using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LabelsRename
{
    public partial class MainForm : Form
    {
        Dictionary<string, string> replacements;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            lstLabelTracks.Items.Clear();
        }

        private void rtRenameRules_TextChanged(object sender, EventArgs e)
        {
            var lineCount = rtRenames.Lines.Count();
            lblLineCount.Text = lineCount.ToString();
        }


        private void btnSelectTxtFile_Click(object sender, EventArgs e)
        {
            try
            {
                // OpenFileDialog Configurations
                OpenFileDialog ofdFile = new OpenFileDialog();
                ofdFile.Multiselect = true;
                ofdFile.Title = "Browse txt Files";
                ofdFile.DefaultExt = "txt";
                ofdFile.Filter = "txt files (*.txt)|*.txt";
                ofdFile.CheckFileExists = true;
                ofdFile.CheckPathExists = true;

                //If the user selects a file proceed
                if (ofdFile.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in ofdFile.FileNames)
                    {
                        if (!lstLabelTracks.Items.Contains(file))
                        {
                            lstLabelTracks.Items.Add(file);
                            lblTracksCount.Text = "Count: " + lstLabelTracks.Items.Count.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btnRename_Click(object sender, EventArgs e)
        {

            if (lstLabelTracks.Items.Count == 0)
                return;

            ReadReplacementRules();

            foreach (string file in lstLabelTracks.Items)
            {
                RenameLabels(file);

                if(ckRemoveDuplicates.Checked)
                    RemoveDuplicates(file);
            }

            MessageBox.Show($"Renamed {lstLabelTracks.Items.Count} File(s) Successfully");
        }


        /// <summary>
        /// Read the textbox and add their values to the dictionary
        /// </summary>
        private void ReadReplacementRules()
        {
            try
            {
                replacements = new Dictionary<string, string>();
                foreach (string str in rtRenames.Lines)
                {
                    replacements.Add(str.Split('|')[0], str.Split('|')[1]);
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Make sure you wrote your replacements correctly", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void RenameLabels(string fileLocation)
        {
            try
            {
                var oldText = File.ReadAllText(fileLocation);
                var newText = replacements.Aggregate(oldText, (current, replacement) => current.Replace(replacement.Key, replacement.Value));
                //Equivalent to
                //foreach (string toReplace in replacements.Keys)
                //{
                //    oldText = s.Replace(toReplace, Replacements[toReplace]);
                //}
                //return s;

                File.WriteAllText(fileLocation, newText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveDuplicates(string fileLocation)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileLocation);
                File.WriteAllLines(fileLocation, lines.Distinct().ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
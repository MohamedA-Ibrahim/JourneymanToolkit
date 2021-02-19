using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LabelsRename
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
                    foreach (String file in ofdFile.FileNames)
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
                MessageBox.Show(ex.Message);
            }

        }

        private void RenameLabels(string fileLocation)
        {
            var oldLines = File.ReadLines(fileLocation);

            var newLines = oldLines.Select(s => 
            s.Replace("MorroDefau_MDQGreeting_", "MorroDefau_MDQGreetingTopi_")
            .Replace("MorroDefau_MDQGreetings_", "MorroDefau_MDQGreetingsTop_")
            .Replace("MorroDefaultQuest_MDQIdle_", "MorroDefau_MDQIdleLinesTop_")
            .Replace("MorroDefaultQuest_MDQTopic_", "MorroDefau_MDQMolagMarTopi_")
            .Replace("MorroDefau_MDQTopic_", "MorroDefau_MDQMolagMarTopi_")
            .Replace("MorroDefau_MDQVivecTopicCi_", "MorroDefau_MDQVivecTopic_"))
                .ToList();

            File.WriteAllLines(fileLocation, newLines);
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            try
            {

                if (lstLabelTracks.Items.Count != 0)
                {
                    foreach (string file in lstLabelTracks.Items)
                    {
                        RenameLabels(file);
                    }
                    MessageBox.Show("Success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            lstLabelTracks.DataSource = null;
            lstLabelTracks.Items.Clear();
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            lstLabelTracks.Items.Remove(lstLabelTracks.SelectedItem);
        }
    }
}

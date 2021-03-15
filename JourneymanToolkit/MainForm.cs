using System;
using System.Windows.Forms;

namespace JourneymanToolkit
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLabelsRename_Click(object sender, EventArgs e)
        {
            LabelsRename.MainForm frm = new LabelsRename.MainForm();
            frm.Show();
        }

        private void btnRetakesFormatter_Click(object sender, EventArgs e)
        {
            RetakesFormatter.MainForm frm = new RetakesFormatter.MainForm();
            frm.Show();
        }

        private void btnSecondCheckAutomation_Click(object sender, EventArgs e)
        {
            SecondCheckAutomation.MainForm frm = new SecondCheckAutomation.MainForm();
            frm.Show();
        }

        private void btnOldLinesManagement_Click(object sender, EventArgs e)
        {
            OldLinesManagement.MainForm frm = new OldLinesManagement.MainForm();
            frm.Show();
        }
    }
}

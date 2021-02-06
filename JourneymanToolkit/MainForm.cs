using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BulkDeleter;

namespace JourneymanToolkit
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBulkDeleter_Click(object sender, EventArgs e)
        {
            BulkDeleter.MainForm frm = new BulkDeleter.MainForm();
            frm.Show();
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
    }
}

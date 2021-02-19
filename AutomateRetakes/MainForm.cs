using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutomateRetakes
{
    public partial class MainForm : Form
    {
        string fileLocation;
        public MainForm()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            // OpenFileDialog Configurations
            OpenFileDialog ofdFile = new OpenFileDialog();
            ofdFile.Title = "Browse Excel or txt Files";
            ofdFile.DefaultExt = "Excel";
            ofdFile.Filter = "Excel files (*.xlsx)|*.xlsx| txt files (*.txt)|*.txt";
            ofdFile.FilterIndex = 1;
            ofdFile.CheckFileExists = true;
            ofdFile.CheckPathExists = true;

            //If the user selects a file proceed
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                //Set the filLocation variable to the file chosen from the dialog
                fileLocation = ofdFile.FileName;

                //paste the filename into the text file
                txtFile.Text = fileLocation;

            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            ReadExcelFile(fileLocation);
        }


        private void ReadExcelFile(string file)
        {
            try
            {
                //Select the excel file
                FileInfo existingFile = new FileInfo(file);

                //Using Epplus nuget package
                using (ExcelPackage package = new ExcelPackage(existingFile))
                {
                    //Get the first worksheet in the workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets["WorkTable"];
                    ExcelWorksheet PerfectSheet = package.Workbook.Worksheets.Copy("WorkTable", "Perfect");
                    ExcelWorksheet RetakesSheet = package.Workbook.Worksheets.Copy("WorkTable", "Retakes");

                    int rowEnd = worksheet.Dimension.End.Row;


                    var NonPerfectRows = from cell in PerfectSheet.Cells["G4:G" + rowEnd] 
                                         where !cell.Value?.ToString().ToLower().Contains("Perfect".ToLower()) == true
                                         select cell.Start.Row;

                    var PerfectRows = from cell in RetakesSheet.Cells["G4:G" + rowEnd] 
                                         where cell.Value?.ToString().ToLower().Contains("Perfect".ToLower()) == true
                                         select cell.Start.Row;

                    foreach (var row in NonPerfectRows)
                    {
                        PerfectSheet.Cells["A" + row + ":G" + row].Clear();
                    }

                    foreach (var row in PerfectRows)
                    {
                        RetakesSheet.Cells["A" + row + ":G" + row].Clear();
                    }

                    TrimEmptyRows(PerfectSheet);
                    TrimEmptyRows(RetakesSheet);

                    PerfectSheet.DeleteRow(1, 3);
                    RetakesSheet.DeleteRow(1, 3);


                    package.Save();

                    MessageBox.Show("Success");

            }
        }
            catch (Exception)
            {
                MessageBox.Show("An error occured while formatting the file, Check that the excel file doesn't have any weird lines (empty or formula lines).");
            }
}


        private void TrimEmptyRows(ExcelWorksheet worksheet)
        {
            //loop all rows in a file
            for (int i = worksheet.Dimension.End.Row; i >= worksheet.Dimension.Start.Row; i--)
            {
                bool isRowEmpty = true;

                //loop all columns in a row
                for (int j = worksheet.Dimension.Start.Column; j <= worksheet.Dimension.End.Column; j++)
                {
                    if (worksheet.Cells[i, j].Value != null)
                    {
                        isRowEmpty = false;
                        break;
                    }
                }
                if (isRowEmpty)
                {
                    worksheet.DeleteRow(i);
                }
            }
        }


    }

    }


using OfficeOpenXml;
using RetakesFormatter.Classes.Data;
using RetakesFormatter.Classes.Formatting;
using RetakesFormatter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace RetakesFormatter
{
    public partial class MainForm : Form
    {

        #region Variables Declerations

        string fileLocation = "";

        List<Lines> GroupedLines = new List<Lines>();

        BaseSheetFormatting baseSheetFormatting = new BaseSheetFormatting();
        SegmentsGrouping segmentsGrouping = new SegmentsGrouping();
        ReformmatedSheetFormatting reformmatedSheetFormatting = new ReformmatedSheetFormatting();

        BackgroundWorker worker;

        #endregion

        #region Constructor

        public MainForm()
        {

            InitializeComponent();

            //Set the licensing to NonCommercial
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }


        #endregion

        #region Form Events

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            SelectExcelFile();
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            //The method for marking missing lines in the Excel file

            worker = new BackgroundWorker();

            //Using Background worker to prevent freezing the app while doing the formatting
            worker.DoWork += delegate (object s, DoWorkEventArgs args)
            {
                FormatFile(fileLocation);
            };

            worker.RunWorkerCompleted += delegate (object s, RunWorkerCompletedEventArgs args)
            {
                if (args.Error != null)
                {
                    MessageBox.Show(args.Error.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Formatting has been successfully completed!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            };

            worker.RunWorkerAsync();

        }

        #endregion

        #region Methods
       
        private void SelectExcelFile()
        {
            try
            {
                // OpenFileDialog Configurations
                OpenFileDialog ofdFile = new OpenFileDialog();
                ofdFile.Title = "Browse Excel File";
                ofdFile.DefaultExt = "Excel";
                ofdFile.Filter = "Excel files (*.xlsx)|*.xlsx";
                ofdFile.FilterIndex = 1;
                ofdFile.CheckFileExists = true;
                ofdFile.CheckPathExists = true;
                ofdFile.InitialDirectory = Settings.Default.folder;

                //If the user selects a file proceed
                if (ofdFile.ShowDialog() == DialogResult.OK)
                {
                    //get the path of the selected file
                    string directoryPath = Path.GetDirectoryName(ofdFile.FileName);

                    //make the selected path intial path for next launches
                    Settings.Default.folder = directoryPath;
                    Settings.Default.Save();

                    //Set the filLocation variable to the file chosen from the dialog
                    fileLocation = ofdFile.FileName;

                    //paste the filename into the text file
                    txtFile.Text = fileLocation;

                    GroupedLines.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FormatFile(string file)
        {
            //Copy the contents of the sheet into a new file 
            CreateCleanScript(file);

            //Select the excel file
            FileInfo ExcelFile = new FileInfo(file);

            //Use the new file with the copied values
            using (var package = new ExcelPackage(ExcelFile))
            {
                ExcelWorksheet BaseSheet = package.Workbook.Worksheets[0];
                ExcelWorksheet ReformattedSheet = package.Workbook.Worksheets.Add("Reformatted Sheet");

                //Format the base sheet
                baseSheetFormatting.FormatBaseSheet(BaseSheet);

                //Get the grouped segments
                GroupedLines = segmentsGrouping.GroupSegments(BaseSheet);

                //Format the Reformatted Sheet
                reformmatedSheetFormatting.FormatHeader(BaseSheet, ReformattedSheet);

                //Insert the lines at the Reformatted sheet with grouping
                reformmatedSheetFormatting.InsertLinesAtReformattedSheet(ReformattedSheet, GroupedLines);

                //Format the inserted Lines
                reformmatedSheetFormatting.FormatInsertedLines(ReformattedSheet);

                //Save the excel file with the same name as the old file
                package.Save();
            }
        }

        /// <summary>
        /// Gets the values from the original sheet and copy them into a new excel file with fresh formatting
        /// </summary>
        /// <param name="file"></param>
        private void CreateCleanScript(string file)
        {
            FileInfo OriginalFile = new FileInfo(file);

            //Load the original Excel file
            using (var src = new ExcelPackage(OriginalFile))
            //Create new file
            using (var dest = new ExcelPackage())
            {
                //Get the Base Sheet of the original excel file
                var wsSrc = src.Workbook.Worksheets[0];

                //Add a sheet with the same name in the new excel file
                var wsDest = dest.Workbook.Worksheets[wsSrc.Name] ?? dest.Workbook.Worksheets.Add(wsSrc.Name);

                //Loop through the rows and the columns 
                for (var r = 1; r <= wsSrc.Dimension.Rows; r++)
                {
                    for (var c = 1; c <= wsSrc.Dimension.Columns; c++)
                    {
                        //get teh current cell value using the row and column of the original file
                        var cellSrc = wsSrc.Cells[r, c];

                        //get teh current cell value using the row and column of the new file
                        var cellDest = wsDest.Cells[r, c];

                        // Copy the cell value from the original file to the new file without formatting
                        cellDest.Value = cellSrc.Value;
                    }
                }

                dest.SaveAs(OriginalFile);
            }
        }

        #endregion

    }
}

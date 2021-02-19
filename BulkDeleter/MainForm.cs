using BulkDeleter.Properties;
using Microsoft.WindowsAPICodePack.Dialogs;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BulkDeleter
{
    public partial class MainForm : Form
    {
        string fileLocation = "";
        bool isExcel = false;

        #region Constructor

        public MainForm()
        {
            //Call the method to embed dll files into the executable to make a single file
            //AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

            InitializeComponent();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

        }

        #endregion

        #region Form Events

        /// <summary>
        /// Delete the unuesed files from the selected folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        /// <summary>
        /// Select the folder where the files are located 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            //using Microsoft.WindowsAPICodePack-Shell Api that allows choosing folders instead of files
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = Settings.Default.folder;
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtFolder.Text = dialog.FileName;

                //get the path of the selected file
                string directoryPath = Path.GetDirectoryName(dialog.FileName);

                //make the selected path intial path for next launches
                Settings.Default.folder = directoryPath;
                Settings.Default.Save();

                if(isExcel)
                {
                    btnMarkMissingLines.Enabled = true;
                }

                btnCleanFolder.Enabled = true;
                btnChangeFilenames.Enabled = true;
            }
        }

        /// <summary>
        /// Select the Excel file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            PopulateFromTxtOrExcel();
        }

        private void btnCleanFolder_Click(object sender, EventArgs e)
        {
            //get the list of files to exclude from deletion
            List<string> filesInExcelFile = lstFileNames.Items.Cast<string>().ToList();

            lblStatus.Text = "Status: Deleting files ... ";

            DeleteFilesFromFolder(txtFolder.Text, filesInExcelFile);

            lblStatus.Text = "Status: Deleting Complete!";

            btnCleanFolder.Enabled = false;
            btnChangeFilenames.Enabled = false;
        }

        private void btnChangeFilenames_Click(object sender, EventArgs e)
        {
            List<string> filesInExcelFile = lstFileNames.Items.Cast<string>().ToList();

            lblStatus.Text = "Status: Changing filenames ... ";

            RenameFiles(txtFolder.Text, filesInExcelFile);

            lblStatus.Text = "Status: Renaming Complete!";

            btnCleanFolder.Enabled = false;
            btnChangeFilenames.Enabled = false;
        }

        private void btnMarkMissingLines_Click(object sender, EventArgs e)
        {

            //get the list of files to exclude from deletion
            List<string> filesInExcelFile = lstFileNames.Items.Cast<string>().ToList();

            lblStatus.Text = "Status: Marking missing file names . . . ";

            //The method for finding missing lines from the folder
            List<string> filesNotInExcelFile = FindMissingLines(txtFolder.Text, filesInExcelFile);

            //The method for marking missing lines in the Excel file
            MarkMissingLines(fileLocation, filesNotInExcelFile);

            lblStatus.Text = "Marking Complete !";

            btnMarkMissingLines.Enabled = false;
        }



        #endregion

        #region Methods

        ///// <summary>
        ///// The method used to embed dll files into the executable 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="args"></param>
        ///// <returns></returns>
        //System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        //{
        //    string dllName = args.Name.Contains(',') ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");

        //    dllName = dllName.Replace(".", "_").Replace("-", "_");

        //    if (dllName.EndsWith("_resources")) return null;

        //    System.Resources.ResourceManager rm = new System.Resources.ResourceManager(GetType().Namespace + ".Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());

        //    byte[] bytes = (byte[])rm.GetObject(dllName);

        //    return System.Reflection.Assembly.Load(bytes);
        //}

        private void PopulateFromTxtOrExcel()
        {
            try
            {
                // OpenFileDialog Configurations
                OpenFileDialog ofdFile = new OpenFileDialog();
                ofdFile.Title = "Browse Excel or txt Files";
                ofdFile.DefaultExt = "Excel";
                ofdFile.Filter = "Excel files (*.xlsx)|*.xlsx| txt files (*.txt)|*.txt";
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

                    //Change status text
                    lblStatus.Text = "Status: grabbing files ...";

                    //paste the filename into the text file
                    txtFile.Text = fileLocation;

                    // Clear the list box of any previous items on it
                    lstFileNames.DataSource = null;
                    lstFileNames.Items.Clear();

                    //Populate either from txt file or from excel file depending on the user choice
                    if (".txt".Equals(Path.GetExtension(fileLocation), StringComparison.OrdinalIgnoreCase))
                    {
                        PopulateListFromTxtFile(fileLocation);
                        isExcel = false;
                    }
                    else if (".xlsx".Equals(Path.GetExtension(fileLocation), StringComparison.OrdinalIgnoreCase))
                    {
                        PopulateListFromExcelFile(fileLocation);
                        isExcel = true;
                    }

                    lblStatus.Text = "Status: grabbing files completed";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error : " + ex.Message;
            }

        }
        /// <summary>
        /// The method to open a dialog for choosing a txt file
        /// Todo: to be replaced with Excel file instead
        /// </summary>
        private void PopulateListFromTxtFile(string file)
        {
            try
            {
                using (StreamReader r = new StreamReader(file))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        lstFileNames.Items.Add(line);
                        lblCount.Text = "Count: " + lstFileNames.Items.Count.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error : " + ex.Message;
            }

        }

        /// <summary>
        /// The method to import data from excel file
        /// </summary>
        /// <param name="fileName"></param>
        private void PopulateListFromExcelFile(string file)
        {
            try
            {
                //Select the excel file
                FileInfo existingFile = new FileInfo(file);

                //Using Epplus nuget package
                using (ExcelPackage package = new ExcelPackage(existingFile))
                {
                    //Get the first worksheet in the workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

                    //Grab the data starting from Row 4 (the begining of the actual data in the excel file)
                    //to the end of the worksheet.
                    for (var rowNum = 4; rowNum <= worksheet.Dimension.End.Row; rowNum++)
                    {
                        //Add the row to the lstfilenames box
                        lstFileNames.Items.Add(worksheet.Cells[rowNum, 1].Value);
                        lblCount.Text = "Count: " + lstFileNames.Items.Count.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error : " + ex.Message;
            }
        }

        public void MarkMissingLines(string filename, List<string> filenameNotInFolders)
        {
            try
            {
                FileInfo existingFile = new FileInfo(filename);

                using (ExcelPackage package = new ExcelPackage(existingFile))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

                    //Get the list of the files in the folder
                    List<string> lstFiles = lstFileNames.Items.Cast<string>().ToList();

                    //loop through the lisf of files from the folder
                    for (var i = 0; i < lstFiles.Count; i++)
                    {
                        //Set the current row to the index of the lis + 4 (because we took data from line 4)
                        int rowInExcelFile = i + 4;

                        //loop through the lines in excel file not found in folder
                        foreach (var file in filenameNotInFolders)
                        {
                            //Compare the current row in the excel file with the corresponding filename from the list of Missing Lines (filenameNotInFolders)
                            if (lstFiles[i].Equals(file))
                            {
                                //Change the color of the range A(rowInExcelFile):G(rowInExcelFile) to Red where rowInExcelFile is the current row number in the Excel file
                                worksheet.Cells["A" + rowInExcelFile + ":" + "G" + rowInExcelFile].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Red);

                                //Change the value of the Filecutter Notes (G) to "Missing"
                                worksheet.Cells["G" + rowInExcelFile].Value = "Missing";
                            }
                        }
                    }

                    //Save the excel file
                    package.Save();

                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error : " + ex.Message;
            }

        }

        /// <summary>
        /// Method to compare the file names in the filesToDeleteFromFolder list and the files in the folder
        /// and delete the unused ones from the folder.
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="filesToDeleteFromFolder"></param>
        public void DeleteFilesFromFolder(string folder, List<string> filesInExcelFile)
        {
            try
            {
                //LINQ function to get the list of files in the folder that don't exist in the excel file
                var filesNotInExcelFile = System.IO.Directory.GetFiles(folder).Where(file => !filesInExcelFile.Contains(System.IO.Path.GetFileNameWithoutExtension(file)));

                //Begin the deletion process
                foreach (var file in filesNotInExcelFile)
                {
                    System.IO.File.Delete(file);
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error : " + ex.Message;
            }
        }

        /// <summary>
        /// For wav files that aren't used in the script, Append "_" at the start of the filename instead of deleting it.
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="filesInExcelFile"></param>
        public void RenameFiles(string folder, List<string> filesInExcelFile)
        {
            //try
            //{
                //LINQ function to get the list of files in the folder that don't exist in the excel file
                var filesNotInExcelFile = System.IO.Directory.GetFiles(folder).Where(file => !filesInExcelFile.Contains(System.IO.Path.GetFileNameWithoutExtension(file)));
            
                //Begin the deletion process
                foreach (var file in filesNotInExcelFile)
                {
                string filename = Path.GetFileName(file);

                    System.IO.File.Move(file, $"{Path.GetDirectoryName(file)}\\_{filename}");
                }
            //}
            //catch (Exception ex)
            //{
            //    lblStatus.Text = "Error : " + ex.Message;
            //}
        }

        public List<string> FindMissingLines(string directory, List<string> filesInExcelFile)
        {
            try
            {

                var filesInFolder = System.IO.Directory.GetFiles(directory).Select(Path.GetFileNameWithoutExtension);

                var filenameNotInFolder = filesInExcelFile.Where(filename => !filesInFolder.Contains(filename));

                return filenameNotInFolder.ToList();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error : " + ex.Message;
                return null;
            }
        }

        #endregion

    }
}

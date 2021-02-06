using OfficeOpenXml;
using OfficeOpenXml.Style;
using RetakesFormatter.Classes;
using RetakesFormatter.Classes.Data;
using RetakesFormatter.Classes.Formatting;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace RetakesFormatter
{
    public class ReformmatedSheetFormatting
    {
        public void FormatReformattedInformation(ExcelWorksheet BaseSheet, ExcelWorksheet ReformattedSheet)
        {

            ReformattedSheet.Cells["A1"].Value = "Name:";
            ReformattedSheet.Cells["B1"].Value = BaseSheet.Cells["B1"].Value;
            ReformattedSheet.Cells["B1"].Style.Font.Bold = true;

            ReformattedSheet.Cells["A2"].Value = "Sex:";
            ReformattedSheet.Cells["B2"].Value = BaseSheet.Cells["D1"].Value;
            ReformattedSheet.Cells["B2"].Style.Font.Bold = true;

            ReformattedSheet.Cells["A3"].Value = "Race:";

            //Get the value of the Race column like: ImperialRace "Imperial" [RACE:00013744] 
            string input = (BaseSheet.Cells["F1"].Value).ToString();

            //Get the value that is in the double quotes " " which is in this case : Imperial 
            string output = input.Split('"', '"')[1];

            ReformattedSheet.Cells["B3"].Value = output;
            ReformattedSheet.Cells["B3"].Style.Font.Bold = true;

            ReformattedSheet.Cells["A5"].Value = "Useful Links:";

            //Set the hyperlink
            ReformattedSheet.Cells["B6"].Hyperlink = new ExcelHyperLink("https://sites.google.com/view/tesrskywind/va/how-to-record") { Display = "How to Record" };
            ReformattedSheet.Cells["B7"].Hyperlink = new ExcelHyperLink("https://sites.google.com/view/tesrskywind/va/accent-guide") { Display = "Accent Guide" };
            ReformattedSheet.Cells["B8"].Hyperlink = new ExcelHyperLink("https://sites.google.com/view/tesrskywind/va/problems") { Display = "Pronunciations" };
            ReformattedSheet.Cells["B9"].Hyperlink = new ExcelHyperLink("https://trello.com/b/ehTXhmfX/voice-acting") { Display = "Trello" };
            ReformattedSheet.Cells["B10"].Hyperlink = new ExcelHyperLink("https://discord.gg/Wzs4QTd") { Display = "Discord --- Ask questions here!" };

            //Set the style of the cells to be Hyperlink (blue underlined text) 
            ReformattedSheet.Cells["B6:B10"].StyleName = "Hyper";

            ReformattedSheet.Cells["A12"].Value = "Script Format:";

            //Set the font size
            ReformattedSheet.Cells["A:B"].Style.Font.Size = 14;

            ReformattedSheet.Cells["A:B"].Style.Numberformat.Format = "@";

            //Column A
            ReformattedSheet.Column(1).Width = 7;
            ReformattedSheet.Column(1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ReformattedSheet.Column(1).Style.Font.Bold = true;

            //Column B
            ReformattedSheet.Column(2).Width = 59;
            ReformattedSheet.Column(2).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ReformattedSheet.Column(2).Style.WrapText = true;

            //Insert Line Example and put the formatiing index
            //Format index 0: speaker; 1: prompt; 2: acting note; 3: line; 4: blank
            ReformattedSheet.Cells["A13"].Value = "   ";
            ReformattedSheet.Cells["B13"].Value = "Speaker";
            ReformattedSheet.Cells["C13"].Value = 0;

            ReformattedSheet.Cells["A14"].Value = "0. ";
            ReformattedSheet.Cells["B14"].Value = "Prompt (what the player says/asks about)";
            ReformattedSheet.Cells["C14"].Value = 1;


            ReformattedSheet.Cells["A15"].Value = " .1";
            ReformattedSheet.Cells["B15"].Value = "Emotion & Acting note for Line 1";
            ReformattedSheet.Cells["C15"].Value = 2;


            ReformattedSheet.Cells["A16"].Value = "   ";
            ReformattedSheet.Cells["B16"].Value = "Line 1 (what you read)";
            ReformattedSheet.Cells["C16"].Value = 3;

            ReformattedSheet.Cells["A17"].Value = " .2";
            ReformattedSheet.Cells["B17"].Value = "Emotion & Acting note for Line 2 (if applicable)";
            ReformattedSheet.Cells["C17"].Value = 2;

            ReformattedSheet.Cells["A18"].Value = "   ";
            ReformattedSheet.Cells["B18"].Value = "Line 2 (if applicable; remember to leave >0.5sec of silence between lines)";
            ReformattedSheet.Cells["C18"].Value = 3;

            ReformattedSheet.Cells["A19"].Value = " .3";
            ReformattedSheet.Cells["B19"].Value = "etc...";
            ReformattedSheet.Cells["C19"].Value = 2;

            ReformattedSheet.Cells["A20:B21"].Value = "   ";
            //Set it 5 or any number after 4 so it doesn't get formatted
            ReformattedSheet.Cells["C20:C21"].Value = 5;

        }

        public void InsertLinesAtReformattedSheet(ExcelWorksheet sheet, List<Lines> GroupedLines)
        {
            //create a datatable
            DataTable dataTable = new DataTable();

            int lineNumber = 1;

            //The third column is the format index
            //0: speaker; 1: prompt; 2: acting note; 3: line; 4: blank

            dataTable.Columns.Add("Column A", typeof(string));
            dataTable.Columns.Add("Column B", typeof(string));
            dataTable.Columns.Add("Format index", typeof(int));

            foreach (var line in GroupedLines)
            {
                dataTable.Rows.Add("", line.speaker, 0);

                dataTable.Rows.Add(lineNumber + ".", line.prompt, 1);

                List<string> Segments = line.segments;
                List<string> Emotions = line.emotions;
                List<string> ActingNotes = line.actingNotes;

                for (int i = 0; i < Segments.Count; i++)
                {
                    dataTable.Rows.Add(" ." + (i + 1).ToString(), Emotions[i] + ". " + ActingNotes[i], 2);
                    dataTable.Rows.Add("   ", Segments[i], 3);
                }


                lineNumber++;

                //To avoid inserting an empty line after the last line
                //first get the value of the last item
                var item = GroupedLines[GroupedLines.Count - 1];

                //Compare the current line with the last line
                if (line != item)
                {
                    dataTable.Rows.Add("   ", "   ", 4);
                }
            }

            //add all the content from the DataTable, starting at cell A1
            //false is for printing column headers
            sheet.Cells["A22"].LoadFromDataTable(dataTable, false);
        }

        public void FormatInsertedLines(ExcelWorksheet sheet)
        {
            //The last row
            var end = sheet.Dimension.End;

            sheet.Cells["A1:B" + end.Row].Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;

            //Set the formatting of each line depending of its format index and autofit them
            for (int row = 13; row <= end.Row; row++)
            {
                var formatIndex = sheet.Cells[row, 3].Value.ToString();

                if (formatIndex == "0")
                {
                    //for Speaker cells
                    sheet.Cells["A" + row + ":B" + row].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    sheet.Cells["A" + row + ":B" + row].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(223, 223, 223));
                    sheet.Cells["A" + row + ":B" + row].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                }
                else if (formatIndex == "1")
                {
                    //for Prompt cells
                    sheet.Cells["A" + row + ":B" + row].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    sheet.Cells["A" + row + ":B" + row].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(191, 191, 191));

                }
                else if (formatIndex == "2")
                {
                    //Insert a new line before the string "Retake Note:" and give it special formatting (make it bold)
                    FormatPartialText(sheet,row);
                  
                    //for Acting Note and emotion cells
                    sheet.Cells["A" + row + ":B" + row].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    sheet.Cells["A" + row + ":B" + row].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(223, 223, 223));
                    sheet.Cells["A" + row + ":B" + row].Style.Font.Italic = true;

                    //Align the number to the right
                    sheet.Cells["A" + row].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                }
                else if (formatIndex == "3")
                {
                    //for segment cells                    
                    sheet.Cells["A" + row + ":B" + row].Style.Font.Bold = true;

                }
                else if (formatIndex == "4")
                {
                    //empty lines
                    sheet.Cells["A" + row + ":B" + row].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                }
                if (row == end.Row)
                {
                    sheet.Cells["A" + row + ":B" + row].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }

                AutofitRows.DoAutoFit(sheet, row, true);

                sheet.Row(20).Height = 23;
                sheet.Row(21).Height = 23;

                //Set the column width to a bigger value to fix the issue of some rows needing more space
                sheet.Column(1).Width = 9;
                sheet.Column(2).Width = 61;

            }

            //Delete the format index column
            sheet.DeleteColumn(3);




        }

        /// <summary>
        /// Format the "Retake Note" string to be bold and in a new line
        /// Because Epplus doesn't support  partial styling for existing data and only supports formatting new lines
        /// I had to: 1. get the text before and after the string I want to format , 2. Insert each section (before text, the targetd text, after text) , 3. Format them manually
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="row"></param>
        private void FormatPartialText(ExcelWorksheet sheet, int row)
        {
            // The text to be formatted
            string toBeSearched = "Retake Note:";

            //Current cell address
            var cell = sheet.Cells[row, 2];
            var cellValue = cell.Value.ToString();

            //See if only the cell has the text to be formatted
            if (cellValue.Contains(toBeSearched))
            {
                //Get the text before the string we want to format
                string BeforeText = cellValue.Substring(0, cellValue.IndexOf(toBeSearched));

                //Get the text After the string we want to format
                string AfterText = cellValue.Substring(cellValue.IndexOf(toBeSearched) + toBeSearched.Length);

                // Set the cell property to be rich text to be able to do partial formatting
                cell.IsRichText = true;

                //Clear the currnnt cell content
                cell.RichText.Clear();

                //Insert the Before text and format it with its original formatting
                var firstSection = cell.RichText.Add(BeforeText);
                firstSection.Italic = true;

                //Insert the string we wanted and Format it
                var secondSection = cell.RichText.Add("\r\n" + toBeSearched);
                secondSection.Bold = true;
                secondSection.Italic = true;

                //Insert the After text
                var thirdSection = cell.RichText.Add(AfterText);

                //Any text after the second one will have its formatting which we want to avoid so set Bold to false
                thirdSection.Bold = false;

                //format it with its original formatting
                secondSection.Italic = true;

                //Set the border of the cell to its original formatting
                sheet.Cells[row, 2].Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;

            }
        }
    }
}

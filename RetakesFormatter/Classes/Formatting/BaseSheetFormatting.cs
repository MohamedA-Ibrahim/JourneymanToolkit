using OfficeOpenXml;
using OfficeOpenXml.Style;
using RetakesFormatter.Classes.Formatting;
using System.Drawing;
using System.Linq;

namespace RetakesFormatter
{
    public class BaseSheetFormatting
    {
        #region Main Method

        /// <summary>
        /// The Main method for formatting the base sheet and adding required information
        /// </summary>
        /// <param name="sheet">The Base Sheet</param>
        public void FormatBaseSheet(ExcelWorksheet sheet)
        {
            SearchForText(sheet);

            sheet.Column(1).Width = 12.71;
            sheet.Column(1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //Column B
            sheet.Column(2).Width = 21.71;
            sheet.Column(2).Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //Column C
            sheet.Column(3).Width = 27.71;
            sheet.Column(3).Style.WrapText = true;
            sheet.Column(3).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            //Column D
            sheet.Column(4).Width = 49.71;
            sheet.Column(4).Style.WrapText = true;
            sheet.Column(4).Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //Column E

            sheet.Column(5).Width = 24.71;
            sheet.Column(5).Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //Column F
            sheet.Column(6).Width = 34.71;
            sheet.Column(6).Style.WrapText = true;
            sheet.Column(6).Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //Column G
            sheet.Column(7).Width = 24.71;
            sheet.Column(7).Style.WrapText = true;
            sheet.Column(7).Style.VerticalAlignment = ExcelVerticalAlignment.Center;


            //The first row
            var start = sheet.Dimension.Start;

            //The last row
            var end = sheet.Dimension.End;

            //Create formatting Style for Hyperlinks
            //Will also be used later in Reformatted Sheet
            var namedStyle = sheet.Workbook.Styles.CreateNamedStyle("Hyper");
            namedStyle.Style.Font.UnderLine = true;
            namedStyle.Style.Font.Color.SetColor(Color.FromArgb(5, 99, 193));

            //Add information with hyperlinks
            sheet.Cells["B2"].Hyperlink = new ExcelHyperLink("https://sites.google.com/view/tesrskywind/va/how-to-record") { Display = "How to Record" };
            sheet.Cells["C2"].Hyperlink = new ExcelHyperLink("https://sites.google.com/view/tesrskywind/va/accent-guide") { Display = "Accent Guide" };
            sheet.Cells["D2"].Hyperlink = new ExcelHyperLink("https://sites.google.com/view/tesrskywind/va/problems") { Display = "Pronunciations" };
            sheet.Cells["E2"].Hyperlink = new ExcelHyperLink("https://trello.com/b/ehTXhmfX/voice-acting") { Display = "Trello" };
            sheet.Cells["F2"].Hyperlink = new ExcelHyperLink("https://discord.gg/Wzs4QTd") { Display = "Discord --- Ask questions here!" };

            //Set the style of the cells to be Hyperlink (blue underlined text) 
            sheet.Cells["B2:F2"].StyleName = "Hyper";


            //Make the column that contains the lines to speak Bold
            sheet.Cells["D3:D" + end.Row].Style.Font.Bold = true;

            //Set the style properites for the infomation Row
            sheet.Cells["A3:G3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            sheet.Cells["A3:G3"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(166, 166, 166));
            sheet.Cells["A3:G3"].Style.Font.Color.SetColor(Color.Black);
            sheet.Cells["A3:G3"].Style.Font.Bold = true;
            sheet.Cells["A3:G3"].Style.Font.Size = 14;
            sheet.Cells["A3:G3"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


            //Draw outside border
            sheet.Cells["A3:G" + end.Row].Style.Border.BorderAround(ExcelBorderStyle.Medium, System.Drawing.Color.Black);

            //To fix the issue of Grid Lines disapparing While Filling Color In Excel
            //We draw a border of the same color as the color of the grid border.
            sheet.Cells["A4:G" + end.Row].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            sheet.Cells["A4:G" + end.Row].Style.Border.Left.Color.SetColor(Color.FromArgb(192, 192, 192));
            sheet.Cells["A4:G" + end.Row].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            sheet.Cells["A4:G" + end.Row].Style.Border.Top.Color.SetColor(Color.FromArgb(192, 192, 192));

            //Color the sheet rows alternativy
            ColorAlternateRows(sheet);

            //Fade out and italicize the prompt if it's a continuation segment
            FadeOutNextSegment(sheet);

            //Autofit the rows for the content 
            for (int row = start.Row; row <= end.Row; row++)
            {
                AutofitRows.DoAutoFit(sheet, row);
            }

            //Set the column width to a bigger value to fix the issue of some rows needing more space

            sheet.Column(1).Width = 15;
            sheet.Column(2).Width = 24;
            sheet.Column(3).Width = 32;
            sheet.Column(4).Width = 52;
            sheet.Column(5).Width = 27;
            sheet.Column(6).Width = 37;
            sheet.Column(7).Width = 27;


        }

        #endregion

        #region Helper Methods
        /// <summary>
        /// Color the sheet rows with alternate colors (White and grey)
        /// But EXCLUDE continuation segments to make them the same color.
        /// </summary>
        /// <param name="sheet"></param>
        private void ColorAlternateRows(ExcelWorksheet sheet)
        {
            int row;
            int lastrow = sheet.Dimension.End.Row;

            Color color1 = System.Drawing.Color.FromArgb(233, 233, 233);
            Color color2 = System.Drawing.Color.FromArgb(255, 255, 255);

            // "Current" colour for highlighting

            Color currentColor = color1;

            for (row = 4; row <= lastrow; row++)
            {
                if (row == lastrow)
                {
                    sheet.Cells["A" + row + ":G" + row].Style.Fill.PatternType = ExcelFillStyle.Solid;

                    //Set the color of the row
                    sheet.Cells["A" + row + ":G" + row].Style.Fill.BackgroundColor.SetColor(currentColor);
                    break;
                }

                //Define the pattern type.
                //The range here is all rows within the excel sheet from A to G column
                sheet.Cells["A" + row + ":G" + row].Style.Fill.PatternType = ExcelFillStyle.Solid;

                //Set the color of the row
                sheet.Cells["A" + row + ":G" + row].Style.Fill.BackgroundColor.SetColor(currentColor);

                //get the filename in column A for the first line and second line
                string firstLine = sheet.Cells[row, 1].Value.ToString();
                string secondLine = sheet.Cells[row + 1, 1].Value.ToString();

                //get the original filename without the additional suffix numbering
                string firstLineWithoutSuffix = firstLine.Substring(0, firstLine.Length - 2);
                string SecondLineWithoutSuffix = secondLine.Substring(0, secondLine.Length - 2);

                // If column A value in next row is different, change colour
                if (SecondLineWithoutSuffix != firstLineWithoutSuffix)
                {
                    //Draw a border for alternating line except when the lines are of the same filename and color
                    sheet.Cells["A" + row + ":G" + row].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                    // Set to whichever colour it is not
                    if (currentColor == color1)
                        currentColor = color2;
                    else
                        currentColor = color1;
                }

            }
        }

        /// <summary>
        /// Fade out and italicize the prompt
        /// to help keep the VA focused on how one segment flows to the next.
        /// </summary>
        /// <param name="sheet"></param>
        private void FadeOutNextSegment(ExcelWorksheet sheet)
        {
            int row;
            int lastrow = sheet.Dimension.End.Row;

            for (row = 4; row <= lastrow; row++)
            {
                //Get the filename of the current line, for example: MorroDefau_0000EDA6_1
                string CurrentLine = sheet.Cells[row, 1].Value.ToString();

                //Get the filename of the previous line
                string PreviousLine = sheet.Cells[row - 1, 1].Value.ToString();

                //Get the filename without the segment numbering, For example: MorroDefau_0000EDA6
                string CurrentLineWithoutSuffix = CurrentLine.Substring(0, CurrentLine.Length - 2);
                string PreviousLineWithoutSuffix = PreviousLine.Substring(0, PreviousLine.Length - 2);

                //If the filename of the current row is the same as the previous row, Group the segments together into a line
                if (CurrentLineWithoutSuffix == PreviousLineWithoutSuffix)
                {
                    //Check if the background color is white 
                    if (sheet.Cells[row, 3].Style.Fill.BackgroundColor.Rgb == "#FFFFFF")
                    {
                        //Set the cell font to italic
                        sheet.Cells[row, 3].Style.Font.Italic = true;

                        //Change the color of the text of the cell to grey
                        sheet.Cells[row, 3].Style.Font.Color.SetColor(Color.FromArgb(192, 192, 192));
                    }
                    //If it isn't white which is in this case grey
                    else
                    {
                        sheet.Cells[row, 3].Style.Font.Italic = true;

                        //Change the color of the text of the cell to darker grey
                        sheet.Cells[row, 3].Style.Font.Color.SetColor(Color.FromArgb(175, 175, 175));
                    }

                }
            }


        }



        //Use the FindAndReplace function multiple times to search for the text required and replace it
        private void SearchForText(ExcelWorksheet sheet)
        {
            /*
             * This array has the values to be searched and the values that will replace it.
             * We replace & here becuase of a bug in Epplus that results in Xml parser error
             * The rest of the replacement is made according to the new rules from the Voice Processing Team
             */
            string[,] searchParameters = new string[8, 2] 
            {
                {"Bad Acting", "Acting" },
                {"&", "and" },
                { "MorroDefau_MDQGreeting_", "MorroDefau_MDQGreetingTopi_" },
                { "MorroDefau_MDQGreetings_", "MorroDefau_MDQGreetingsTop_" },
                { "MorroDefaultQuest_MDQIdle_", "MorroDefau_MDQIdleLinesTop_" } ,
                { "MorroDefaultQuest_MDQTopic_","MorroDefau_MDQMolagMarTopi_"},
                { "MorroDefau_MDQTopic_","MorroDefau_MDQMolagMarTopi_"},
                { "MorroDefau_MDQVivecTopicCi_","MorroDefau_MDQVivecTopic_"} 
            };

            FindAndReplace(sheet, searchParameters);

        }

        /// <summary>
        /// Finds a specific string in the excel sheet and replaces it with another string
        /// </summary>
        /// <param name="sheet">The sheet to search for the string in</param>
        private void FindAndReplace(ExcelWorksheet sheet, string[,] searchParameters)
        {
            for (int i = 0; i < searchParameters.GetLength(0); i++)
            {
                //Use LINQ query to search all the Sheet and select only the cells that contain the string
                var query = from cell in sheet.Cells["A:XFD"]
                            where cell.Value?.ToString().Contains(searchParameters[i,0]) == true
                            select cell;

                //replace the string in the cells that we selected
                foreach (var cell in query)
                {
                    cell.Value = cell.Value.ToString().Replace(searchParameters[i, 0], searchParameters[i, 1]);
                }
            }

        }

        #endregion

    }
}

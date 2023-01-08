using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RetakesFormatter.Classes.Formatting
{
    public static class AutofitRows
    {
        /// <summary>
        /// The method for doing the autofitting by measuring the text height. 
        /// </summary>
        /// <param name="sheet">Current Sheet</param>
        /// <param name="row">Current row</param>
        public static void DoAutoFit(ExcelWorksheet sheet, int row)
        {
            // The value of Prompt vell
            string PromptValue = sheet.Cells[row, 3]?.Value?.ToString();
            string LineValue = sheet.Cells[row, 4].Value.ToString();
            string ActingNotesValue = sheet.Cells[row, 6]?.Value?.ToString();
            string FilecutterNotesValue = sheet.Cells[row, 7]?.Value?.ToString();

            //Get the font of the line cell
            ExcelFont font = sheet.Cells[row, 4].Style.Font;
            var drawingFont = new Font(font.Name, font.Size);

            //Make a new line each 32 characters
            //32 is the number of characters in a single line in the Prompt Cell 
            string SlicedPrompt = SliceText(PromptValue, 32);

            //Make a new line each 55 characters
            //55 is the number of characters in a single line in the Line Cell 
            string SlicedLine = SliceText(LineValue, 56);

            string SlicedActingNotes = SliceText(ActingNotesValue, 40);
            string SlicedFilecutterNotes = SliceText(FilecutterNotesValue, 24);

            //measure the height of the text
            double SlicedPromptHieght = TextRenderer.MeasureText(SlicedPrompt, drawingFont).Height;
            double SlicedLineHieght = TextRenderer.MeasureText(SlicedLine, drawingFont).Height;
            double SlicedActingNotesHieght = TextRenderer.MeasureText(SlicedActingNotes, drawingFont).Height;
            double SlicedFilecutterNotesHieght = TextRenderer.MeasureText(SlicedFilecutterNotes, drawingFont).Height;

            //Set the height of the text to be the biggest value of the Line and Prompt Cell to autofit the whole row
            sheet.Row(row).Height = new[] { SlicedLineHieght, SlicedPromptHieght, SlicedActingNotesHieght, SlicedFilecutterNotesHieght }.Max();
        }

        /// <summary>
        /// The method for formatting rows in Reformatted Sheet
        /// </summary>
        /// <param name="sheet">Current Sheet</param>
        /// <param name="row">Current row</param>
        public static void DoAutoFitForReformatted(ExcelWorksheet sheet, int row)
        {
            // The value of Prompt vell
            string cellValue = sheet.Cells[row, 2].Value.ToString();

            //Get the font of the line cell
            ExcelFont font = sheet.Cells[row, 2].Style.Font;
            var drawingFont = new Font(font.Name, font.Size);

            //Make a new line each 55 characters
            //55 is the number of characters in a single line in the Cell 
            string SlicedCell = SliceText(cellValue, 51);

            //measure the height of the text
            double SlicedCellHieght = TextRenderer.MeasureText(SlicedCell, drawingFont).Height;

            sheet.Row(row).Height = Math.Max(18.75, SlicedCellHieght);
        }


        /// <summary>
        /// The method for slicing text into multiple lines
        /// </summary>
        /// <param name="text"></param>
        /// <param name="lineLength"></param>
        /// <returns></returns>
        private static string SliceText(string text, int lineLength)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            return Regex.Replace(text, "(.{" + lineLength + "})", "$1" + Environment.NewLine);
        }
    }
}
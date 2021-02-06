using OfficeOpenXml;
using RetakesFormatter.Classes.Data;
using System.Collections.Generic;
using System.Linq;

namespace RetakesFormatter.Classes.Formatting
{
    public class SegmentsGrouping
    {
        #region Variables

        List<Lines> GroupedLines = new List<Lines>();

        #endregion

        #region Main Method

        public List<Lines> GroupSegments(ExcelWorksheet sheet)
        {
            //the variable for storing the current row information
            int row;

            //The last row of the sheet
            int lastrow = sheet.Dimension.End.Row;

            string Speaker = "";
            string Prompt = "";

            List<string> Segments = new List<string>();
            List<string> Emotions = new List<string>();
            List<string> ActingNotes = new List<string>();

            //Loop through the rows of the sheet beginning at 4 which is the first line for this excel file
            //and ending at lastrow
            for (row = 4; row <= lastrow; row++)
            {
                //Get the filename of the current line, for example: MorroDefau_0000EDA6_1
                string CurrentLine = sheet.Cells[row, 1].Value.ToString();

                //Get the filename of the previous line
                string PreviousLine = sheet.Cells[row - 1, 1].Value.ToString();

                //Get the filename without the segment numbering, For example: MorroDefau_0000EDA6
                string CurrentLineWithoutSuffix = CurrentLine.Substring(0, CurrentLine.Length - 2);
                string PreviousLineWithoutSuffix = PreviousLine.Substring(0, PreviousLine.Length - 2);

                //If the current row is the first row
                if (row == 4)
                {
                    (Speaker, Prompt, Segments, Emotions, ActingNotes) = AddValuesToNewLine(sheet, row);
                }
                //If the filename of the current row is the same as the previous row, Group the segments together into a line
                else if (CurrentLineWithoutSuffix == PreviousLineWithoutSuffix)
                {
                    (Segments, Emotions, ActingNotes) = AddValuesToExistingLine(sheet, row, Segments, Emotions, ActingNotes);
                }
                //If the current filename is Unique and isn't a contiunation segment, Add it as new line
                else
                {
                    //Check if the prompt is null and set it's value
                    if (string.IsNullOrWhiteSpace(Prompt))
                        Prompt = sheet.Cells[row, 3]?.Value?.ToString();

                    //Add the old segment and increase the index
                    GroupedLines.Add(new Lines
                    {
                        speaker = Speaker,
                        prompt = Prompt,
                        segments = Segments,
                        emotions = Emotions,
                        actingNotes = ActingNotes


                    });

                    //Add a new line
                    (Speaker, Prompt, Segments, Emotions, ActingNotes) = AddValuesToNewLine(sheet, row);
                }
            }

            //Add last row
            if (string.IsNullOrWhiteSpace(Prompt))
                Prompt = sheet.Cells[row, 3]?.Value?.ToString();

            GroupedLines.Add(new Lines
            {
                speaker = Speaker,
                prompt = Prompt,
                segments = Segments,
                emotions = Emotions,
                actingNotes = ActingNotes

            });

            return GroupedLines;
        }

        #endregion

        #region Tuple Types Methods

        /// <summary>
        /// Using new C# 7 feautre Tuples syntax to be able to return multiple values from a method
        /// Make a new line that contains: Speaker, Prompt, Segments, Emotions, Acting Notes
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="currentRow"></param>
        /// <returns></returns>
        (string, string, List<string>, List<string>, List<string>) AddValuesToNewLine(ExcelWorksheet sheet, int currentRow)
        {
            //The last row of the sheet
            int lastrow = sheet.Dimension.End.Row;

            string Speaker = "";
            string Prompt = "";

            List<string> Segments = new List<string>();
            List<string> Emotions = new List<string>();
            List<string> ActingNotes = new List<string>();

            string FilecutterNotes;
            string OriginalEmotions;

            //Set the value of the variables from the cells of Excel
            Speaker = sheet.Cells[currentRow, 2]?.Value?.ToString();
            Prompt = sheet.Cells[currentRow, 3]?.Value?.ToString();

            //Using new List here to replace the list if it has any previous values
            Segments = new List<string>() { sheet.Cells[currentRow, 4].Value.ToString() };

            //Get the current emotion, For example: Neutral 50
            OriginalEmotions = sheet.Cells[currentRow, 5]?.Value?.ToString();

            //Check if the Emotions isn't null                  
            if (!string.IsNullOrWhiteSpace(OriginalEmotions))
            {
                //Get the emotion before the whitespace to get the emotion without the number, for example : Neutral
                Emotions = new List<string>() { OriginalEmotions.Substring(0, OriginalEmotions.IndexOf(" ")) };
            }
            else
            {
                Emotions = new List<string>() { OriginalEmotions};
            }

            ActingNotes = new List<string>() { sheet.Cells[currentRow, 6]?.Value?.ToString() };

            // check if the value is null useing ?.Value?.ToString()
            FilecutterNotes = sheet.Cells[currentRow, 7]?.Value?.ToString();

            //Check if the fileCutterNotes isn't null                  
            if (!string.IsNullOrWhiteSpace(FilecutterNotes))
            {
                //Check if Acting notes is empty
                if (!ActingNotes?.Any() ?? false)
                {
                    //Assign the filecutterNotes to the Acting notes
                    ActingNotes = new List<string>() {"Retake Note: " + FilecutterNotes };
                }
                else
                {
                    ActingNotes = new List<string>() { ActingNotes[0] + "Retake Note: " + FilecutterNotes };
                }
            }

            return (Speaker, Prompt, Segments, Emotions, ActingNotes);
        }

        /// <summary>
        /// Using new C# 7 feautre Tuples syntax to be able to return multiple values from a method
        /// This method takes three lists, Add the current value to each one of them.
        /// And then return the value 
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="currentRow"></param>
        /// <param name="Segments"></param>
        /// <param name="Emotions"></param>
        /// <param name="ActingNotes"></param>
        /// <returns></returns>
        (List<string>, List<string>, List<string>) AddValuesToExistingLine(ExcelWorksheet sheet, int currentRow, List<string> Segments, List<string> Emotions, List<string> ActingNotes)
        {
            //Add the current row segment into the list of the previous segment to group them
            Segments.Add(sheet.Cells[currentRow, 4].Value.ToString());

            string OriginalEmotions = sheet.Cells[currentRow, 5]?.Value?.ToString();

            //Check if the Emotions isn't null                  
            if (!string.IsNullOrWhiteSpace(OriginalEmotions))
            {
                Emotions.Add(OriginalEmotions.Substring(0, OriginalEmotions.IndexOf(" ")));
            }
            else
            {
                Emotions.Add(OriginalEmotions);
            }

            string tempActingNotes = sheet.Cells[currentRow, 6]?.Value?.ToString();

            string FilecutterNotes = sheet.Cells[currentRow, 7]?.Value?.ToString();

            if (!string.IsNullOrWhiteSpace(FilecutterNotes))
            {
                if (!tempActingNotes?.Any() ?? false)
                {
                    tempActingNotes = "Retake Note: " + FilecutterNotes;
                }
                else
                {
                    tempActingNotes = tempActingNotes + "Retake Note: " + FilecutterNotes;
                }
            }

            ActingNotes.Add(tempActingNotes);

            return (Segments, Emotions, ActingNotes);
        }

        #endregion
    }
}

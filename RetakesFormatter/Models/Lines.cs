using System.Collections.Generic;

namespace RetakesFormatter.Classes.Data
{
    public class Lines
    {
        public string Speaker { get; set; }
        public string Prompt { get; set; }
        public List<string> Segments { get; set; }
        public List<string> Emotions { get; set; }
        public List<string> ActingNotes { get; set; }
    }
}

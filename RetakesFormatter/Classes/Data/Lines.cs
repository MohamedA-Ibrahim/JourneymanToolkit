using System.Collections.Generic;

namespace RetakesFormatter.Classes.Data
{
    public class Lines
    {
        public string speaker { get; set; }
        public string prompt { get; set; }
        public List<string> segments { get; set; }
        public List<string> emotions { get; set; }
        public List<string> actingNotes { get; set; }
    }
}

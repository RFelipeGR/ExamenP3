using SQLite;

namespace RobertoGuañaExamen_3P.Models

{
    public class Movie
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string MainActor { get; set; }
        public string Awards { get; set; }
        public string Website { get; set; }
        public string Scordova { get; set; }
    }
}

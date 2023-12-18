namespace SmitApp.Core.MovieDtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Year { get; set; }
        public int Rating { get; set; }
    }
}
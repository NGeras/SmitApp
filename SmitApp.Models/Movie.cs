﻿namespace SmitApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int Rating { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
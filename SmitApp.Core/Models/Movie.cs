﻿namespace SmitApp.Core.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Rating { get; set; }
    public int CategoryId { get; set; }
}
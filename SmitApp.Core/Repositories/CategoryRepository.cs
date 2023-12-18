using SmitApp.Core.Contracts.Repositories;
using SmitApp.Models;

namespace SmitApp.Core.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly List<Category> categories = new()
    {
        new() { Id = 1, Name = "Drama" },
        new() { Id = 2, Name = "Action" },
        new() { Id = 3, Name = "Comedy" },
        new() { Id = 4, Name = "Sci-Fi" },
        new() { Id = 5, Name = "Fantasy" },
        new() { Id = 6, Name = "Adventure" },
        new() { Id = 7, Name = "Thriller" },
        new() { Id = 8, Name = "Animation" },
        new() { Id = 9, Name = "Romance" },
        new() { Id = 10, Name = "Mystery" }
    };

    public IEnumerable<Category> GetCategories()
    {
        return categories;
    }
}
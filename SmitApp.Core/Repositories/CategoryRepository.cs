using SmitApp.Core.Contracts.Repositories;
using SmitApp.Models;

namespace SmitApp.Core.Repositories;

public class CategoryRepository : ICategoryRepository
{
    List<Category> categories = new List<Category>
    {
        new Category { Id = 1, Name = "Drama" },
        new Category { Id = 2, Name = "Action" },
        new Category { Id = 3, Name = "Comedy" },
        new Category { Id = 4, Name = "Sci-Fi" },
        new Category { Id = 5, Name = "Fantasy" },
        new Category { Id = 6, Name = "Adventure" },
        new Category { Id = 7, Name = "Thriller" },
        new Category { Id = 8, Name = "Animation" },
        new Category { Id = 9, Name = "Romance" },
        new Category { Id = 10, Name = "Mystery" },
    };
    public IEnumerable<Category> GetCategories()
    {
        return categories;
    }
}
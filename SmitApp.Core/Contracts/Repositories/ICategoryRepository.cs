using SmitApp.Models;

namespace SmitApp.Core.Contracts.Repositories;

public interface ICategoryRepository
{
    IEnumerable<Category> GetCategories();
}
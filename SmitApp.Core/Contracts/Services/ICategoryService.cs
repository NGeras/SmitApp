using SmitApp.Models;

namespace SmitApp.Core.Contracts.Services;

public interface ICategoryService
{
    IEnumerable<Category> GetCategories();
}
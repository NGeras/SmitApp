using SmitApp.Models;

namespace SmitApp.Core.Contracts.Services;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetCategories();
}
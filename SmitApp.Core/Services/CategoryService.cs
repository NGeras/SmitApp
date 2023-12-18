using SmitApp.Core.Contracts.Repositories;
using SmitApp.Core.Contracts.Services;
using SmitApp.Models;

namespace SmitApp.Core.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public IEnumerable<Category> GetCategories()
    {
        return _categoryRepository.GetCategories();
    }
}
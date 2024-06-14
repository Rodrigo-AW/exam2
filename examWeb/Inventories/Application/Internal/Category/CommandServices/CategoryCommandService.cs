using examWeb.Inventories.Domain.Model.Commands;
using examWeb.Inventories.Domain.Repositories.Category;
using examWeb.Inventories.Domain.Services.Category;
using examWeb.Shared.Domain.Repositories;

namespace examWeb.Inventories.Application.Internal.Category.CommandServices;

public class CategoryCommandService : ICategoryCommandService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork    _unitOfWork;

    public CategoryCommandService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Model.Aggregates.Category> Handle(CreateCategoryCommand command)
    {
        var categoryExists = await _categoryRepository.FindCategoryByName(command.Name);

        if (categoryExists.Any())
        {
            throw new Exception("Category with name already exists");
        }

        var newCategory = new Domain.Model.Aggregates.Category(command);

        await _categoryRepository.AddAsync(newCategory);
        await _unitOfWork.CompleteAsync();
        return newCategory;






    }
}
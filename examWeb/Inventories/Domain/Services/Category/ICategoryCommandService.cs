using examWeb.Inventories.Domain.Model.Commands;

namespace examWeb.Inventories.Domain.Services.Category;

public interface ICategoryCommandService
{
    Task<Model.Aggregates.Category> Handle(CreateCategoryCommand command);
    
}
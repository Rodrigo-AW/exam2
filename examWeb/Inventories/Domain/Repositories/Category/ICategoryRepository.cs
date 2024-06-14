using examWeb.Shared.Domain.Repositories;

namespace examWeb.Inventories.Domain.Repositories.Category;

public interface ICategoryRepository : IBaseRepository<Model.Aggregates.Category>
{
    
/*  Task<Model.Aggregates.Category> FindCategoryById(long id);*/
    Task<IEnumerable<Model.Aggregates.Category>> FindCategoryByName(string categoryName);
}
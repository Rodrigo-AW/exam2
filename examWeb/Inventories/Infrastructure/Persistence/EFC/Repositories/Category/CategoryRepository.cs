using examWeb.Inventories.Domain.Repositories.Category;
using examWeb.Shared.Infrastructure.Persistence.EFC.Configuration;
using examWeb.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace examWeb.Inventories.Infrastructure.Persistence.EFC.Repositories.Category;

public class CategoryRepository :BaseRepository<Domain.Model.Aggregates.Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Domain.Model.Aggregates.Category>> FindCategoryByName(string categoryName)
    {
        return await Context.Set<Domain.Model.Aggregates.Category>()
            .Where(c => c.Name == categoryName)
            .ToListAsync();
    }
}
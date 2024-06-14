using examWeb.Inventories.Domain.Model.Aggregates;
using examWeb.Inventories.Interfaces.REST.Resources.Category;

namespace examWeb.Inventories.Interfaces.REST.Transform;

public static class CategoryResourceFromEntityAssembler
{
    public static CategoryResource ToResourceFromEntity(Category entity)
    {
        return new CategoryResource(entity.Id, entity.Name, entity.GroupId, entity.Description, entity.ReferenceImageUrl);
    }
}
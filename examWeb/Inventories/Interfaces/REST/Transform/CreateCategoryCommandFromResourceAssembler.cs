using examWeb.Inventories.Domain.Model.Commands;
using examWeb.Inventories.Interfaces.REST.Resources.Category;

namespace examWeb.Inventories.Interfaces.REST.Transform;

public  static class CreateCategoryCommandFromResourceAssembler
{
    
    public static CreateCategoryCommand ToCommandFromResource(CreateCategoryResource resource)
    {
        return new CreateCategoryCommand(resource.Name, resource.GroupId,resource.Description,resource.ReferenceImageUrl);
    }
    
}
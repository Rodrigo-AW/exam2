namespace examWeb.Inventories.Interfaces.REST.Resources.Category;

public record CreateCategoryResource( string Name, long GroupId, string Description, string ReferenceImageUrl);
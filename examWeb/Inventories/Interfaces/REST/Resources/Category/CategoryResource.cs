namespace examWeb.Inventories.Interfaces.REST.Resources.Category;

public record CategoryResource(long Id, string Name, long GroupId, string Description, string ReferenceImageUrl);
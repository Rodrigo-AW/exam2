using System.Net.Mime;
using examWeb.Inventories.Domain.Services.Category;
using examWeb.Inventories.Interfaces.REST.Resources.Category;
using examWeb.Inventories.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace examWeb.Inventories.Interfaces.REST;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class CategoryController: ControllerBase
{
    private readonly ICategoryCommandService _categoryCommandService;

    public CategoryController(ICategoryCommandService categoryCommandService)
    {
        _categoryCommandService = categoryCommandService;
    }

    [HttpPost("createCategory")]

    public async Task<ActionResult> CreateCategory([FromBody] CreateCategoryResource resource)
    {
        var createCategoryCommand = CreateCategoryCommandFromResourceAssembler.ToCommandFromResource(resource);
        var category = await _categoryCommandService.Handle(createCategoryCommand);
        return Ok(category);
    } 
    
    
    
}
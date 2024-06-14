using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using examWeb.Inventories.Domain.Model.Commands;
using examWeb.Inventories.Domain.Model.Entities;

namespace examWeb.Inventories.Domain.Model.Aggregates;

public partial class Category
{
   // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string Name { get; set; }
    public long GroupId { get; set; }
    public string Description { get; set; }
    public string ReferenceImageUrl { get; set; }
    
    protected Category()
    {
        this.Id = 0;
        this.Name = string.Empty;
        this.GroupId = 0;
        this.Description = string.Empty;
        this.ReferenceImageUrl = string.Empty;
    }

    public Category(CreateCategoryCommand command)
    {
        
        if(command.Name.Length>50)
        {
            throw new Exception("Name must be between 1 and 50 characters");
            
        }
        if(command.Description.Length>360)
        {
            throw new Exception("Description must be between 1 and 360 characters");
        }
        
        
        this.GroupId= command.GroupId;
        this.Name = command.Name;
        this.Description = command.Description;
        this.ReferenceImageUrl = command.ReferenceImageUrl;
        
        
    }
    [JsonIgnore]

    public Groupsa Group { get; set; } // Propiedad de navegación

    
    
    
    
}
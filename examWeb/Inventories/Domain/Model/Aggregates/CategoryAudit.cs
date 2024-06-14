using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace examWeb.Inventories.Domain.Model.Aggregates;

public partial class Category : IEntityWithCreatedUpdatedDate
{
    public DateTimeOffset? CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
}
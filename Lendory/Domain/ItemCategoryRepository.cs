using Lendory.Data;
using Lendory.Entities;
using Model.Domain;

namespace Lendory.Domain;

public class ItemCategoryRepository : ARepository<ItemCategory>
{
    public ItemCategoryRepository(ApplicationDbContext db) : base(db)
    {
    }
}
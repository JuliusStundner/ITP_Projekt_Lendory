using Lendory.Data;
using Lendory.Entities;
using Model.Domain;

namespace Lendory.Domain;

public class ItemRepository : ARepository<Item>
{
    public ItemRepository(ApplicationDbContext db) : base(db)
    {
    }
}
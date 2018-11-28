using CharacterThrowdown.Data;
using CharacterThrowdown.Models;
using CharacterThrowDown.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterThrowdown.Services
{
    public class ItemService
    {
        private readonly Guid _userId;

        public ItemService (Guid userId)
        {
            _userId = userId;
        }

        public bool CreateItem(ItemCreate model)
        {
            var entity =
                new Item()
                {
                    OwnerId = _userId,
                    ItemName = model.ItemName,
                    ItemDescription = model.ItemDescription,
                    ItemType = model.ItemType
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Items.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ItemListItem> GetItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Items
                        .Where(e => e.OwnerId == _userId) 
                        .Select(
                        e =>
                            new ItemListItem
                            {
                                ItemId = e.ItemId,
                                ItemName = e.ItemName,
                            }
                        );
                return query.ToArray();
            }
        }


    }
}

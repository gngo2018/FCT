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

        public ItemDetail GetItemById(int itemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Items
                        .Single(e => e.ItemId == itemId && e.OwnerId == _userId);
                return
                    new ItemDetail
                    {
                        ItemId = entity.ItemId,
                        ItemName = entity.ItemName,
                        ItemDescription = entity.ItemDescription,
                        ItemType = entity.ItemType
                    };
            }
        }

        public bool UpdateItem (ItemEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Items
                        .Single(e => e.ItemId == model.ItemId && e.OwnerId == _userId);

                entity.ItemName = model.ItemName;
                entity.ItemDescription = model.ItemDescription;
                entity.ItemType = model.ItemType;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteItem(int itemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Items
                        .Single(e => e.ItemId == itemId && e.OwnerId == _userId);

                ctx.Items.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}

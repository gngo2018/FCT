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
    public class CharacterService
    {
        private readonly Guid _userId;

        public CharacterService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCharacter(CharacterCreate model)
        {
            var entity =
                new Character()
                {
                    OwnerId = _userId,
                    CharacterName = model.CharacterName,
                    CharacterUniverse = model.CharacterUniverse,
                    CharacterAbility = model.CharacterAbility,
                    ItemId = model.ItemId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Characters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CharacterListItem> GetCharacters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Characters
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                            new CharacterListItem
                            {
                                CharacterId = e.CharacterId,
                                CharacterName = e.CharacterName,
                                ItemId = e.ItemId,
                                Item = e.Item
                            }

                        );

                var newList = query.ToList();

                return newList;
            }
        }

        public CharacterDetail GetCharacterById(int characterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.CharacterId == characterId && e.OwnerId == _userId);
                return
                    new CharacterDetail
                    {
                        CharacterId = entity.CharacterId,
                        CharacterName = entity.CharacterName,
                        CharacterUniverse = entity.CharacterUniverse,
                        CharacterAbility = entity.CharacterAbility,
                        ItemId = entity.ItemId,
                        Item = entity.Item
                    };

            }
        }

        public bool UpdateCharacter(CharacterEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.CharacterId == model.CharacterId && e.OwnerId == _userId);

                entity.CharacterName = model.CharacterName;
                entity.CharacterUniverse = model.CharacterUniverse;
                entity.CharacterAbility = model.CharacterAbility;
                entity.ItemId = model.ItemId;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCharacter(int characterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.CharacterId == characterId && e.OwnerId == _userId);
                ctx.Characters.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

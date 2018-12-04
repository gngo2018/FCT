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
    public class BattleService
    {
        private readonly Guid _userId;

        public BattleService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateBattle (BattleCreate model)
        {
            var entity =
                new Battle()
                {
                    OwnerId = _userId,
                    Location = model.Location,
                    FirstCharacterId = model.FirstCharacterId,
                    SecondCharacterId = model.SecondCharacterId,
                    FirstCharacter = model.FirstCharacter,
                    SecondCharacter = model.SecondCharacter
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Battles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BattleListItem> GetBattles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Battles
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                            new BattleListItem
                            {
                                BattleId = e.BattleId,
                                FirstCharacterId = e.FirstCharacterId,
                                SecondCharacterId = e.SecondCharacterId,
                                Location = e.Location,
                                FirstCharacterName = e.FirstCharacter.CharacterName,
                                SecondCharacterName = e.SecondCharacter.CharacterName
                            }

                        );

                var newList = query.ToList();

                return newList;
            }
        }

        public BattleDetail GetBattleById(int battleId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Battles
                        .Single(e => e.BattleId == battleId && e.OwnerId == _userId);
                return
                    new BattleDetail
                    {
                        BattleId = entity.BattleId,
                        Location = entity.Location,
                        FirstCharacterId = entity.FirstCharacterId,
                        FirstCharacter = entity.FirstCharacter,
                        SecondCharacterId = entity.SecondCharacterId,
                        SecondCharacter = entity.SecondCharacter,
                        WinnerCharacterId = entity.WinnerCharacterId,
                        WinnerCharacter = entity.WinnerCharacter
                    };
            }
        }
    }
}

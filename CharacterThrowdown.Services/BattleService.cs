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
            Random winner = new Random();
            var outcome = winner.Next(0, 100);
            if (outcome < 50)
            {
                model.WinnerCharacterId = model.FirstCharacterId;
            }

            else
            {
                model.WinnerCharacterId = model.SecondCharacterId;
            }

            var entity =
                new Battle()
                {
                    OwnerId = _userId,
                    Location = model.Location,
                    FirstCharacterId = model.FirstCharacterId,
                    SecondCharacterId = model.SecondCharacterId,
                    FirstItemId = model.FirstItemId,
                    SecondItemId = model.SecondItemId,
                    BattleName = model.BattleName,
                    WinnerCharacterId = model.WinnerCharacterId
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
                                BattleName = e.BattleName,
                                FirstCharacterId = e.FirstCharacterId,
                                SecondCharacterId = e.SecondCharacterId,
                                Location = e.Location,
                                FirstCharacter= ctx.Characters.FirstOrDefault(f => f.CharacterId == e.FirstCharacterId),
                                SecondCharacter = ctx.Characters.FirstOrDefault(f => f.CharacterId == e.SecondCharacterId),
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
                        .FirstOrDefault(e => e.BattleId == battleId && e.OwnerId == _userId);

                var model = new BattleDetail
                {
                    BattleId = entity.BattleId,
                    BattleName = entity.BattleName,
                    Location = entity.Location,
                    FirstCharacterId = entity.FirstCharacterId,
                    SecondCharacterId = entity.SecondCharacterId,
                    FirstItemId = entity.FirstItemId,
                    SecondItemId = entity.SecondItemId,
                    WinnerCharacterId = entity.WinnerCharacterId,
                };

                if (ctx.Characters.Any(c => c.CharacterId == model.FirstCharacterId))
                {
                    model.FirstCharacter = ctx.Characters.Single(e => e.CharacterId == entity.FirstCharacterId);
                }

                if (ctx.Characters.Any(c => c.CharacterId == model.SecondCharacterId))
                {
                    model.SecondCharacter = ctx.Characters.Single(e => e.CharacterId == entity.SecondCharacterId);
                }

                if (ctx.Items.Any(c => c.ItemId == model.FirstItemId))
                {
                    model.FirstItem = ctx.Items.Single(e => e.ItemId == entity.FirstItemId);
                }

                if (ctx.Items.Any(c => c.ItemId == model.SecondItemId))
                {
                    model.SecondItem = ctx.Items.Single(e => e.ItemId == entity.SecondItemId);
                }

                //Random Generator
                if (ctx.Characters.Any(c => c.CharacterId == model.WinnerCharacterId))
                {
                    model.WinnerCharacter = ctx.Characters.Single(e => e.CharacterId == entity.WinnerCharacterId);
                }

                //Random winner = new Random();
                //var outcome = winner.Next(0, 100);
                //if (outcome < 50)
                //{
                //    model.WinnerCharacterId = model.FirstCharacterId;
                //    //ctx.Battles.Add(entity);
                //}

                //else
                //{
                //    model.WinnerCharacterId = model.SecondCharacterId;
                //    //ctx.Battles.Add(entity);
                //}


                return model;
            }
        }

        public bool UpdateBattle(BattleEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Battles
                        .Single(e => e.BattleId == model.BattleId && e.OwnerId == _userId);

                entity.Location = model.Location;
                entity.FirstCharacterId = model.FirstCharacterId;
                entity.SecondCharacterId = model.SecondCharacterId;
                entity.FirstItemId = model.FirstItemId;
                entity.SecondItemId = model.SecondItemId;
                entity.WinnerCharacterId = model.WinnerCharacterId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBattle(int battleId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Battles
                        .Single(e => e.BattleId == battleId && e.OwnerId == _userId);
                ctx.Battles.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

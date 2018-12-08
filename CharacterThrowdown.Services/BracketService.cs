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
    public class BracketService
    {
        public bool CreateBracket(BracketCreate model)
        {
            //Winner Generator
            Random winner = new Random();
            var outcome = winner.Next(0, 100);
            //First 8
            if (outcome < 50)
            {
                model.FirstEightWinnerId = model.FirstCharacterEightId;
            }
            else
            {
                model.FirstEightWinnerId = model.SecondCharacterEightId;
            }
            //Second 8
            if (outcome < 50)
            {
                model.SecondEightWinnerId = model.ThirdCharacterEightId;
            }
            else
            {
                model.SecondEightWinnerId = model.FourthCharacterEightId;
            }
            //Third 8
            if (outcome < 50)
            {
                model.ThirdEightWinnerId = model.FifthCharacterEightId;
            }
            else
            {
                model.ThirdEightWinnerId = model.SixthCharacterEightId;
            }
            //Fourth 8
            if (outcome < 50)
            {
                model.FourthEightWinnerId = model.SeventhCharacterEightId;
            }
            else
            {
                model.FourthEightWinnerId = model.EighthCharacterEightId;
            }

            var entity =
                new Bracket()
                {
                    Location = model.Location,
                    TournamentName = model.TournamentName,
                    //Elite Eight
                    FirstCharacterEightId = model.FirstCharacterEightId,
                    SecondCharacterEightId = model.SecondCharacterEightId,
                    ThirdCharacterEightId = model.ThirdCharacterEightId,
                    FourthCharacterEightId = model.FourthCharacterEightId,
                    FifthCharacterEightId = model.FifthCharacterEightId,
                    SixthCharacterEightId = model.SixthCharacterEightId,
                    SeventhCharacterEightId = model.SeventhCharacterEightId,
                    EighthCharacterEightId = model.EighthCharacterEightId,
                    FirstEightWinnerId = model.FirstEightWinnerId,
                    SecondEightWinnerId = model.SecondEightWinnerId,
                    ThirdEightWinnerId = model.ThirdEightWinnerId,
                    FourthEightWinnerId = model.FourthEightWinnerId,
                    //Final Four
                    FirstCharacterFourId = model.FirstEightWinnerId,
                    SecondCharacterFourId = model.SecondEightWinnerId,
                    ThirdCharacterFourId = model.ThirdEightWinnerId,
                    FourthCharacterFourId = model.FourthEightWinnerId,

                    FirstFourWinnerId = model.FirstFourWinnerId,
                    SecondFourWinnerId = model.SecondFourWinnerId,
                    //Final
                    FirstCharacterFinalId = model.FirstFourWinnerId,
                    SecondCharacterFinalId = model.SecondFourWinnerId,
                    FinalWinnerId = model.FinalWinnerId
                };


            Random newRandom = new Random();
            var outcomeFour = newRandom.Next(0, 100);
            //First 4
            if (outcomeFour < 50)
            {
                entity.FirstFourWinnerId = entity.FirstCharacterFourId;
            }
            else
            {
                entity.FirstFourWinnerId = entity.SecondCharacterFourId;
            }
            //Second 4
            if (outcomeFour < 50)
            {
                entity.SecondFourWinnerId = entity.ThirdCharacterFourId;
            }
            else
            {
                entity.SecondFourWinnerId = entity.FourthCharacterFourId;
            }
            Random finalRandom = new Random();
            var outcomeFinal = finalRandom.Next(0, 100);
            //Final
            if (outcomeFinal < 50)
            {
                entity.FinalWinnerId = entity.FirstFourWinnerId;
            }
            else
            {
                entity.FinalWinnerId = entity.SecondFourWinnerId;
            }

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Brackets.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<BracketListItem> GetBrackets()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Brackets
                        .Select(
                        e =>
                            new BracketListItem
                            {
                                BracketId = e.BracketId,
                                TournamentName = e.TournamentName,
                                Location = e.Location
                            }

                        );

                var newList = query.ToList();

                return newList;
            }
        }

        public BracketDetail GetBracketById(int bracketId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Brackets
                        .FirstOrDefault(e => e.BracketId == bracketId);

                var model = new BracketDetail
                {
                    BracketId = entity.BracketId,
                    TournamentName = entity.TournamentName,
                    Location = entity.Location,
                    FirstCharacterEightId = entity.FirstCharacterEightId,
                    SecondCharacterEightId = entity.SecondCharacterEightId,
                    ThirdCharacterEightId = entity.ThirdCharacterEightId,
                    FourthCharacterEightId = entity.FourthCharacterEightId,
                    FifthCharacterEightId = entity.FifthCharacterEightId,
                    SixthCharacterEightId = entity.SixthCharacterEightId,
                    SeventhCharacterEightId = entity.SeventhCharacterEightId,
                    EighthCharacterEightId = entity.EighthCharacterEightId,
                    FirstEightWinnerId = entity.FirstEightWinnerId,
                    SecondEightWinnerId = entity.SecondEightWinnerId,
                    ThirdEightWinnerId = entity.ThirdEightWinnerId,
                    FourthEightWinnerId = entity.FourthEightWinnerId,
                    //Final Four
                    FirstCharacterFourId = entity.FirstEightWinnerId,
                    SecondCharacterFourId = entity.SecondEightWinnerId,
                    ThirdCharacterFourId = entity.ThirdEightWinnerId,
                    FourthCharacterFourId = entity.FourthEightWinnerId,

                    FirstFourWinnerId = entity.FirstFourWinnerId,
                    SecondFourWinnerId = entity.SecondFourWinnerId,
                    //Final
                    FinalWinnerId = entity.FinalWinnerId

                };


                if (ctx.Characters.Any(c => c.CharacterId == model.FirstCharacterEightId))
                {
                    model.FirstCharacterEight = ctx.Characters.Single(e => e.CharacterId == entity.FirstCharacterEightId);
                }

                if (ctx.Characters.Any(c => c.CharacterId == model.SecondCharacterEightId))
                {
                    model.SecondCharacterEight = ctx.Characters.Single(e => e.CharacterId == entity.SecondCharacterEightId);
                }

                if (ctx.Characters.Any(c => c.CharacterId == model.ThirdCharacterEightId))
                {
                    model.ThirdCharacterEight = ctx.Characters.Single(e => e.CharacterId == entity.ThirdCharacterEightId);
                }

                if (ctx.Characters.Any(c => c.CharacterId == model.FourthCharacterEightId))
                {
                    model.FourthCharacterEight = ctx.Characters.Single(e => e.CharacterId == entity.FourthCharacterEightId);
                }

                if (ctx.Characters.Any(c => c.CharacterId == model.FifthCharacterEightId))
                {
                    model.FifthCharacterEight = ctx.Characters.Single(e => e.CharacterId == entity.FifthCharacterEightId);
                }

                if (ctx.Characters.Any(c => c.CharacterId == model.SixthCharacterEightId))
                {
                    model.SixthCharacterEight = ctx.Characters.Single(e => e.CharacterId == entity.SixthCharacterEightId);
                }

                if (ctx.Characters.Any(c => c.CharacterId == model.SeventhCharacterEightId))
                {
                    model.SeventhCharacterEight = ctx.Characters.Single(e => e.CharacterId == entity.SeventhCharacterEightId);
                }

                if (ctx.Characters.Any(c => c.CharacterId == model.EighthCharacterEightId))
                {
                    model.EighthCharacterEight = ctx.Characters.Single(e => e.CharacterId == entity.EighthCharacterEightId);
                }

                if (ctx.Characters.Any(c => c.CharacterId == model.FirstEightWinnerId))
                {
                    model.FirstEightWinner = ctx.Characters.Single(e => e.CharacterId == entity.FirstEightWinnerId);
                }

                if (ctx.Characters.Any(c => c.CharacterId == model.SecondEightWinnerId))
                {
                    model.SecondEightWinner = ctx.Characters.Single(e => e.CharacterId == entity.SecondEightWinnerId);
                }

                if (ctx.Characters.Any(c => c.CharacterId == model.ThirdEightWinnerId))
                {
                    model.ThirdEightWinner = ctx.Characters.Single(e => e.CharacterId == entity.ThirdEightWinnerId);
                }

                if (ctx.Characters.Any(c => c.CharacterId == model.FourthEightWinnerId))
                {
                    model.FourthEightWinner = ctx.Characters.Single(e => e.CharacterId == entity.FourthEightWinnerId);
                }

                if (ctx.Characters.Any(c => c.CharacterId == model.FirstFourWinnerId))
                {
                    model.FirstFourWinner = ctx.Characters.Single(e => e.CharacterId == entity.FirstFourWinnerId);
                }

                if (ctx.Characters.Any(c => c.CharacterId == model.SecondFourWinnerId))
                {
                    model.SecondFourWinner = ctx.Characters.Single(e => e.CharacterId == entity.SecondFourWinnerId);
                }

                if (ctx.Characters.Any(c => c.CharacterId == model.FinalWinnerId))
                {
                    model.FinalWinner = ctx.Characters.Single(e => e.CharacterId == entity.FinalWinnerId);
                }

                return model;
            }
        }

        public bool UpdateBracket(BracketEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Brackets
                        .Single(e => e.BracketId == model.BracketId);

                entity.Location = model.Location;
                entity.FirstCharacterEightId = model.FirstCharacterId;
                entity.SecondCharacterEightId = model.SecondCharacterId;
                entity.ThirdCharacterEightId = model.ThirdCharacterId;
                entity.FourthCharacterEightId = model.FourthCharacterId;
                entity.FifthCharacterEightId = model.FifthCharacterId;
                entity.SixthCharacterEightId = model.SixthCharacterId;
                entity.SeventhCharacterEightId = model.SeventhCharacterId;
                entity.EighthCharacterEightId = model.EighthCharacterId;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBracket(int bracketId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Brackets
                        .Single(e => e.BracketId == bracketId);
                ctx.Brackets.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public List<Character> Characters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Characters.ToList();
            }
        }

        public List<Bracket> Brackets()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Brackets.ToList();
            }
        }

    }
}

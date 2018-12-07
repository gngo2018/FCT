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
                    FirstCharacterFinalId = model.FirstCharacterFinalId,
                    SecondCharacterFinalId = model.SecondCharacterFinalId,
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

            var outcomeFinal = winner.Next(0, 100);
            //Final
            if (outcomeFinal < 50)
            {
                entity.FinalWinnerId = entity.FirstCharacterFinalId;
            }
            else
            {
                entity.FinalWinnerId = entity .SecondCharacterFinalId;
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

    }
}

﻿using CharacterThrowdown.Data;
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
                    CharacterAbillity = model.CharacterAbillity
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
                            }

                        );
                return query.ToArray();
            }
        }
    }
}

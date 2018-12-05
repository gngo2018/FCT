using CharacterThrowdown.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterThrowdown.Models
{
    public class BattleEdit
    {
        public int BattleId { get; set; }
        public string Location { get; set; }
        public int FirstCharacterId { get; set; }
        public int SecondCharacterId { get; set; }

        public virtual Character FirstCharacter { get; set; }
        public virtual Character SecondCharacter { get; set; }
    }
}

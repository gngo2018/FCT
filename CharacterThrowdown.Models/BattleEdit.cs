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
        public string BattleName { get; set; }
        public string Location { get; set; }
        public int FirstCharacterId { get; set; }
        public int SecondCharacterId { get; set; }
        public int FirstItemId { get; set; }
        public int SecondItemId { get; set; }
        public int WinnerCharacterId { get; set; }

        public virtual Item FirstItem { get; set; }
        public virtual Item SecondItem { get; set; }
        public virtual Character FirstCharacter { get; set; }
        public virtual Character SecondCharacter { get; set; }
        public virtual Character WinnerCharacter { get; set; }

    }
}

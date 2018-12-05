using CharacterThrowdown.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterThrowdown.Models
{
    public class BattleDetail
    {
        public int BattleId { get; set; }
        public string Location { get; set; }
        [Display(Name = "Character 1 ID")]
        public int FirstCharacterId { get; set; }
        [Display(Name = "Character 2 ID")]
        public int SecondCharacterId { get; set; }
        [Display(Name = "Winner ID")]
        public int WinnerCharacterId { get; set; }
        public int FirstItemId { get; set; }
        public int SecondItemId { get; set; }


        public virtual Character FirstCharacter { get; set; }
        public virtual Character SecondCharacter { get; set; }
        public virtual Character WinnerCharacter { get; set; }
        public virtual Item FirstItem { get; set; }
        public virtual Item SecondItem { get; set; }


        public override string ToString() => $"[{BattleId}] {Location}";
    }
}

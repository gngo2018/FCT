using CharacterThrowdown.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterThrowdown.Models
{
    public class BattleListItem
    {
        [Display(Name= "Battle ID")]
        public int BattleId { get; set; }
        [Display(Name = "Battle Location")]
        public string Location { get; set; }
        [Display(Name = "Character 1")]
        public int FirstCharacterId { get; set; }
        [Display(Name = "Character 2")]
        public int SecondCharacterId { get; set; }
        [Display(Name = "Character 1 Weapon")]
        public int WinnerCharacterId { get; set; }

//        public string FirstCharacterName { get; set; }
//        public string SecondCharacterName { get; set; }
        
        public virtual Character FirstCharacter { get; set; }
        public virtual Character SecondCharacter { get; set; }
        public virtual Character WinnerCharacter { get; set; }

        public override string ToString() => Location;
    }
}

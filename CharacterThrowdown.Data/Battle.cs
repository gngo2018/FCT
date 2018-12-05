using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterThrowdown.Data
{
    public class Battle
    {
        [Key]
        public int BattleId { get; set; }
        public int FirstCharacterId { get; set; }
        public int SecondCharacterId { get; set; }
        public int FirstItemId { get; set; }
        public int SecondItemId { get; set; }
        public int WinnerCharacterId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Location { get; set; }

        public virtual Character FirstCharacter { get; set; }
        public virtual Character SecondCharacter { get; set; }
        public virtual Item FirstItem { get; set; }
        public virtual Item SecondItem { get; set; }
        public virtual Character WinnerCharacter { get; set; }
        

    }
}

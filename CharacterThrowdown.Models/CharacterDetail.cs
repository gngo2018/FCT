using CharacterThrowdown.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterThrowdown.Models
{
    public class CharacterDetail
    {
        [Display(Name = "Character ID")]
        public int CharacterId { get; set; }

        [Display(Name = "Character Name")]
        public string CharacterName { get; set; }

        [Display(Name = "Universe")]
        public Universe CharacterUniverse { get; set; }

        [Display(Name = "Character Ability")]
        public string CharacterAbility { get; set; }

        public override string ToString() => $"[{CharacterId}] {CharacterName}";
    }
}

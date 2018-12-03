using CharacterThrowdown.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterThrowdown.Models
{
    public class CharacterListItem
    {
        [Display(Name = "Character ID")]
        public int CharacterId { get; set; }

        [Display(Name = "Character Name")]
        public string CharacterName { get; set; }

        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public override string ToString() => CharacterName;
    }
}

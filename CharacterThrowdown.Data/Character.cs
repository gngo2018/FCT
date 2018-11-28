using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterThrowdown.Data
{
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }

        [Required]
        public string CharacterName { get; set; }

        [Required]
        public string CharacterUniverse { get; set; }

        [Required]
        public string CharacterAbillity { get; set; }
    }
}

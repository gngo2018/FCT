using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterThrowdown.Models
{
    public class CharacterCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least 1 character")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field")]
        public string CharacterName { get; set; }
        public string CharacterUniverse { get; set; }
        public string CharacterAbillity { get; set; }

        public override string ToString() => CharacterName;
    }
}

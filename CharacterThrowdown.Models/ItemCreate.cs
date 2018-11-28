using CharacterThrowdown.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterThrowdown.Models
{
    public class ItemCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least 1 character")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field")]
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public TypeOfItem ItemType { get; set; }

        public override string ToString() => ItemName;
    }
}

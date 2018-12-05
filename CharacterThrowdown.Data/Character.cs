using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterThrowdown.Data
{
    public enum Universe
    {
        [Display(Name = "Marvel")]
        Marvel = 1,
        [Display(Name = "DC")]
        DC,
        [Display(Name = "Star Wars")]
        StarWars,
        [Display(Name = "Other")]
        Other,
    }

    public class Character
    {
        [Key]
        public int CharacterId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string CharacterName { get; set; }

        [Required]
        public Universe CharacterUniverse { get; set; }

        [Required]
        public string CharacterAbility { get; set; }
 
    }

}

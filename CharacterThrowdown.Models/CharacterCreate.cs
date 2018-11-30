﻿using CharacterThrowdown.Data;
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
        [Display(Name = "Character Name")]
        public string CharacterName { get; set; }

        [Display(Name = "Universe")]
        public Universe CharacterUniverse { get; set; }

        [Display(Name = "Character Ability")]
        public string CharacterAbility { get; set; }

        [Required(ErrorMessage = "Weapon needed for battle. Please choose or create a new item.")]
        [Display(Name = "Item Id # Character will use")]
        public int ItemId { get; set; }

        //[Display(Name = "Item Id # that this Character will use")]
        //public virtual Item Item { get; set; }

        public override string ToString() => CharacterName;
    }
}

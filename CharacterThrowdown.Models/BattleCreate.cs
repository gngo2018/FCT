﻿using CharacterThrowdown.Data;
using CharacterThrowDown.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterThrowdown.Models
{
    public class BattleCreate
    {
        [Display(Name= "Battle Location")]
        public string Location { get; set; }
        [Display(Name= "Character 1")]
        public int FirstCharacterId { get; set; }
        [Display(Name = "Character 2")]
        public int SecondCharacterId { get; set; }

        public virtual Character FirstCharacter { get; set; }
        public virtual Character SecondCharacter { get; set; }

        public override string ToString() => Location;
    }

}
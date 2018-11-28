﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterThrowdown.Models
{
    public class CharacterListItem
    {
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }

        public override string ToString() => CharacterName;
    }
}
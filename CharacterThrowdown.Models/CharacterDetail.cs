using CharacterThrowdown.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterThrowdown.Models
{
    public class CharacterDetail
    {
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public Universe CharacterUniverse { get; set; }
        public string CharacterAbillity { get; set; }

        public override string ToString() => $"[{CharacterId}] {CharacterName}";
    }
}

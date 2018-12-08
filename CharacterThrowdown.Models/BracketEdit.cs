using CharacterThrowdown.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterThrowdown.Models
{
    public class BracketEdit
    {
        public int BracketId { get; set; }
        public string TournamentName { get; set; }
        public string Location { get; set; }
        public int FirstCharacterId { get; set; }
        public int SecondCharacterId { get; set; }
        public int ThirdCharacterId { get; set; }
        public int FourthCharacterId { get; set; }
        public int FifthCharacterId { get; set; }
        public int SixthCharacterId { get; set; }
        public int SeventhCharacterId { get; set; }
        public int EighthCharacterId { get; set; }

        public virtual Character FirstCharacter { get; set; }
        public virtual Character SecondCharacter { get; set; }
        public virtual Character ThirdCharacter { get; set; }
        public virtual Character FourthCharacter { get; set; }
        public virtual Character FifthCharacter { get; set; }
        public virtual Character SixthCharacter { get; set; }
        public virtual Character SeventhCharacter { get; set; }
        public virtual Character EighthCharacter { get; set; }

    }
}

using CharacterThrowdown.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterThrowdown.Models
{
    public class BracketCreate
    {
        [Required]
        [Display(Name = "Tournament Location")]
        public string Location { get; set; }
        [Display(Name = "Tournament Name")]
        public string TournamentName { get; set; }
        [Display(Name="Character 1")]
        public int FirstCharacterEightId { get; set; }
        [Display(Name = "Character 2")]
        public int SecondCharacterEightId { get; set; }
        [Display(Name = "Character 3")]
        public int ThirdCharacterEightId { get; set; }
        [Display(Name = "Character 4")]
        public int FourthCharacterEightId { get; set; }
        [Display(Name = "Character 5")]
        public int FifthCharacterEightId { get; set; }
        [Display(Name = "Character 6")]
        public int SixthCharacterEightId { get; set; }
        [Display(Name = "Character 7")]
        public int SeventhCharacterEightId { get; set; }
        [Display(Name = "Character 8")]
        public int EighthCharacterEightId { get; set; }
        //Final Four
        public int FirstCharacterFourId { get; set; }
        public int SecondCharacterFourId { get; set; }
        public int ThirdCharacterFourId { get; set; }
        public int FourthCharacterFourId { get; set; }
        //Final
        public int FirstCharacterFinalId { get; set; }
        public int SecondCharacterFinalId { get; set; }
        //Winners
        public int FirstEightWinnerId { get; set; }
        public int SecondEightWinnerId { get; set; }
        public int ThirdEightWinnerId { get; set; }
        public int FourthEightWinnerId { get; set; }
        public int FirstFourWinnerId { get; set; }
        public int SecondFourWinnerId { get; set; }
        public int FinalWinnerId { get; set; }

        //Virtual Eight
        public virtual Character FirstCharacterEight { get; set; }
        public virtual Character SecondCharacterEight { get; set; }
        public virtual Character FirstEightWinner { get; set; }
        public virtual Character ThirdCharacterEight { get; set; }
        public virtual Character FourthCharacterEight { get; set; }
        public virtual Character SecondEightWinner { get; set; }
        public virtual Character FifthCharacterEight { get; set; }
        public virtual Character SixthCharacterEight { get; set; }
        public virtual Character ThirdEightWinner { get; set; }
        public virtual Character SeventhCharacterEight { get; set; }
        public virtual Character EighthCharacterEight { get; set; }
        public virtual Character FourthEightWinner { get; set; }
    }
}

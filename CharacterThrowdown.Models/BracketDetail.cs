﻿using CharacterThrowdown.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterThrowdown.Models
{
    public class BracketDetail
    {
        [Display(Name = "Tounament Id")]
        public int BracketId { get; set; }
        public string Location { get; set; }
        [Display(Name = "Tournament Name")]
        public string TournamentName { get; set; }
        //Elite Eight
        [Display(Name= "Character 1")]
        public int FirstCharacterEightId { get; set; }
        [Display(Name = "Character 2")]
        public int SecondCharacterEightId { get; set; }
        [Display(Name = "Winner")]
        public int FirstEightWinnerId { get; set; }
        [Display(Name = "Character 3")]
        public int ThirdCharacterEightId { get; set; }
        [Display(Name = "Character 4")]
        public int FourthCharacterEightId { get; set; }
        [Display(Name = "Winner")]
        public int SecondEightWinnerId { get; set; }
        [Display(Name="Elite 8 Character 5")]
        public int FifthCharacterEightId { get; set; }
        public int SixthCharacterEightId { get; set; }
        public int ThirdEightWinnerId { get; set; }

        public int SeventhCharacterEightId { get; set; }
        public int EighthCharacterEightId { get; set; }
        public int FourthEightWinnerId { get; set; }
        //Final Four
        [Display(Name = "")]
        public int FirstCharacterFourId { get; set; }
        public int SecondCharacterFourId { get; set; }
        public int FirstFourWinnerId { get; set; }
        [Display(Name = "Character 2")]
        public int ThirdCharacterFourId { get; set; }
        public int FourthCharacterFourId { get; set; }
        public int SecondFourWinnerId { get; set; }
        //Final
        [Display(Name = "Champion")]

        public int FinalWinnerId { get; set; }

        //Virtual
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
        //Virtual Four
        public virtual Character FirstCharacterFour { get; set; }
        public virtual Character SecondCharacterFour { get; set; }
        public virtual Character FirstFourWinner { get; set; }
        public virtual Character ThirdCharacterFour { get; set; }
        public virtual Character FourthCharacterFour { get; set; }
        public virtual Character SecondFourWinner { get; set; }
        //Virtual Final
        public virtual Character FirstCharacterFinal { get; set; }
        public virtual Character SecondCharacterFinal { get; set; }
        public virtual Character FinalWinner { get; set; }

    }
}

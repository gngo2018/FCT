using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterThrowdown.Models
{
    public class BracketListItem
    {
        [Display(Name= "Tourney ID")]
        public int BracketId { get; set; }
        public string Location { get; set; }
        [Display(Name = "Tourney Name")]
        public string TournamentName { get; set; }
    }
}

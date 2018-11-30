using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterThrowdown.Data
{
    public class Battle
    {
        [Key]
        public int BattleId { get; set; }

        [Required]
        public string Location { get; set; }

        public virtual Character Character { get; set; }
        public virtual Item Item { get; set; }

    }
}

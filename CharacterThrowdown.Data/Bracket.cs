using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterThrowdown.Data
{
    public class Bracket
    {
        [Key]
        public int BracketId { get; set; }
        public int BattleId { get; set; }

        public virtual Battle FirstBattle { get; set; }
        public virtual Battle SecondBattle { get; set; }
        public virtual Battle ThirdBattle { get; set; }
        public virtual Battle FourthBattle { get; set; }

    }
}

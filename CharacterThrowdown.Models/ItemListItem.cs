using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterThrowdown.Models
{
    public class ItemListItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }

        public override string ToString() => ItemName;
    }
}

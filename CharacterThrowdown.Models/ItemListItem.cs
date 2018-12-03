using CharacterThrowdown.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterThrowdown.Models
{
    public class ItemListItem
    {
        [Display(Name="Item ID")]
        public int ItemId { get; set; }
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        public IEnumerable<Item> Items { get; set; }

        public override string ToString() => ItemName;
    }
}

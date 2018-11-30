using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterThrowdown.Data
{
    public enum TypeOfItem
    {
        [Display(Name = "Melee")]
        Melee = 1,
        [Display(Name = "Ranged")]
        Ranged,
        [Display(Name = "Magic")]
        Magic,
        [Display(Name = "Other")]
        Other,
    }

    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        
        public Guid OwnerId { get; set; }

        public string ItemName { get; set; }

        
        public string ItemDescription { get; set; }

        
        public TypeOfItem ItemType { get; set; }
    }
}

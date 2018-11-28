using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        public string ItemDescription { get; set; }

        [Required]
        public TypeOfItem ItemType { get; set; }
    }
}

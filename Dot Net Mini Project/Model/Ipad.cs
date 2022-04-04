using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;


namespace Dot_Net_Mini_Project
{
    class Ipad
    {
        //[Key, ForeignKey("user")]
        [Key]
        //[Required()]
        public int IpadId { get; set; }

        [Required()]
        [MaxLength(10)]
        public string IpadName { get; set; }

        [Required()]
        public int Quantity { get; set; }

        [Required()]
        public decimal Price { get; set; }

        public int UserId { get; set; }
        //[ForeignKey("UserId")]
        public virtual User user { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;

namespace Dot_Net_Mini_Project
{
    class User
    {
        [Key]
        [Required()]
        public int UserId { get; set; }

        [Required()]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required()]
        public string Email { get; set; }
              
        [Required()]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required()]
        public string Category { get; set; }

        [Required()]
        public string Role { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TruyumApplication.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MenuItem")]
        public int MenuItenId { get; set; }

        public MenuItem MenuItem { get; set; }
    }
}
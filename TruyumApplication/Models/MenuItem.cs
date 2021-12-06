using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TruyumApplication.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Display(Name = "Free Delivery")]
        public bool FreeDelivery { get; set; }

        [Display(Name = "Date Of Launch")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfLaunch { get; set; }

        public bool Active { get; set; }

        [ForeignKey("Category")]
        [Display(Name="Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruyumApplication.Models;

namespace TruyumApplication.ViewModels
{
    public class NewItemViewModel
    {
        public MenuItem MenuItem { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
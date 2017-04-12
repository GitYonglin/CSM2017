using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMBUI.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public bool Show { get; set; }
        public string url { get; set; }
        public List<Menu> SubCategory { get; set; }
    }
}

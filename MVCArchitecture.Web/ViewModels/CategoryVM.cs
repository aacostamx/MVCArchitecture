using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCArchitecture.Web.ViewModels
{
    public class CategoryVM
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public List<GadgetVM> Gadgets { get; set; }
    }
}
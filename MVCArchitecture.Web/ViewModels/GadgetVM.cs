﻿namespace MVCArchitecture.Web.ViewModels
{
    public class GadgetVM
    {
        public int GadgetID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public int CategoryID { get; set; }
    }
}
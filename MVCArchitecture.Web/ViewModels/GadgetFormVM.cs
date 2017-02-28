using System.Web;

namespace MVCArchitecture.Web.ViewModels
{
    public class GadgetFormVM
    {
        public HttpPostedFileBase File { get; set; }
        public string GadgetTitle { get; set; }
        public string GadgetDescription { get; set; }
        public decimal GadgetPrice { get; set; }
        public int GadgetCategory { get; set; }
    }
}
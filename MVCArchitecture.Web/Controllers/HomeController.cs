using AutoMapper;
using MVCArchitecture.Model.Models;
using MVCArchitecture.Service.Services;
using MVCArchitecture.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCArchitecture.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IGadgetService gadgetService;

        public HomeController(ICategoryService categoryService, IGadgetService gadgetService)
        {
            this.categoryService = categoryService;
            this.gadgetService = gadgetService;
        }

        public ActionResult Index(string category = null)
        {
            IEnumerable<CategoryVM> categoryVM;
            IEnumerable<Category> categories;

            categories = categoryService.GetCategories(category).ToList();

            categoryVM = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryVM>>(categories);
            return View(categoryVM);
        }

        public ActionResult Filter(string category, string gadgetName)
        {
            IEnumerable<GadgetVM> gadgetVM;
            IEnumerable<Gadget> gadgets;

            gadgets = gadgetService.GetCategoryGadgets(category, gadgetName);

            gadgetVM = Mapper.Map<IEnumerable<Gadget>, IEnumerable<GadgetVM>>(gadgets);

            return View(gadgetVM);
        }

        [HttpPost]
        public ActionResult Create(GadgetFormVM newGadget)
        {
            if (newGadget != null && newGadget.File != null)
            {
                var gadget = Mapper.Map<GadgetFormVM, Gadget>(newGadget);
                gadgetService.CreateGadget(gadget);

                string gadgetPicture = System.IO.Path.GetFileName(newGadget.File.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/images/"), gadgetPicture);
                newGadget.File.SaveAs(path);

                gadgetService.SaveGadget();
            }

            var category = categoryService.GetCategory(newGadget.GadgetCategory);
            return RedirectToAction("Index", new { category = category.Name });
        }
    }
}
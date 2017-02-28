﻿using MVCArchitecture.Data.Infrastructure;
using MVCArchitecture.Data.Repositories;
using MVCArchitecture.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVCArchitecture.Service.Services
{
    public interface IGadgetService
    {
        IEnumerable<Gadget> GetGadgets();
        IEnumerable<Gadget> GetCategoryGadgets(string categoryName, string gadgetName = null);
        Gadget GetGadget(int id);
        void CreateGadget(Gadget gadget);
        void SaveGadget();
    }

    public class GadgetService : IGadgetService
    {
        private readonly IGadgetRepository gadgetsRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public GadgetService(IGadgetRepository gadgetsRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.gadgetsRepository = gadgetsRepository;
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IGadgetService Members

        public IEnumerable<Gadget> GetGadgets()
        {
            var gadgets = gadgetsRepository.GetAll();
            return gadgets;
        }

        public IEnumerable<Gadget> GetCategoryGadgets(string categoryName, string gadgetName = null)
        {
            var category = categoryRepository.GetCategoryByName(categoryName);
            return category.Gadgets.Where(g => g.Name.ToLower().Contains(gadgetName.ToLower().Trim()));
        }

        public Gadget GetGadget(int id)
        {
            var gadget = gadgetsRepository.GetById(id);
            return gadget;
        }

        public void CreateGadget(Gadget gadget)
        {
            gadgetsRepository.Add(gadget);
        }

        public void SaveGadget()
        {
            unitOfWork.Commit();
        }

        #endregion

    }
}
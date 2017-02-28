using AutoMapper;
using MVCArchitecture.Model.Models;
using MVCArchitecture.Web.ViewModels;

namespace MVCArchitecture.Web.Mappings
{
    public class ModelMapping : Profile
    {
        public ModelMapping()
        {
            CreateMap<Category, CategoryVM>().ReverseMap();
            CreateMap<Gadget, GadgetVM>().ReverseMap();
            CreateMap<GadgetFormVM, Gadget>()
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.GadgetTitle))
                .ForMember(g => g.Description, map => map.MapFrom(vm => vm.GadgetDescription))
                .ForMember(g => g.Price, map => map.MapFrom(vm => vm.GadgetPrice))
                .ForMember(g => g.Image, map => map.MapFrom(vm => vm.File.FileName))
                .ForMember(g => g.CategoryID, map => map.MapFrom(vm => vm.GadgetCategory))
                .ReverseMap();
        }
    }
}

using AutoMapper;
using ShoppingMallAssignmentDB.Models;
using ShoppingMallAssignmentMVC.Models;

namespace ShoppingMallAssignmentMVC.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<ShoppingMallModel, ShoppingMallModel>().ReverseMap();
        }
    }  
    
}

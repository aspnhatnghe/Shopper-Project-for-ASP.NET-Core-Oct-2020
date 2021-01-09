
using AutoMapper;
using ShopperProject.Areas.Admin.Models;
using ShopperProject.Data;

namespace ShopperProject.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //định nghĩa phần map
            CreateMap<HangHoaVM, HangHoa>().ReverseMap();
        }
    }
}

using AutoMapper;
using VirtualTrading.Model;

namespace VirtualTrading.DAL.Models
{
    public class MyAssetProfile : Profile
    {
        public MyAssetProfile() =>
          this.CreateMap<MyAsset, MyAssetModel>();

      //  Mapper.CreateMap<Person, Doctor>()
      //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LastName))
      //.ForMember(dest => dest.Id, opt => opt.Ignore())
      //.ForSourceMember(src=> src.FirstName, opt => opt.Ignore());

        // public MyAssetProfile() =>
        //this.CreateMap<MyAsset, MyAssetModel>().ForMember(x => x.profitloss, opt => opt.Ignore()).ForMember(x => x.StockId ,opt => opt.Ignore())
        //   .ForMember(x => x.UserId, opt => opt.Ignore());

        //  this.CreateMap<MyAsset, MyAssetModel>().Ignore()
        //CreateMap<Foo, Bar>().ForMember(x => x.Blarg, opt => opt.Ignore());

    }
}

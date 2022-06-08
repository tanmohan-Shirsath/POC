using AutoMapper;
using VirtualTrading.Model;

namespace VirtualTrading.DAL.Models
{
    class OrderHistoryProfile : Profile
    {
        public OrderHistoryProfile() =>
           this.CreateMap<TradeHistory, OrderHistoryModel>();
    }
}

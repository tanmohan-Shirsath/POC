using AutoMapper;
using System.Collections.Generic;
using VirtualTrading.Model;

namespace VirtualTrading.Interface
{
    public interface IOrderHistory
    {
        public List<OrderHistoryModel> GetOrderHistoryByUserID(string UserId, IMapper _mapper);
    }
}

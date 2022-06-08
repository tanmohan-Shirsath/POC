using System.Collections.Generic;
using VirtualTrading.Model;
using AutoMapper;
using VirtualTrading.Interface;

namespace VirtualTrading.API.Repository
{
    public class OrderHistoryRepository : IOrderHistory
    {
        VirtualTrading.BAL.VTOrderHistoryBAL _bal = new BAL.VTOrderHistoryBAL();
        public List<OrderHistoryModel> GetOrderHistoryByUserID(string UserId, IMapper _mapper)
        {
            List<OrderHistoryModel> OrderHistory = _bal.GetOrderHistoryByUserID(UserId, _mapper);

            return OrderHistory;
        }
    }
}

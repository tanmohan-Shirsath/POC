using AutoMapper;
using System.Collections.Generic;
using VirtualTrading.DAL;
using VirtualTrading.Model;

namespace VirtualTrading.BAL
{
    public class VTOrderHistoryBAL
    {
        VirtualTradeDataAccessLayer Context = new VirtualTradeDataAccessLayer();
        public List<OrderHistoryModel> GetOrderHistoryByUserID(string UserId, IMapper _mapper)
        {
            List<OrderHistoryModel> OrderHistory = Context.GetOrderHistoryByUserID(UserId, _mapper);

            return OrderHistory;
        }
    }
}

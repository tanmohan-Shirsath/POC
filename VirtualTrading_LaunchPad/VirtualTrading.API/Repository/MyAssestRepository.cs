using System.Collections.Generic;
using VirtualTrading.Model;
using AutoMapper;
using VirtualTrading.Interface;

namespace VirtualTrading.API.Repository
{
    public class MyAssestRepository :IMyAssest
    {
        VirtualTrading.BAL.VTMyAsset _bal = new BAL.VTMyAsset();
        public List<MyAssetModel> GetMyAssestByUserID(string UserId, IMapper _mapper)
        {
            List<MyAssetModel> MyAsset = _bal.GetMyAssetByUserID(UserId, _mapper);

            return MyAsset;
        }
        // MyAssetComponent.html:2 ERROR Error: Could not find column with id "stockSymbol ".

        public decimal GetUserBalanceByUserID(string UserId)
        {
            decimal UserBalance = _bal.GetUserBalanceByUserID(UserId);
            return UserBalance;

        }
    }
}

using AutoMapper;
using System.Collections.Generic;
using VirtualTrading.Model;

namespace VirtualTrading.Interface
{
    public interface IMyAssest
    {
        public List<MyAssetModel> GetMyAssestByUserID(string UserId, IMapper _mapper);

        public decimal GetUserBalanceByUserID(string UserId);
    }

}

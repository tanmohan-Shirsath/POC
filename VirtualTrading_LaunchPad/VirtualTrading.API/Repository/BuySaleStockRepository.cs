using System.Collections.Generic;
using VirtualTrading.Model;
using AutoMapper;
using VirtualTrading.Interface;
using System;
using VirtualTrading.BAL;

namespace VirtualTrading.API.Repository
{
    public class BuySaleStockRepository : IBuySaleStock
    {
        VTBuySaleStockBAL _bal = new VTBuySaleStockBAL();

        public bool BuyNewStockByUserID(string paramUserId, string paramStockSymbol, decimal paramPrice, decimal paramCommision, decimal paramQuantity, decimal paramTotal, bool paramTransactionType, DateTime paramdatetime, string From, String UserName, String Password, String SMTPServer, IMapper _mapper)
        {   
            bool IsInserted = _bal.BuyNewStockByUserID(paramUserId, paramStockSymbol, paramPrice, paramCommision, paramQuantity, paramTotal, paramTransactionType, paramdatetime, From, UserName, Password, SMTPServer, _mapper);

            return IsInserted;
        }
    }
}

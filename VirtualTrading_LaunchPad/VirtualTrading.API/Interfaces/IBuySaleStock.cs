using AutoMapper;
using System;
using System.Collections.Generic;
using VirtualTrading.Model;

namespace VirtualTrading.Interface
{
    public interface IBuySaleStock
    {
        bool BuyNewStockByUserID(string paramUserId, string paramStockSymbol, decimal paramPrice, decimal paramCommision, decimal paramQuantity, decimal paramTotal, bool paramTransactionType, DateTime paramdatetime, string From, String UserName, String Password, String SMTPServer, IMapper _mapper);
    }
}

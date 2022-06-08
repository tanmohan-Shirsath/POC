using AutoMapper;
using System;
using System.Collections.Generic;
using VirtualTrading.DAL;
using VirtualTrading.Model;
using VirtualTrading.Common;

namespace VirtualTrading.BAL
{
    public class VTBuySaleStockBAL
    {
        VirtualTradeDataAccessLayer Context = new VirtualTradeDataAccessLayer();
        public bool BuyNewStockByUserID(string paramUserId, string paramStockSymbol, decimal paramPrice, decimal paramCommision, decimal paramQuantity, decimal paramTotal, bool paramTransactionType, DateTime paramdatetime, string From, string userName, String Password, String SMPTServer, IMapper _mapper)
        {
            // 1. Get stockid based on stock sysmbol from stockprice table
            // 2. Get userbalance based on the userid from userbalance table. Calculate AccountValue based on buy or sale. If buy then substract and if sale then add to the AccountValue 
            //    Update into the userbalance table.
            // 3. Check if the tradeId exist based on the userId and StockId. If not Generate new unique tradeId 
            // 4. Get the RemainingQuantity based on UserId and StockId. Calculate the RemainingQuantity based on the new qualnity based on buy or sale the stock.
            // 5. Calculate the TradeStatus

            //1
            string subject = string.Empty;
            string body = string.Empty;
            bool IsInserted = false;
            int paramStockId = Context.GetStockIdByStockSymbol(paramStockSymbol);
            //2
            decimal UserBalance = Context.GetUseBakanceByUserId(paramUserId);
            if (UserBalance > paramTotal)
            {
            }
            else { 
            }
            decimal AccountValue = CalculateUserBalance(UserBalance, paramTotal, paramCommision, paramTransactionType);

            //3
            bool paramTradeStatus;
            long TradeId = GetTradeId(paramUserId, paramStockId, out paramTradeStatus);
            //long TradeId = GetTradeId(paramUserId, paramStockId);

            //4
            decimal RemainingQuantity = CalculateRemainingQuantity(TradeId, paramUserId, paramStockId, paramQuantity, paramTransactionType, paramTradeStatus);

            //RemainingQuantity.CompareTo(0.0M);
            //5

            if (!paramTradeStatus) {
            paramTradeStatus = calculateTradeStatus(RemainingQuantity, paramQuantity);
            }

            IsInserted = Context.BuyNewStockByUserID(TradeId, paramUserId, paramStockId, paramPrice, paramCommision, paramQuantity, paramTotal, AccountValue, paramTransactionType, paramTradeStatus, paramdatetime, RemainingQuantity, _mapper);

            if (IsInserted)
            {
                string UserEmail = Context.GetUserEmailAddress(paramUserId);
                
                subject = "You order has been Placed.";

                if (paramTransactionType)
                {
                    body = string.Format("You bought {0} {1} stocks for a price of {2} each.", paramQuantity, paramStockSymbol, paramPrice);
                }
                else
                {
                    body = string.Format("You sold {0} {1} stocks for a price of {2} each.", paramQuantity, paramStockSymbol, paramPrice);
                }
                VTCommonEmail.SendEmail(subject,body,UserEmail, From, userName,Password,SMPTServer);
            
            }
            return IsInserted;
        }

        private bool calculateTradeStatus(decimal RemainingQuantity, decimal paramQuantity)
        {
            bool result = false;
            if (RemainingQuantity == 0)
            {
                // Trade is closed
                result = false;
            }
            else
            {
                // Trade is Open
                result = true;
            }
            return result;
        }

        private long GetTradeId(string UserId, int StockId, out bool paramTradeStatus)        
        {
            paramTradeStatus = false;
            long TradeId = Context.GetTradeId(UserId, StockId);
            //New Trade
            if (TradeId == 0)
            {
                paramTradeStatus = true;
                TradeId = DateTime.Now.Ticks;                
            }
            return TradeId;
        }

        private decimal CalculateRemainingQuantity(long TradeId, string UserId, int StockId, decimal paramQuantity, bool paramTransactionType, bool paramIsNewTrade)
        {
            decimal RemainingQuantity = Context.CalculateRemainingQuantity(TradeId, UserId, StockId);

            if (RemainingQuantity == 0)
            {
                RemainingQuantity = paramQuantity;
            }
            else
            {
                if (paramTransactionType && ! paramIsNewTrade)
                {
                    RemainingQuantity = RemainingQuantity + paramQuantity;
                }
                else
                {
                    RemainingQuantity = RemainingQuantity - paramQuantity;
                }
                
            }
            return RemainingQuantity;
        }

        private decimal CalculateUserBalance(decimal UserBalance, decimal paramTotal, decimal paramCommision,  bool paramTransactionType)
        {
            decimal AccountValue;
            paramTotal = paramTotal - paramCommision;

            if (paramTransactionType == true)
            {
                AccountValue = UserBalance - paramTotal;
            }
            else
            {
                AccountValue = UserBalance + paramTotal;
            }

            return AccountValue;
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualTrading.DAL.Models;
using VirtualTrading.Model;

namespace VirtualTrading.DAL
{
    public class VirtualTradeDataAccessLayer
    {
        private virtualTraderContext _Context = new virtualTraderContext();
        
        public List<StockpriceModel> GetAllStockPrice(DateTime CurrentDate, IMapper _mapper)
        {          
            List<StockpriceModel> stockPrices = new List<StockpriceModel>();
            try
            {   
                var result = from sp in _Context.StockPrices
                             join s in _Context.Stocks on sp.StockId equals s.StockId
                             where sp.Date.Equals(CurrentDate)
                             select new
                             {
                                 StockSymbol = s.Symbol,
                                 StockCompanyName = s.CompanyName,
                                 CloseMarket = sp.CloseMarket,
                                 VolumeOfMarket = sp.VolumeOfMarket,
                                 OpenMarket = sp.OpenMarket,
                                 HighMarket = sp.HighMarket,
                                 LowMarket = sp.LowMarket,
                                 Date = sp.Date,
                             };
                var source = result.ToList();
                stockPrices = _mapper.Map<List<StockpriceModel>>(source);               
            }
            catch (Exception ex)
            {
                throw;
            }

            return stockPrices;
        }

        public List<OrderHistoryModel> GetOrderHistoryByUserID(string UserId, IMapper _mapper)
        {
            //UserId = 1;
            List<OrderHistoryModel> OrderHistory = new List<OrderHistoryModel>();
            try
            {   
                var result = from Th in _Context.TradeHistories
                             join s in _Context.Stocks on Th.StockId equals s.StockId
                             where Th.UserId.Equals(UserId)
                             select new
                             {
                                 StockSymbol = s.Symbol,
                                 StockCompanyName = s.CompanyName,
                                 DateTime = Th.DateTime,
                                 TransactionType = Th.TransactionType,
                                 Quantity = Th.Quantity,
                                 Price = Th.Price,
                                 Commision = Th.Commision,
                                 Total = Th.Total,
                                 AccountValue = Th.AccountValue,
                                 TradeStatus = Th.TradeStatus,
                             };
                var source = result.ToList();
                OrderHistory = _mapper.Map<List<OrderHistoryModel>>(source);
            }
            catch (Exception ex)
            {
                throw;
            }

            return OrderHistory;
        }

        public List<MyAssetModel> GetMyAssetByUserID(string UserId, IMapper _mapper)
        {
            //UserId = 2;
            List<MyAssetModel> MyAssetModel = new List<MyAssetModel>();
            try
            {
                var result = from Th in _Context.MyAssets
                             join s in _Context.Stocks on Th.StockId equals s.StockId
                             join sp in _Context.StockPrices on s.StockId equals sp.StockId
                             group Th by new
                             {
                                 Th.TradeId,
                                 Th.UserId, 
                                 Th.StockId,
                                 Th.RemainingQuantity,                                
                                 s.Symbol,
                                 s.CompanyName,
                                 Th.Price,
                                 Th.Commision,
                                 Th.Total,
                                 Th.AccountValue,
                                 Th.DateTime,                                
                             } into gc
                             where gc.Key.UserId.Equals(UserId) &&  gc.Key.RemainingQuantity != 0
                             select new
                             {
                                 StockSymbol = gc.Key.Symbol,
                                 StockCompanyName = gc.Key.CompanyName.Trim(),
                                 DateTime = gc.Key.DateTime,
                                 RemainingQuantity = gc.Key.RemainingQuantity,
                                 Price = gc.Key.Price,
                                 Commision = gc.Key.Commision,
                                 Total = gc.Key.Total,
                                 AccountValue = gc.Key.AccountValue,
                                 profitloss = 0,
                                 UserId = gc.Key.UserId,
                                 StockId = gc.Key.StockId,
                             };
                var p = result.ToList().OrderByDescending(x => x.DateTime);                
                var source = p;
                MyAssetModel = _mapper.Map<List<MyAssetModel>>(source);
            }
            catch (Exception ex)
            {
                throw;
            }

            return MyAssetModel;
        }

        public bool BuyNewStockByUserID(long paramTradeId, string paramUserId, int paramStockId, decimal paramPrice, decimal paramCommision, decimal paramQuantity, decimal paramTotal, decimal paramAccountValue, bool paramTransactionType, bool paramTradeStatus, DateTime paramdatetime, decimal paramRemainingQuantity, IMapper _mapper)
        {
            using (var context = new virtualTraderContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var newTradeHistory = new TradeHistory
                        {
                           TradeId = paramTradeId,
                           UserId = paramUserId,
                           StockId = paramStockId,
                           Price = paramPrice,
                           Commision = paramCommision,
                           Quantity = paramQuantity,
                           RemainingQuantity = paramRemainingQuantity,
                           Total = paramTotal,
                           AccountValue = paramAccountValue,
                           TransactionType = paramTransactionType,
                           TradeStatus = paramTradeStatus,
                           DateTime = paramdatetime,
                        };

                        context.TradeHistories.Add(newTradeHistory);
                        context.SaveChanges();

                        var uBal = context.UserBalances.FirstOrDefault(x => x.UserId == paramUserId);
                        uBal.AvailableBalance = paramAccountValue;
                        context.SaveChanges();

                        var vMyAsset = context.MyAssets.FirstOrDefault(p => p.StockId == paramStockId && p.TradeId == paramTradeId && p.UserId == paramUserId);

                        //Add new
                        if (vMyAsset == null)
                        {
                            var newMyAsset = new MyAsset
                            {
                                TradeId = paramTradeId,
                                UserId = paramUserId,
                                StockId = paramStockId,
                                Price = paramPrice,
                                Commision = paramCommision,
                                RemainingQuantity = paramRemainingQuantity,
                                Total = paramTotal,
                                AccountValue = paramAccountValue,
                                DateTime = paramdatetime,
                            };

                            context.MyAssets.Add(newMyAsset);
                            context.SaveChanges();
                        }
                        else
                        {
                            //Existing update
                            vMyAsset.RemainingQuantity = paramRemainingQuantity;
                            vMyAsset.Price = paramPrice;
                            vMyAsset.Total = paramTotal;
                            vMyAsset.AccountValue = paramAccountValue;
                            vMyAsset.DateTime = paramdatetime;
                            context.SaveChanges();
                        }
                        
                        transaction.Commit(); 
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public string GetUserEmailAddress(string UserId) {
            var result = _Context.AspNetUsers.SingleOrDefault(x => x.Id == UserId);
            return result.Email;
        }
        public bool AddDefaultUserBalance(string UserId)
        {
            using (var context = new virtualTraderContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var UserBal = new UserBalance
                        {
                            UserId = UserId,
                            AvailableBalance = 100000,
                            LastAccess = DateTime.Now,
                        };
                        context.UserBalances.Add(UserBal);
                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

            public bool AddStockPrice(int stockId, DateTime date, decimal openMarket, decimal highMarket, decimal lowMarket, decimal closeMarket, decimal volumeOfMarket, IMapper _mapper)
        {
            using (var context = new virtualTraderContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var strockPrice = new StockPrice
                        {
                            StockId = stockId,
                            Date = date,
                            OpenMarket = openMarket,
                            HighMarket = highMarket,
                            LowMarket = lowMarket,
                            CloseMarket = closeMarket,
                            VolumeOfMarket = volumeOfMarket,
                        };
                        context.StockPrices.Add(strockPrice);
                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return false;
                    }
                    }
            }
        }
        public decimal GetStockPriceByStockSymbol(string StockSymbol, IMapper _mapper)
        {
            var Stock = _Context.Stocks.SingleOrDefault(x => x.Symbol == StockSymbol);
            int stockId = Stock.StockId;

            var result = _Context.StockPrices.Where(p => p.StockId == stockId).OrderByDescending(x => x.Date).Select(x => new
            {
                x.CloseMarket
            }).Take(1);

            decimal StockPrice = (decimal)result.SingleOrDefault().CloseMarket;
            return StockPrice;
            
        }
        public int GetStockIdByStockSymbol(string StockSymbol)
        {
            var Stock = _Context.Stocks.SingleOrDefault(x => x.Symbol == StockSymbol);
            return Stock.StockId;
        }

        public decimal CalculateRemainingQuantity(long TradeId, string UserId, int StockId)
        {
            decimal RemainingQuantity = 0;
            var result = _Context.TradeHistories.OrderByDescending(x => x.DateTime).FirstOrDefault(x => x.TradeId == TradeId && x.UserId == UserId && x.StockId == StockId);
            if (result == null)
            {
                RemainingQuantity = 0;
            }
            else {
                RemainingQuantity = (decimal)result.RemainingQuantity;
            }
            return RemainingQuantity;
        }
        public long GetTradeId(string UserId, int StockId)
        {
            var result = _Context.TradeHistories.FirstOrDefault(x => x.UserId == UserId && x.StockId == StockId);
            long TradeId = 0;

            if (result != null)
            {
                TradeId = result.TradeId;
            }

            return TradeId;
        }
        public decimal GetUseBakanceByUserId(string UserId)
        {
            var UserBalance = _Context.UserBalances.SingleOrDefault(x => x.UserId == UserId);
            return (decimal)UserBalance.AvailableBalance;
        }

        public decimal GetUserBalanceByUserID(string UserId)
        {

            var result = _Context.UserBalances.SingleOrDefault(x => x.UserId == UserId);
            decimal UserBalance = (decimal)result.AvailableBalance;
            
            return UserBalance;

        }

        //public  GetprofitForStocks(string UserId, int StockId)
        //{

        //    decimal CurrentValue = _Context..Total;
        //    decimal TotalValue = StockpriceModel.CloseMarket * OrderHistoryModel.Quantity;

        //    decimal result = CurrentValue - TotalValue;

        //    if (result < 0)
        //    {
        //        return result;
        //        // printf (""Your loss is ")

        //    }
        //    else
        //    {
        //        return result;

        //        // You have profit 
        //    }

        //}


      

        //public decimal GetStockSymbolByStockId(int stockId, IMapper _mapper) 
        //{
        //    var StockSymbol = _Context.Stocks.SingleOrDefault(x => x.StockId == stockId);

        //    var StockSymbol = Stock.symbol;

      

        //    decimal StockPrice = (decimal)result.SingleOrDefault().CloseMarket;
        //    return StockPrice;



        //}

        public string GetStockSymbolByStockId(int stockId)
        {
            var result = _Context.Stocks.SingleOrDefault(x => x.StockId == stockId);
            string StockSymbol = result.Symbol;
            return StockSymbol;
        }    


    }
}

       



//public UserModel AuthenticateUser(string userName, String Password, IMapper _mapper)
//{
//    UserModel userModel = new UserModel();
//    User users = _Context.Users.SingleOrDefault(x => x.Email == userName && x.Password == Password);

//    userModel = _mapper.Map<UserModel>(users);
//    return userModel;
//}

//public UserModel AuthenticateUserByID(int userNameId, IMapper _mapper)
//{
//    UserModel userModel = new UserModel();
//    User users = _Context.Users.SingleOrDefault(x => x.UserId == userNameId);

//    userModel = _mapper.Map<UserModel>(users);
//    return userModel;
//}

//public List<MyAssetModel> GetMyAssetByUserID(string UserId, IMapper _mapper)
//{
//    //UserId = 2;
//    List<MyAssetModel> MyAssetModel = new List<MyAssetModel>();
//    try
//    {
//        var result = from Th in _Context.TradeHistories
//                     join s in _Context.Stocks on Th.StockId equals s.StockId
//                     join sp in _Context.StockPrices on s.StockId equals sp.StockId
//                     group Th by new
//                     {
//                         Th.TradeId,
//                         Th.UserId,
//                         Th.TransactionType,
//                         Th.RemainingQuantity,
//                         Th.Quantity,
//                         s.Symbol,
//                         s.CompanyName,
//                         Th.Price,
//                         Th.Commision,
//                         Th.Total,
//                         Th.AccountValue,
//                         Th.DateTime,
//                         Th.TradeStatus,
//                     } into gc
//                     where gc.Key.UserId.Equals(UserId) && gc.Key.TransactionType.Equals(false) && gc.Key.TradeStatus.Equals(true)                             
//                     select new
//                     {
//                         StockSymbol = gc.Key.Symbol,
//                         StockCompanyName = gc.Key.CompanyName.Trim(),
//                         DateTime = gc.Key.DateTime,
//                         TransactionType = gc.Key.TransactionType,
//                         Quantity = gc.Key.Quantity,
//                         RemainingQuantity = gc.Key.RemainingQuantity,
//                         Price = gc.Key.Price,
//                         Commision = gc.Key.Commision,
//                         Total = gc.Key.Total,
//                         AccountValue = gc.Key.AccountValue,
//                         TradeStatus = gc.Key.TradeStatus,
//                     };
//        var p = result.ToList().OrderByDescending(x => x.DateTime).Take(1);
//        //var p = result.ToList();
//        var source = p;
//        MyAssetModel = _mapper.Map<List<MyAssetModel>>(source);
//    }
//    catch (Exception ex)
//    {
//        throw;
//    }

//    return MyAssetModel;
//}

//public List<MyAssetModel> GetMyAssetByUserID(string UserId, IMapper _mapper)
//{
//    //UserId = 2;
//    List<MyAssetModel> MyAssetModel = new List<MyAssetModel>();
//    try
//    {
//        var result = from Th in _Context.TradeHistories
//                     join s in _Context.Stocks on Th.StockId equals s.StockId
//                     join sp in _Context.StockPrices on s.StockId equals sp.StockId
//                     group Th by new
//                     {
//                         Th.TradeId,
//                         Th.UserId,
//                         Th.TransactionType,
//                         Th.RemainingQuantity,
//                         Th.Quantity,
//                         s.Symbol,
//                         s.CompanyName,
//                         Th.Price,
//                         Th.Commision,
//                         Th.Total,
//                         Th.AccountValue,
//                         Th.DateTime,
//                         Th.TradeStatus,
//                     } into gc
//                     where gc.Key.UserId.Equals(UserId) && gc.Key.TransactionType.Equals(false)

//                     select new
//                     {
//                         StockSymbol = gc.Key.Symbol,
//                         StockCompanyName = gc.Key.CompanyName,
//                         DateTime = gc.Key.DateTime,
//                         TransactionType = gc.Key.TransactionType,
//                         Quantity = gc.Key.Quantity,
//                         RemainingQuantity = gc.Key.RemainingQuantity,
//                         Price = gc.Key.Price,
//                         Commision = gc.Key.Commision,
//                         Total = gc.Key.Total,
//                         AccountValue = gc.Key.AccountValue,
//                         TradeStatus = gc.Key.TradeStatus,
//                     };
//        var p = result.ToList();
//        var source = p;
//        MyAssetModel = _mapper.Map<List<MyAssetModel>>(source);
//    }
//    catch (Exception ex)
//    {
//        throw;
//    }

//    return MyAssetModel;
//}
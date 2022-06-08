using System;
using System.Collections.Generic;
using System.Text;
using VirtualTrading.Model;
using System.IO;
using Google.Apis.Sheets.v4;
using Google.Apis.Auth.OAuth2;

namespace VirtualTrading.Common
{
    public class VTCommonStockPrice
    {
        static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static readonly string ApplicationName = "Current Legislators";
        static readonly string SpreadsheetId = "1IVF6wdrfDGetN92ZMXIPmg4PDJchdmCoUycUeDS4qII";
        static readonly string sheet = "Stock_Price";
        static SheetsService service;

        public List<StockpriceModel> GetAllStockPrice()
        {
            GoogleCredential credential;
            using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
            }

            // Create Google Sheet  API Service.

            service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            List<StockpriceModel> stockPrice =  ReadEnteries();

            return stockPrice;
        }

        private List<StockpriceModel> ReadEnteries()
        {
            var range = $"{sheet}!A2:G7";
            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);

            var response = request.Execute();
            var values = response.Values;
            List<StockpriceModel> StockpriceList = new List<StockpriceModel>();
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    var Stockprice = new StockpriceModel
                    {
                        StockSymbol = (string)row[0],
                        StockCompanyName = (string)row[1],
                        OpenMarket = Convert.ToDecimal(row[2]),
                        HighMarket = Convert.ToDecimal(row[3]),
                        LowMarket = Convert.ToDecimal(row[4]),
                        CloseMarket = Convert.ToDecimal(row[5]),
                        VolumeOfMarket = Convert.ToDecimal(row[6]),
                        Date = DateTime.Now,
                    };
                    StockpriceList.Add(Stockprice);
                }   
                }          
            else
            {
                Console.WriteLine("No Data was found!");
            }
           
            return StockpriceList;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualTrading.Model;
using System.Xml;
using VirtualTrading.Interface;

namespace VirtualTrading.API.Repository
{
    public class NewsRepository : INewsRepository
    {
        public List<News> GetNyseNews()
        {
            VirtualTrading.BAL.VTNewsBAL _bal = new BAL.VTNewsBAL();

            List<News> newsList = new List<News>();
            newsList = _bal.GetNyseNews();

            return newsList;
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualTrading.Model;

namespace VirtualTrading.Interface
{
    public interface INewsRepository
    {
        List<News> GetNyseNews();
    }
}
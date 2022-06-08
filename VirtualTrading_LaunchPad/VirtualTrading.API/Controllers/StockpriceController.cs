using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualTrading.DAL.Models;
using VirtualTrading.Interface;
using VirtualTrading.Model;

namespace VirtualTrading.API.Controllers
{
    [ApiController]
    //[EnableCors("AllowOrigin")]
    public class StockpriceController : ControllerBase
    {
        public IStockPriceRepository _repository;
        public IMapper _mapper;
        public StockpriceController(IStockPriceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        //[EnableCors("AllowOrigin")]
        [Route("api/GetAllStockPrice")]
        public  List<StockpriceModel> GetAllStockPrice()
        {
            try
            {
                // Get last day stock price
                DateTime dateParam = DateTime.Now.AddDays(-1);
                List<StockpriceModel> result = _repository.GetAllStockPrice(dateParam, _mapper);

                return result;                
            }
            catch (Exception ex)
            {
                throw; 
            }             
        }

        [HttpGet]
        //[EnableCors("AllowOrigin")]
        [Route("api/GetStockPriceByStockSymbol")]
        public decimal GetStockPriceByStockSymbol(string StockSymbol)
        {
            try
            {
                decimal result = _repository.GetStockPriceByStockSymbol(StockSymbol, _mapper);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

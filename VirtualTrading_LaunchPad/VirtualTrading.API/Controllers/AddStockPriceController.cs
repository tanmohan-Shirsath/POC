using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using VirtualTrading.Interface;
using VirtualTrading.Model;
using VirtualTrading.API.Models;
using Microsoft.Extensions.Logging;

namespace VirtualTrading.API.Controllers
{
   
    [ApiController]
    public class AddStockPriceController : ControllerBase
    {

        public ILogger _logger;

        public IStockPriceRepository _repository;
        public IMapper _mapper;
        public AddStockPriceController(IStockPriceRepository repository, IMapper mapper, ILogger logger)
        {   
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        // [EnableCors("AllowOrigin")]
        [Route("api/AddStockPrice")]        
        public bool AddStockPrice(DateTime date, decimal openMarket, decimal highMarket, decimal lowMarket, decimal closeMarket, decimal volumeOfMarket, string stockSymbol)
        {
            try
            {   
                bool result = _repository.AddStockPrice(date, openMarket, highMarket, lowMarket, closeMarket, volumeOfMarket, stockSymbol, _mapper);
               // _logger.LogCritical;


                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

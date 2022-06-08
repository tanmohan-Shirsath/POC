using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using VirtualTrading.Interface;
using VirtualTrading.Model;
using VirtualTrading.API.Models;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Http;

namespace VirtualTrading.API.Controllers
{
    [ApiController]
    //[EnableCors("AllowOrigin")]
    public class BuySaleController : ControllerBase
    {
        public IBuySaleStock _repository;
        public IMapper _mapper;
        private IConfiguration configuration;
        public BuySaleController(IBuySaleStock repository, IMapper mapper, IConfiguration iconfig)
        {
            _repository = repository;
            _mapper = mapper;
            configuration = iconfig;
        }

        [HttpPost]
       // [EnableCors("AllowOrigin")]
        [Route("api/PostBuySaleStockByUserID")]
        //public bool BuyNewStockByUserID([FromBody] BuySale model)
        public bool BuyNewStockByUserID(string UserId, string StockSymbol, decimal Price,  decimal Quantity, decimal Total, string TransactionType)
        {
            DateTime datetime = DateTime.Now;
            bool boolTransactionType = false;
            string FromEmail = configuration.GetSection("EmailSettings").GetSection("From").Value;
            string UserEmail = configuration.GetSection("EmailSettings").GetSection("UserEmail").Value;
            string UserPassword = configuration.GetSection("EmailSettings").GetSection("UserPassword").Value;
            string SMTPServer = configuration.GetSection("EmailSettings").GetSection("SMTPServer").Value;

            if (TransactionType == "Buy")
            {
                boolTransactionType = true;
            }
            else
            {
                boolTransactionType = false;
             }

            try
            {
                decimal Commision = 2;
                //bool result = _repository.BuyNewStockByUserID(model.UserId, model.StockSymbol, model.Price, Commision, model.Quantity, model.Total, TransactionType, model.datetime, _mapper);
                bool result = _repository.BuyNewStockByUserID(UserId, StockSymbol, Price, Commision, Quantity, Total, boolTransactionType, datetime, FromEmail, UserEmail, UserPassword, SMTPServer, _mapper);

                //return Request.CreateResponse(HttpStatusCode.BadRequest, myError);

                //return HttpResponseMessage
                 return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

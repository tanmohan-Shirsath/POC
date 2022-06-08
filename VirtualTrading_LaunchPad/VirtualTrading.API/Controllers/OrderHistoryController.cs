using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using VirtualTrading.Interface;
using VirtualTrading.Model;

namespace VirtualTrading.API.Controllers
{
    [ApiController]
    //[EnableCors("AllowOrigin")]
    public class OrderHistoryController : ControllerBase
    {
        public IOrderHistory _repository;
        public IMapper _mapper;
        public OrderHistoryController(IOrderHistory repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        //[EnableCors("AllowOrigin")]
        [Route("api/GetOrderHistoryByUserID")]
        public List<OrderHistoryModel> GetOrderHistoryByUserID(string UserId)
        {
            try
            {
                List<OrderHistoryModel> result = _repository.GetOrderHistoryByUserID(UserId, _mapper);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

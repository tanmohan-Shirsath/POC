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
   // [EnableCors("AllowOrigin")]
    public class MyAssetController : ControllerBase
    {
        public IMyAssest _repository;
        public IMapper _mapper;
        public MyAssetController(IMyAssest repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        //[EnableCors("AllowOrigin")]
        [Route("api/GetMyAssestByUserID")]
        public List<MyAssetModel> GetMyAssestByUserID(string UserId)
        {
            try
            {
                List<MyAssetModel> result = _repository.GetMyAssestByUserID(UserId, _mapper);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("api/GetUserBalanceByUserID")]
        public decimal GetUserBalanceByUserID(string UserId)
        {
            try
            {
                decimal result = _repository.GetUserBalanceByUserID(UserId);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

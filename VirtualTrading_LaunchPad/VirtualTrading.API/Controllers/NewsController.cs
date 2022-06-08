using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using VirtualTrading.Interface;
using VirtualTrading.Model;

namespace VirtualTrading.API.Controllers
{    
    [ApiController]
    //[EnableCors("AllowOrigin")]
    public class NewsController : ControllerBase
    {
        public INewsRepository _repository;
        public NewsController(INewsRepository repository)
        {
            _repository = repository;
        }
          
        [HttpGet]
        //[EnableCors("AllowOrigin")]
        [Route("api/GetNyseNews")]
        public List<News> Get()        
        {
            return _repository.GetNyseNews();

        }

    }
}

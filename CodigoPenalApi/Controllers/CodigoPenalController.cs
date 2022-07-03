using CodigoPenalApi.Models;
using CodigoPenalApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodigoPenalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodigoPenalController : ControllerBase
    {
        private ICodigoPenalService _CPService;

        public CodigoPenalController(ICodigoPenalService CPService)
        {
            _CPService = CPService;
        }
        
    }
}

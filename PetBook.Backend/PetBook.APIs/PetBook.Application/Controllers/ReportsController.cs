using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetBook.Services.ReportsServices;

namespace PetBook.Application.Controllers
{
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsService _reportsService;

        public ReportsController(IReportsService reportsService)
        {
            _reportsService = reportsService;
        }

        [HttpGet("report/")]
        public async Task<IActionResult> GetReport()
        {
            try
            {
                return Ok(_reportsService.GenerateReport().Result.Content);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetBook.Domain.PetsDomain;
using PetBook.Services.PetsServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetBook.Application.Controllers
{
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly ILogger<PetsController> _logger;
        private readonly IPetService _petService;

        public PetsController(ILogger<PetsController> logger, IPetService petService)
        {
            _logger = logger;
            _petService = petService;
        }

        [HttpGet("pets/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try {
                return Ok(await _petService.GetPet(id));
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
            
        }

        [HttpGet("pets/")]
        public async Task<IActionResult> GetAll()
        {
            try {
                return Ok(await _petService.GetAll());
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("pets/")]
        public async Task<IActionResult> Post([FromBody]Pet pet)
        {
            try {
                await _petService.AddPet(pet);
                return Ok();
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("pets/")]
        [Authorize]
        public async Task<IActionResult> Delete()
        {
            try {
                await _petService.DeleteAll();
                return Ok("All pets were deleted successfully");
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}

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
    /// <summary>
    /// Controller responsable to implement all endpoints related to pets API
    /// </summary>
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        /// <summary>
        /// Return certain pet depending on the ID
        /// </summary>
        /// <param name="id">Pet ID</param>
        /// <returns></returns>
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

        
        /// <summary>
        /// Add a pet to the database
        /// </summary>
        /// <param name="pet">Pet object</param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete all pets from the database
        /// </summary>
        /// <returns></returns>
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

        /* 
         * Exercício 1: Criar o endpoint que atualiza a idade do pet
         1. Anotações na classe
         2. Receber os parâmetros no body
         3. Usar o serviço (IPetService) para fazer o update - UpdatePetAge
         4. Usar o postman para fazer o update de um PET
         */

        //public async Task<IActionResult> Update()
        //{
        //    try {

        //    }
        //    catch (Exception e) {
        //    }
        //}


        /*
         * Exerício 2: Colocar autorização na API que retorna todos os PETS
         * 1. 
         * 
         */

        /// <summary>
        /// Return all pets from the database
        /// </summary>
        /// <returns></returns>
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
    }
}

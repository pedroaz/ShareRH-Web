using PetBook.Domain.PetsDomain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetBook.Services.PetsServices
{
    public interface IPetService
    {
        /// <summary>
        /// Delete all pets from the database
        /// </summary>
        /// <returns></returns>
        Task DeleteAll();

        /// <summary>
        /// Add a pet to the database
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>
        Task AddPet(Pet pet);

        /// <summary>
        /// Returns a pet using the pet ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Pet> GetPet(int id);

        /// <summary>
        /// Returns all pets from the database
        /// </summary>
        /// <returns></returns>
        Task<List<Pet>> GetAll();

        /// <summary>
        /// Update a pet age depending on its name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        Task UpdatePetAge(string name, int age);
    }
}

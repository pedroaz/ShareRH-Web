using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PetBook.Domain.PetsDomain
{
    /// <summary>
    /// Pet model class
    /// </summary>
    public class Pet
    {
        /// <summary>
        /// Pet ID - Primary Key on the database
        /// </summary>
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Pet names
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// Age of the pet
        /// </summary>
        [Column("age")]
        public int Age { get; set; }

        /// <summary>
        /// Inially the pets were going to have photos, but I'm kind of lazy so I didn't do it. Sorry :(
        /// </summary>
        [Column("photoId")]
        public int PhotoId { get; set; }
    }
}

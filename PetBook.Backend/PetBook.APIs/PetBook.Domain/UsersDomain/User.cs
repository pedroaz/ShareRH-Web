using PetBook.Domain.PetsDomain;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetBook.Domain.UsersDomain
{
    /// <summary>
    /// Representation on the database of a user
    /// </summary>
    [Table("Users")]
    public class User
    {
        /// <summary>
        /// User id - Primary Key
        /// </summary>
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// User Name
        /// </summary>
        [Column("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// User passowrd
        /// </summary>
        [Column("password")]
        public string Password { get; set; }

        /// <summary>
        /// Role that the user can execute actions
        /// </summary>
        [Column("role")]
        public string Role { get; set; }
    }
}

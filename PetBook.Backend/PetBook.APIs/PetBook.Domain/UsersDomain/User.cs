using PetBook.Domain.PetsDomain;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetBook.Domain.UsersDomain
{
    [Table("Users")]
    public class User
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }
        
        [Column("password")]
        public string Password { get; set; }

        [Column("role")]
        public string Role { get; set; }
    }
}

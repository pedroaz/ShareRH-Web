using System;
using System.Collections.Generic;
using System.Text;

namespace PetBook.Domain.UsersDomain
{
    /// <summary>
    /// Login data used on login request
    /// </summary>
    public class LoginData
    {
        /// <summary>
        /// The user name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The user password
        /// </summary>
        public string Password { get; set; }
    }
}

using LST.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LST.Model.Model
{
    public class User : EntityBase
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? PasswordSalt { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
    }
}

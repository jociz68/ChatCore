using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Model
{
    public class User
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}

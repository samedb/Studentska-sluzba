using System;
using System.Collections.Generic;

namespace StudentskaSluzba.Models
{
    public partial class Korisnik
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Usertype { get; set; }

        public virtual Referent Referent { get; set; }
    }
}

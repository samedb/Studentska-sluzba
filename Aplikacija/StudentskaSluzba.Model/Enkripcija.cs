using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace StudentskaSluzba.Model
{
    public class Enkripcija
    {
        public static string Enkriptuj(string ulaz)
        {
            using (var sha256 = new SHA256CryptoServiceProvider())
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(ulaz);
                byte[] encrypted = sha256.ComputeHash(byteArray);
                return Encoding.ASCII.GetString(encrypted);
            }
        }
    }
}

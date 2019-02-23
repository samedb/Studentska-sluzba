using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentskaSluzba.Model.Models
{

    /// <summary>
    /// Ova klasa se kosriti u IspitAddViewModel, korsti se za
    /// ListView koji ima naziv isipta i ocenu
    /// </summary>
    public class IspitOcena
    {
        public Ispit Ispit { get; set; }

        private int ocena;
        public int Ocena
        {
            get { return ocena; }
            set
            {
                if (value < 6 || value > 10)
                    ocena = 5;
                else
                    ocena = value;
            }
        }

        public IspitOcena(Ispit ispit, int ocena)
        {
            Ispit = ispit;
            Ocena = ocena;
        }
    }
}

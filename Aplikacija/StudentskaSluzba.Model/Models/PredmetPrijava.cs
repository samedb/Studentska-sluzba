using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentskaSluzba.Model.Models
{
    // Ova klasa se koristi kod IspitiAddViewModel i sluzi da bi se 
    // predstavili elementi u listView, ima referencu na predmet i bool prijavljen
    public class PredmetPrijava
    {
        public Predmet Predmet { get; set; }
        public bool Prijavljen { get; set; }

        public PredmetPrijava(Predmet predmet, bool prijavljen)
        {
            Predmet = predmet;
            Prijavljen = prijavljen;
        }
    }
}

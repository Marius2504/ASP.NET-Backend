using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities
{
    public class Adresa
    {
        public int Id { get; set; }
        public string Judet { get; set; }
        public string Oras { get; set; }
        public string Strada { get; set; }
        public Gym Gyms { get; set; }
        public int GymId { get; set; }

    }
}

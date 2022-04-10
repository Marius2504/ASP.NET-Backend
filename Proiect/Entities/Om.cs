using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities
{
    public class Om
    {
        public int Id { get; set; }
        public int Varsta { get; set; }
        public string Nume { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public Antrenor Antrenors { get; set; }
        public Gym Gyms { get; set; }

    }
}

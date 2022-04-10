using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities
{
    public class Antrenor
    {
        public int Id { get; set; }
        public int varsta { get; set; }
        public string telefon { get; set; }
        public string Nume { get; set; }
        public string Email { get; set; }
        public string Optiuni { get; set; }
        public int OmId { get; set; }
        public ICollection<Om> Oms { get; set; }
        public ICollection<AntrenorGym> AntrenorGyms { get; set; }

    }
}

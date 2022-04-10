using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities.DTOs
{
    public class CreateAntrenorDTO
    {
        public int varsta { get; set; }
        public string telefon { get; set; }
        public string Nume { get; set; }
        public string Email { get; set; }
        public string Optiuni { get; set; }
        public int OmId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plata.Model
{
    class Plata
    {
        public long id { get; set; }
        public int brutoPlata { get; set; }
        public long firmaId { get; set; }
        public Firma firma { get; set; }
        public DateTime mesecPlata { get; set; }
        public int netoPlata { get; set; }
    }
}

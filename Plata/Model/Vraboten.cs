using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plata.Model
{
    class Vraboten
    {
        public Vraboten()
        {
        }

        public Vraboten(string ime, DateTime datumPriem, DateTime? datumOtkaz, string pol, string embg, string adresa, string opstina, string transakciskaSmetka, string podracnaEdinica, string email, int brutoPlata, int netoPlata, String sifra, int skrateno, long firmaId )
        {
            this.ime = ime;
            this.datumPriem = datumPriem;
            this.datumOtkaz = datumOtkaz;
            this.pol = pol;
            this.embg = embg;
            this.adresa = adresa;
            this.opstina = opstina;
            this.transakciskaSmetka = transakciskaSmetka;
            this.podracnaEdinica = podracnaEdinica;
            this.email = email;
            this.brutoPlata = brutoPlata;
            this.netoPlata = netoPlata;
            this.sifra = sifra;
            this.skrateno = skrateno;
            this.firmaId = firmaId;
        }
        [Key]
        public long id { get; set; }
        public String ime { get; set; }
        public DateTime datumPriem { get; set; }
        public DateTime? datumOtkaz{ get; set; }
        public String pol{ get; set; }
        public String embg { get; set; }
        public String adresa{ get; set; }
        public String opstina { get; set; }
        public String transakciskaSmetka { get; set; }
        public String podracnaEdinica { get; set; }
        public String email { get; set; }
        public int brutoPlata { get; set; }
        public int netoPlata { get; set; }
        public String sifra { get; set; }
        public int skrateno { get; set; }
        public long firmaId { get; set; }
        public Firma firma { get; set; }
    }
}

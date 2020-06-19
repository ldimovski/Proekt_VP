using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plata.Model
{
    class Firma
    {
        public Firma() { }
        public Firma(string ime, string adresa, string naselenoMesto, string opstina, string telefon, string email, string dejnost, string ziroSmetka, string edb, string posta, string broj, string grad, string povBroj, string faks, bool minTrud, bool odBruto, bool zastita)
        {
            //this.id = id;
            this.ime = ime;
            this.adresa = adresa;
            this.naselenoMesto = naselenoMesto;
            this.opstina = opstina;
            this.telefon = telefon;
            this.email = email;
            this.dejnost = dejnost;
            this.ziroSmetka = ziroSmetka;
            this.edb = edb;
            this.posta = posta;
            this.broj = broj;
            this.grad = grad;
            this.povBroj = povBroj;
            this.faks = faks;
            this.minTrud = minTrud;
            this.odBruto = odBruto;
            this.zastita = zastita;
        }

        public long id { get; set; }
        public String ime { get; set; }
        public String adresa { get; set; }
        public String naselenoMesto { get; set; }
        public String opstina { get; set; }
        public String telefon { get; set; }
        public String email { get; set; }
        public String dejnost { get; set; }
        public String ziroSmetka { get; set; }
        public String edb { get; set; }
        public String posta { get; set; }
        public String broj { get; set; }
        public String grad { get; set; }
        public String povBroj { get; set; }
        public String faks { get; set; }
        public bool minTrud { get; set; }
        public bool odBruto { get; set; }
        public bool zastita { get; set; }

        

    }
}

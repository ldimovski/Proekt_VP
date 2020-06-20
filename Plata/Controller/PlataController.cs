using Plata.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plata.Controller
{
    class PlataController
    {
        
        public static void calculateDays(DateTimePicker dateTimePicker3, Label lblDenovi)
        {
            DateTime data = dateTimePicker3.Value;
            int year = data.Year;
            int month = data.Month;
            lblDenovi.Text = DateTime.DaysInMonth(year, month).ToString();
        }
        
        public static void workingHours(Label workingDays, Label lblHours)
        {
            int days = int.Parse(workingDays.Text);
            int hours = days * 8;
            lblHours.Text = hours.ToString();
        }

        public static int returnNetoPlata(int brutoPlata) {
            return (int)(brutoPlata * (67.5 / 100));
        }

        public static int returnBrutoPlata(int netoPlata)
        {
            return (int)(netoPlata / (67.5/100));
        }

        public static String generate(long temp)
        {
            List<Vraboten> vraboteni = VrabotenController.getVraboteniFromFirmaId(temp);
            Firma firma = FirmaController.GetFirmaById(temp);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(firma.ime + " - " + firma.edb);
            sb.AppendLine("Ime;DatumPriem;EMBG;TransakciskaSmetka;BrutoPlata");
            foreach(Vraboten v in vraboteni)
            {
                DateTime date = v.datumPriem;
                sb.AppendLine(v.ime + ";" + date.ToString("MM/dd/yyyy") + ";" + v.embg + ";" + v.transakciskaSmetka + ";" + v.brutoPlata);
            }
            String finalStr = sb.ToString();
            return finalStr;
        }

        public static int vkupnoTrosoci(long temp)
        {
            int suma = 0;
            List<Vraboten> vraboteni = VrabotenController.getVraboteniFromFirmaId(temp);
            foreach(Vraboten v in vraboteni)
            {
                suma += v.brutoPlata;
            }
            return suma;
        }
       
    }
}

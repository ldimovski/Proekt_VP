using Plata.Model;
using Plata.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plata.Controller
{
    class VrabotenController
    {
        static DataContext db = new DataContext();

        public static List<Vraboten> getVraboteniFromFirmaId(long id)
        {
            Firma firma = db.firmi.SingleOrDefault(f => f.id == id);
            List<Vraboten> vraboteni = db.vraboteni.ToList().FindAll(v => v.firmaId == firma.id);
            return vraboteni;
        }

        internal static void Save(TextBox txtFirmaId, TextBox txtImePrezime, ComboBox cmbPol, TextBox txtEmbg, TextBox txtAdresa2, ComboBox cmbOpstina, TextBox txtTransak, ComboBox cmbPodracna, TextBox txtEmail2, TextBox txtBruto, TextBox txtNeto, ComboBox cmbSifra, TextBox txtSkrateno, DateTimePicker dateTimePicker1, CheckBox chbOtkaz, DateTimePicker dateTimePicker2)
        {
            String pol = cmbPol.SelectedItem.ToString();
            String opstina = cmbOpstina.SelectedItem.ToString();
            String podracna = cmbPodracna.SelectedItem.ToString();
            String sifra = cmbSifra.SelectedItem.ToString();
            DateTime? date2 = null;
            if (chbOtkaz.Checked) {
                date2 = dateTimePicker2.Value;
            }
            long id = long.Parse(txtFirmaId.Text);
            Firma firma = FirmaController.GetFirmaById(id);
            DateTime date1 = dateTimePicker1.Value;
            Vraboten vraboten = new Vraboten(txtImePrezime.Text, date1, date2, pol, txtEmbg.Text, txtAdresa2.Text, opstina, txtTransak.Text, podracna, txtEmail2.Text, int.Parse(txtBruto.Text), int.Parse(txtNeto.Text), sifra, int.Parse(txtSkrateno.Text), firma.id);
            db.vraboteni.Add(vraboten);
            db.SaveChanges();
        }


        public static Vraboten getVrabotenById(long id)
        {
            return db.vraboteni.SingleOrDefault(c => c.id == id);
        }

        public static void deleteVrabotenById(long id)
        {
            Vraboten vraboten= db.vraboteni.SingleOrDefault(c => c.id == id);
            db.vraboteni.Remove(vraboten);
            db.SaveChanges();
        }

        internal static void Update(TextBox txtFirmaId, TextBox txtImePrezime, ComboBox cmbPol, TextBox txtEmbg, TextBox txtAdresa2, ComboBox cmbOpstina, TextBox txtTransak, ComboBox cmbPodracna, TextBox txtEmail2, TextBox txtBruto, TextBox txtNeto, ComboBox cmbSifra, TextBox txtSkrateno, DateTimePicker dateTimePicker1, CheckBox chbOtkaz, DateTimePicker dateTimePicker2,  TextBox txtVrabotenId)
        {
            String pol = cmbPol.SelectedItem.ToString();
            String opstina = cmbOpstina.SelectedItem.ToString();
            String podracna = cmbPodracna.SelectedItem.ToString();
            String sifra = cmbSifra.SelectedItem.ToString();
            long vrabId = long.Parse(txtVrabotenId.Text);
            Vraboten vraboten = db.vraboteni.SingleOrDefault(v => v.id == vrabId);
            vraboten.ime = txtImePrezime.Text;
            vraboten.adresa = txtAdresa2.Text;
            vraboten.pol = pol;
            vraboten.embg = txtEmbg.Text;
            vraboten.opstina = opstina;
            vraboten.transakciskaSmetka = txtTransak.Text;
            vraboten.podracnaEdinica = podracna;
            vraboten.email = txtEmail2.Text;
            vraboten.brutoPlata = int.Parse(txtBruto.Text);
            vraboten.netoPlata = int.Parse(txtNeto.Text);
            vraboten.sifra = sifra;
            vraboten.skrateno = int.Parse(txtSkrateno.Text);
            vraboten.datumPriem = dateTimePicker1.Value;
            if (chbOtkaz.Checked)
            {
                vraboten.datumOtkaz = (DateTime)dateTimePicker2.Value;
            }
            else
            {
                vraboten.datumOtkaz = null;
            }
            db.SaveChanges();
        }
    }
}

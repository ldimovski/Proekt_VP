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
    class FirmaController
    {

        static DataContext db = new DataContext();

        public static void Update(TextBox txtId ,TextBox txtIme, TextBox txtAdresa, TextBox txtMesto, ComboBox cmbOpstina, TextBox txtTelefon,
               TextBox txtEmail, TextBox txtDejnost, TextBox txtZiroSmetka, TextBox txtEdb, TextBox txtPosta, TextBox txtBroj, TextBox txtGrad,
              TextBox txtPovBroj, TextBox txtFaks, RadioButton rbMinatTrudDa, RadioButton rbOdBrutoDa,
               RadioButton rbZastitaDa)
        {
            long id = long.Parse(txtId.Text);
            Firma firma = db.firmi.SingleOrDefault(c => c.id == id);
            firma.ime = txtIme.Text;
            firma.adresa = txtAdresa.Text;
            firma.naselenoMesto = txtMesto.Text;
            firma.opstina = cmbOpstina.SelectedItem.ToString();
            firma.telefon = txtTelefon.Text;
            firma.email = txtEmail.Text;
            firma.dejnost = txtDejnost.Text;
            firma.ziroSmetka = txtZiroSmetka.Text;
            firma.edb = txtEdb.Text;
            firma.posta = txtPosta.Text;
            firma.broj = txtBroj.Text;
            firma.grad = txtGrad.Text;
            firma.povBroj = txtPovBroj.Text;
            firma.faks = txtFaks.Text;
            if (rbMinatTrudDa.Checked)
            {
                firma.minTrud = true;
            }
            else
            {
                firma.minTrud = false;
            }
            if (rbZastitaDa.Checked)
            {
                firma.zastita = true;
            }
            else
            {
                firma.zastita = false;
            }
            if (rbOdBrutoDa.Checked)
            {
                firma.odBruto = true;
            }
            else
            {
                firma.odBruto = false;
            }


            db.SaveChanges();
        }
        public static void Save(TextBox txtIme, TextBox txtAdresa, TextBox txtMesto, ComboBox cmbOpstina, TextBox txtTelefon,
               TextBox txtEmail, TextBox txtDejnost, TextBox txtZiroSmetka, TextBox txtEdb, TextBox txtPosta, TextBox txtBroj, TextBox txtGrad,
              TextBox txtPovBroj, TextBox txtFaks, RadioButton rbMinatTrudDa, RadioButton rbOdBrutoDa,
               RadioButton rbZastitaDa)
        {
            //text.Text = "Aaaa";
            bool minTrud = false, zastita = false, odBruto = false;

            if (rbMinatTrudDa.Checked)
            {
                minTrud = true;
            }
            if (rbZastitaDa.Checked)
            {
                zastita = true;
            }
            if(rbOdBrutoDa.Checked)
            {
                odBruto = true;
            }
                Firma firma = new Firma(txtIme.Text, txtAdresa.Text, txtMesto.Text, cmbOpstina.SelectedItem.ToString(), txtTelefon.Text,
                txtEmail.Text, txtDejnost.Text, txtZiroSmetka.Text, txtEdb.Text, txtPosta.Text, txtBroj.Text, txtGrad.Text,
                txtPovBroj.Text, txtFaks.Text, minTrud, odBruto, zastita);

                db.firmi.Add(firma);
                db.SaveChanges();


        }

        public static List<Firma> getFirmi()
        {
            return db.firmi.ToList();
        }

        public static Firma GetFirmaById (long id)
        {
            Firma firma = db.firmi.SingleOrDefault(c => c.id == id);
            return firma;
        }

        public static void DeleteById (long id)
        {
            Firma firma = db.firmi.SingleOrDefault(c => c.id == id);
            db.firmi.Remove(firma);
            db.SaveChanges();
        }

    }   
}

using Plata.Controller;
using Plata.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Plata
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadComboBox();
        }

        public void LoadComboBox()
        {
            cmbFirmi.DataSource = FirmaController.getFirmi();
            cmbFirmi.DisplayMember = "ime";
            cmbFirmi.ValueMember = "id";

            cmbFirmi.SelectedIndex = -1;
        }
        private void Save(object sender, EventArgs e)
        {

           
            if(cmbFirmi.SelectedIndex == -1)
            {
                if (txtIme.Text != "" && txtAdresa.Text != "" && txtMesto.Text != "" && txtOpstina.Text != "" && txtTelefon.Text != ""
                && txtEmail.Text != "" && txtTelefon.Text != "" && txtDejnost.Text != "" && txtZiroSmetka.Text != "" &&
                txtEdb.Text != "" && txtPosta.Text != "" && txtBroj.Text != "" && txtGrad.Text != "" && txtPovBroj.Text != "" &&
                txtFaks.Text != "")
                {
                    if ((rbMinatTrudDa.Checked || rbMinatTrudNe.Checked) && (rbZastitaDa.Checked || rbZastitaNe.Checked) &&
                        (rbOdBrutoDa.Checked || rbOdBrutoNe.Checked))


                        FirmaController.Save(txtIme, txtAdresa, txtMesto, txtOpstina, txtTelefon,
                        txtEmail, txtDejnost, txtZiroSmetka, txtEdb, txtPosta, txtBroj, txtGrad,
                        txtPovBroj, txtFaks, rbMinatTrudDa, rbOdBrutoDa, rbZastitaDa);
                    
                }


            }
            else
            {
                if (txtIme.Text != "" && txtAdresa.Text != "" && txtMesto.Text != "" && txtOpstina.Text != "" && txtTelefon.Text != ""
                && txtEmail.Text != "" && txtTelefon.Text != "" && txtDejnost.Text != "" && txtZiroSmetka.Text != "" &&
                txtEdb.Text != "" && txtPosta.Text != "" && txtBroj.Text != "" && txtGrad.Text != "" && txtPovBroj.Text != "" &&
                txtFaks.Text != "")
                {
                    if ((rbMinatTrudDa.Checked || rbMinatTrudNe.Checked) && (rbZastitaDa.Checked || rbZastitaNe.Checked) &&
                        (rbOdBrutoDa.Checked || rbOdBrutoNe.Checked))


                        FirmaController.Update(txtId, txtIme, txtAdresa, txtMesto, txtOpstina, txtTelefon,
                        txtEmail, txtDejnost, txtZiroSmetka, txtEdb, txtPosta, txtBroj, txtGrad,
                        txtPovBroj, txtFaks, rbMinatTrudDa, rbOdBrutoDa, rbZastitaDa);

                }
            }
            Clear();
            LoadComboBox();


        }

        public void Clear()
        {
            txtIme.Clear();
            txtAdresa.Clear();
            txtMesto.Clear();
            txtOpstina.Clear();
            txtTelefon.Clear();
            txtEmail.Clear();
            txtDejnost.Clear();
            txtZiroSmetka.Clear();
            txtEdb.Clear();
            txtPosta.Clear();
            txtBroj.Clear();
            txtGrad.Clear();
            txtPovBroj.Clear();
            txtFaks.Clear();
            rbMinatTrudDa.Checked = false;
            rbMinatTrudNe.Checked = false;
            rbZastitaDa.Checked = false;
            rbZastitaNe.Checked = false;
            rbOdBrutoDa.Checked = false;
            rbOdBrutoNe.Checked = false;
            LoadComboBox();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnOdberi_Click(object sender, EventArgs e)
        {

            if(cmbFirmi.SelectedIndex != -1)
            {
                long temp = (long)cmbFirmi.SelectedValue;
                Firma firma = FirmaController.GetFirmaById(temp);

                txtIme.Text = firma.ime;
                txtAdresa.Text = firma.adresa;
                txtMesto.Text = firma.naselenoMesto;
                txtOpstina.Text = firma.opstina;
                txtTelefon.Text = firma.telefon;
                txtEmail.Text = firma.email;
                txtDejnost.Text = firma.dejnost;
                txtZiroSmetka.Text = firma.ziroSmetka;
                txtEdb.Text = firma.edb;
                txtPosta.Text = firma.posta;
                txtBroj.Text = firma.broj;
                txtGrad.Text = firma.grad;
                txtPovBroj.Text = firma.povBroj;
                txtFaks.Text = firma.faks;
                txtId.Text = firma.id.ToString();

                if (firma.minTrud)
                {
                    rbMinatTrudDa.Checked = true;
                }
                else
                {
                    rbMinatTrudNe.Checked = true;
                }

                if (firma.zastita)
                {
                    rbZastitaDa.Checked = true;
                }
                else
                {
                    rbZastitaNe.Checked = true;
                }

                if (firma.odBruto)
                {
                    rbOdBrutoDa.Checked = true;
                }
                else
                {
                    rbOdBrutoNe.Checked = true;
                }

            }

        }

        private void btnIzbrisi_Click(object sender, EventArgs e)
        {
            long temp = (long)cmbFirmi.SelectedValue;
            FirmaController.DeleteById(temp);
            LoadComboBox();
        }


    }
}

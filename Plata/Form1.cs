using Plata.Controller;
using Plata.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            dateTimePicker3.CustomFormat = "MMMM yyyy";
            PlataController.calculateDays(dateTimePicker3, lblDenovi);
            PlataController.workingHours(lblRabotni, lblSaati);
        }

        public void LoadComboBox()
        {
            cmbFirmi.DataSource = FirmaController.getFirmi();
            cmbFirmi.DisplayMember = "ime";
            cmbFirmi.ValueMember = "id";
            cmbFirmi.SelectedIndex = -1;

            cmbFirmi2.DataSource = FirmaController.getFirmi();
            cmbFirmi2.DisplayMember = "ime";
            cmbFirmi2.ValueMember = "id";
            cmbFirmi2.SelectedIndex = -1;

            cmbFirmi3.DataSource = FirmaController.getFirmi();
            cmbFirmi3.DisplayMember = "ime";
            cmbFirmi3.ValueMember = "id";
            cmbFirmi3.SelectedIndex = -1;
        }


        private void Save(object sender, EventArgs e)
        {
            if (cmbFirmi.SelectedIndex == -1)
            {
                if (txtIme.Text != "" && txtAdresa.Text != "" && txtMesto.Text != "" && cmbOpstinaFirma.SelectedIndex != -1 && txtTelefon.Text != ""
                && txtEmail.Text != "" && txtTelefon.Text != "" && txtDejnost.Text != "" && txtZiroSmetka.Text != "" &&
                txtEdb.Text != "" && txtPosta.Text != "" && txtBroj.Text != "" && txtGrad.Text != "" && txtPovBroj.Text != "" &&
                txtFaks.Text != "")
                {
                    if ((rbMinatTrudDa.Checked || rbMinatTrudNe.Checked) && (rbZastitaDa.Checked || rbZastitaNe.Checked) &&
                        (rbOdBrutoDa.Checked || rbOdBrutoNe.Checked))
                    {
                        FirmaController.Save(txtIme, txtAdresa, txtMesto, cmbOpstinaFirma, txtTelefon,
                        txtEmail, txtDejnost, txtZiroSmetka, txtEdb, txtPosta, txtBroj, txtGrad,
                        txtPovBroj, txtFaks, rbMinatTrudDa, rbOdBrutoDa, rbZastitaDa);
                        errorProvider1.SetError(button3, "");
                        Clear();
                        LoadComboBox();
                    }
                    else
                    {
                        errorProvider1.SetError(button3, "Сите полиња се задолжителни");
                    }

                }
                else
                {
                    errorProvider1.SetError(button3, "Сите полиња се задолжителни!");
                }


            }
            else
            {
                if (txtIme.Text != "" && txtAdresa.Text != "" && txtMesto.Text != "" && cmbOpstinaFirma.SelectedIndex != -1 && txtTelefon.Text != ""
                && txtEmail.Text != "" && txtTelefon.Text != "" && txtDejnost.Text != "" && txtZiroSmetka.Text != "" &&
                txtEdb.Text != "" && txtPosta.Text != "" && txtBroj.Text != "" && txtGrad.Text != "" && txtPovBroj.Text != "" &&
                txtFaks.Text != "")
                {
                    if ((rbMinatTrudDa.Checked || rbMinatTrudNe.Checked) && (rbZastitaDa.Checked || rbZastitaNe.Checked) &&
                        (rbOdBrutoDa.Checked || rbOdBrutoNe.Checked))
                    {
                        FirmaController.Update(txtId, txtIme, txtAdresa, txtMesto, cmbOpstinaFirma, txtTelefon,
                        txtEmail, txtDejnost, txtZiroSmetka, txtEdb, txtPosta, txtBroj, txtGrad,
                        txtPovBroj, txtFaks, rbMinatTrudDa, rbOdBrutoDa, rbZastitaDa);
                        Clear();
                        LoadComboBox();
                    }

                }
            }
            


        }

        public void Clear()
        {
            txtIme.Clear();
            txtAdresa.Clear();
            txtMesto.Clear();
            cmbOpstinaFirma.SelectedIndex = -1;
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
            if (cmbFirmi.SelectedIndex == -1)
            {
                MessageBox.Show("Не е селектирана фирма");
                return;
            }

            if (cmbFirmi.SelectedIndex != -1)
            {
                long temp = (long)cmbFirmi.SelectedValue;
                Firma firma = FirmaController.GetFirmaById(temp);

                txtIme.Text = firma.ime;
                txtAdresa.Text = firma.adresa;
                txtMesto.Text = firma.naselenoMesto;
                //txtOpstina.Text = firma.opstina;
                cmbOpstinaFirma.SelectedItem = firma.opstina;
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

            if (cmbFirmi.SelectedIndex == -1)
            {
                MessageBox.Show("Не е селектирана фирма");
                return;
            }
            long temp = (long)cmbFirmi.SelectedValue;
            FirmaController.DeleteById(temp);
            cmbFirmi.SelectedIndex = -1;
            Clear();
            Clear2();
            Clear3();
        }

        private void btnOdberi2_Click(object sender, EventArgs e)
        {
            if(cmbFirmi2.SelectedIndex == -1)
            {
                MessageBox.Show("Ве молиме изберете фирма!");
            }
            else
            {
                long temp = (long)cmbFirmi2.SelectedValue;
                //Fill the listbox
                loadListBox(temp);
                Firma firma = FirmaController.GetFirmaById(temp);
                txtFirmaId.Text = firma.id.ToString();
                //Add new vraboteni
            }

        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            if (cmbFirmi2.SelectedIndex == -1)
            {
                MessageBox.Show("Не е селектирана фирма");
                return;
            }

            if(txtVrabotenId.Text == "")
            {
                if (txtImePrezime.Text != "" && cmbPol.SelectedIndex != -1 && txtEmbg.Text != "" && txtAdresa2.Text != "" && cmbOpstina.SelectedIndex != -1 && txtTransak.Text != ""
               && cmbPodracna.SelectedIndex != -1 && txtEmail2.Text != "" && txtBruto.Text != "" && txtNeto.Text != "" && cmbSifra.SelectedIndex != -1 && txtSkrateno.Text != "")
                {
                    VrabotenController.Save(txtFirmaId, txtImePrezime, cmbPol, txtEmbg, txtAdresa2, cmbOpstina, txtTransak, cmbPodracna, txtEmail2, txtBruto,
                        txtNeto, cmbSifra, txtSkrateno, dateTimePicker1, chbOtkaz, dateTimePicker2);

                    errorProvider1.SetError(button7, "");
                    Clear2();
                    long temp = (long)cmbFirmi2.SelectedValue;
                    loadListBox(temp);
                }
                else
                {
                    errorProvider1.SetError(button7, "Сите полиња се задолжителни!");
                }
            }
            else
            {
                if (txtImePrezime.Text != "" && cmbPol.SelectedIndex != -1 && txtEmbg.Text != "" && txtAdresa2.Text != "" && cmbOpstina.SelectedIndex != -1 && txtTransak.Text != ""
              && cmbPodracna.SelectedIndex != -1 && txtEmail2.Text != "" && txtBruto.Text != "" && txtNeto.Text != "" && cmbSifra.SelectedIndex != -1 && txtSkrateno.Text != "")
                {
                    VrabotenController.Update(txtFirmaId, txtImePrezime, cmbPol, txtEmbg, txtAdresa2, cmbOpstina, txtTransak, cmbPodracna, txtEmail2, txtBruto,
                        txtNeto, cmbSifra, txtSkrateno, dateTimePicker1, chbOtkaz, dateTimePicker2, txtVrabotenId);

                    errorProvider1.SetError(button7, "");
                    Clear2();
                    long temp = (long)cmbFirmi2.SelectedValue;
                    loadListBox(temp);
                }
                else
                {
                    errorProvider1.SetError(button7, "Сите полиња се задолжителни!");
                }
            }

            

            
        }

        private void chbOtkaz_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Enabled = !dateTimePicker2.Enabled;
        }
        public void Clear2()
        {
            txtImePrezime.Clear();
            cmbPol.SelectedIndex = -1;
            txtEmbg.Clear();
            txtAdresa2.Clear();
            cmbOpstina.SelectedIndex = -1;
            txtTransak.Clear();
            cmbOpstina.SelectedIndex = -1;
            txtEmail2.Clear();
            txtBruto.Text = 0.ToString();
            txtNeto.Text = 0.ToString();
            cmbSifra.SelectedIndex = -1;
            cmbPodracna.SelectedIndex = -1;
            txtSkrateno.Clear();
            if (chbOtkaz.Checked)
                chbOtkaz.Checked = !chbOtkaz.Checked;
            txtVrabotenId.Clear();
            lstBox.SelectedIndex = -1;
            long temp = (long)cmbFirmi2.SelectedValue;
            loadListBox(temp);
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            Clear2();
        }

        private void btnOdberi3_Click(object sender, EventArgs e)
        {
            if(lstBox.SelectedIndex == -1)
            {
                MessageBox.Show("Ве молиме изберете вработен!");
            }
            else
            {
                long temp = (long)lstBox.SelectedValue;
                Vraboten vraboten = VrabotenController.getVrabotenById(temp);
                txtImePrezime.Text = vraboten.ime;
                dateTimePicker1.Value = vraboten.datumPriem;
                cmbPol.SelectedItem = vraboten.pol;
                txtEmbg.Text = vraboten.embg;
                txtAdresa2.Text = vraboten.adresa;
                cmbOpstina.SelectedItem = vraboten.opstina;
                txtTransak.Text = vraboten.transakciskaSmetka;
                cmbPodracna.SelectedItem = vraboten.podracnaEdinica;
                txtEmail2.Text = vraboten.email;
                txtBruto.Text = vraboten.brutoPlata.ToString();
                txtNeto.Text = vraboten.netoPlata.ToString();
                cmbSifra.SelectedItem = vraboten.sifra;
                txtSkrateno.Text = vraboten.skrateno.ToString();
                txtVrabotenId.Text = vraboten.id.ToString();
                if (vraboten.datumOtkaz != null)
                {
                    chbOtkaz.Checked = true;
                    dateTimePicker2.Value = (DateTime)vraboten.datumOtkaz;
                }
            }
            
            //txtGod
            //txtMes
            //txtDen
        }

        public void loadListBox(long temp)
        {
            lstBox.DataSource = VrabotenController.getVraboteniFromFirmaId(temp);
            lstBox.DisplayMember = "ime";
            lstBox.ValueMember = "id";
        }

        private void btnIzbrisi2_Click(object sender, EventArgs e)
        {
            if (lstBox.SelectedIndex == -1)
            {
                MessageBox.Show("Не е селектиран вработен");
                return;
            }
            else
            {
                long temp = (long)lstBox.SelectedValue;
                VrabotenController.deleteVrabotenById(temp);
                Clear2();
                Clear3();
            }
            
        }
        public void loadCmbVraboteni(long temp)
        {
            cmbVraboteni.DataSource = VrabotenController.getVraboteniFromFirmaId(temp);
            cmbVraboteni.DisplayMember = "ime";
            cmbVraboteni.ValueMember = "id";
        }

        private void btnOdberi4_Click(object sender, EventArgs e)
        {
            if(cmbFirmi3.SelectedIndex != -1)
            {
                long temp = (long)cmbFirmi3.SelectedValue;
                loadCmbVraboteni(temp);
                txtVkupno.Text = PlataController.vkupnoTrosoci(temp).ToString();
            }
        }

        public void Clear3()
        {
            cmbFirmi3.SelectedIndex = -1;
            cmbVraboteni.SelectedIndex = -1;
            txtOdraboteni.Clear();
            txtBruto2.Clear();
            txtNeto2.Clear();
            txtPridonesiPio.Clear();
            txtPridonesiVrabotuvanje.Clear();
            txtPridonesiZdravstvo.Clear();
            txtProfZaboluvanje.Clear();
            rtbPreview.Clear();
        }

        private void btnClear4_Click(object sender, EventArgs e)
        {
            Clear3();
        }

        private void btnOdberi5_Click(object sender, EventArgs e)
        {
            if (cmbVraboteni.SelectedIndex == -1)
            {
                MessageBox.Show("Ве молиме изберете вработен!");
            }
            else
            {
                long vrabotenId = long.Parse(cmbVraboteni.SelectedValue.ToString());
                Vraboten vraboten = VrabotenController.getVrabotenById(vrabotenId);
                txtOdraboteni.Text = lblRabotni.Text.ToString();
                txtBruto2.Text = vraboten.brutoPlata.ToString();
                txtNeto2.Text = vraboten.netoPlata.ToString();
                txtPridonesiPio.Text = (vraboten.brutoPlata * 0.188).ToString();
                txtPridonesiZdravstvo.Text = (vraboten.brutoPlata * 0.075).ToString();
                txtPridonesiVrabotuvanje.Text = (vraboten.brutoPlata * 0.012).ToString();
                txtProfZaboluvanje.Text = (vraboten.brutoPlata * 0.005).ToString();
                txtDohod.Text = (vraboten.brutoPlata * 0.1).ToString();
            }
            
        }


        private void txtBruto_Validated(object sender, EventArgs e)
        {
            int bruto = int.Parse(txtBruto.Text);
            txtNeto.Text = PlataController.returnNetoPlata(bruto).ToString();
        }

        private void txtNeto_Validated(object sender, EventArgs e)
        {
            int neto = int.Parse(txtNeto.Text);
            txtBruto.Text = PlataController.returnBrutoPlata(neto).ToString();
        }

        private void btnGeneriraj_Click(object sender, EventArgs e)
        {
            if (cmbFirmi3.SelectedIndex == -1)
            {
                MessageBox.Show("Ве молиме селектирајте фирма прво!");
            }
            else
            {
                long temp = long.Parse(cmbFirmi3.SelectedValue.ToString());
                Firma firma = FirmaController.GetFirmaById(temp);
                String str = PlataController.generate(temp);
                DateTime date = dateTimePicker3.Value;
                StreamWriter file = new StreamWriter(@"..\..\Izvestai\" + firma.ime + "-" + date.ToString("MMMM") + "-" + date.ToString("yyyy") + ".csv");
                file.Write(str);
                file.Close();
                MessageBox.Show("Успешно генериран извештај за фирмата!");
                btnPreview.PerformClick();
            }

        }


        public bool checkNumberExists(String text)
        {
            foreach (char c in text)
            {
                if (Char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }

        public bool checkAlphabetExist(String text)
        {
            foreach (char c in text)
            {
                if (Char.IsLetter(c))
                {
                    return true;
                }
            }
            return false;
        }


        private void CheckNumber(object sender, CancelEventArgs e)
        {
            TextBox proba = sender as TextBox;
            String text = proba.Text;
            text = Regex.Replace(text, @"\s+", "");

            if (checkNumberExists(text) || text.Equals(""))
            {
                errorProvider1.SetError(proba, "Не смее тоа поле да содржи број или да биде празно!");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(proba, "");
            }
        }


        private void CheckAlphabet(object sender, CancelEventArgs e)
        {
            TextBox proba = sender as TextBox;
            String text = proba.Text;
            text = Regex.Replace(text, @"\s+", "");

            if (checkAlphabetExist(text) || text.Equals(""))
            {
                errorProvider1.SetError(proba, "Не смее тоа поле да содржи буква или да биде празно!");
                e.Cancel = true;
            }
            else
            {
                long broj = long.Parse(text);
                if(broj < 0)
                {
                    errorProvider1.SetError(proba, "Не смее тоа поле да содржи негативен број!");
                    e.Cancel = true;
                }

                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(proba, "");
                }
            }
        }

        private void checkEmail(object sender, CancelEventArgs e)
        {
            TextBox text = sender as TextBox;
            String email;
            if (text != null)
            {
                email = text.Text;

                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    e.Cancel = false;
                    errorProvider1.SetError(text, "");
                }
                catch
                {
                    errorProvider1.SetError(text, "Мора да биде валиден емаил формат!");
                    e.Cancel = true; ;
                }
            }
        }

        private void AdresaValidating(object sender, CancelEventArgs e)
        {
            TextBox proba = sender as TextBox;
            String text = proba.Text;
            text = Regex.Replace(text, @"\s+", "");

            if (text.Equals(""))
            {
                errorProvider1.SetError(proba, "Не смее оа поле да биде празно");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(proba, "");
            }
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            if(cmbFirmi3.SelectedIndex == -1)
            {
                MessageBox.Show("Ве молиме селектирајте фирма прво!");
            }
            else
            {
                long temp = long.Parse(cmbFirmi3.SelectedValue.ToString());
                String str = PlataController.generate(temp);
                rtbPreview.Text = str;
            }
            
        }
    }
}


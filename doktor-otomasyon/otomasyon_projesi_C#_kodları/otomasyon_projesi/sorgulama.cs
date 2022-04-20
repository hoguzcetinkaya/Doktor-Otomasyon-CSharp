using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace otomasyon_projesi
{
    public partial class sorgulama : Form
    {
        public sorgulama()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti;
        MySqlCommand komut;
        MySqlDataAdapter DA;
        MySqlDataReader DR;
        void baglanti_kontrol()
        {
            baglanti = new MySqlConnection("SERVER=localhost;DATABASE=otomasyon_doktor;UID=root;PASSWORD=37gg87as23ha9LL.");
            try
            {
                baglanti.Open();
                
                baglanti.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        int genislik, yukseklik;
        private void sorgulama_Load(object sender, EventArgs e)
        {
            baglanti_kontrol();
            dataGridView1.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            genislik = this.Size.Width;
            yukseklik = this.Size.Height;

        }
        string doktorid;
        private void btDoktorAra_Click(object sender, EventArgs e)
        {
            
            /*
             * baglanti.Open();
            string getir = "SELECT * from "+a+" order by idadres desc";
            DA = new MySqlDataAdapter(getir, baglanti);
            DataTable tablo = new DataTable();
            DA.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();*/

            try
            {
                doktorid = null;
                baglanti.Open();
                string doktorAraGiris = "SELECT iddoktor from doktor where doktor_adi=@doktor_adi and doktor_soyadi=@doktor_soyadi";
                komut = new MySqlCommand(doktorAraGiris, baglanti);
                komut.Parameters.AddWithValue("@doktor_adi", textBox1.Text);
                komut.Parameters.AddWithValue("@doktor_soyadi", textBox2.Text);
                DR = komut.ExecuteReader();
                if (DR.Read())
                {
                    doktorid = DR["iddoktor"].ToString();
                }
                baglanti.Close();


                baglanti.Open();
                string doktorAra = "Select doktor.doktor_unvan,doktor.doktor_adi,doktor.doktor_soyadi,doktor.doktor_dogum_tarihi,brans.brans_adi,okul.okul_adi,hastane.hastane_adi,adres.il,adres.ilce,adres.mahalle,adres.sokak from hastane,brans,okul,adres,doktor where adres.idadres=doktor.idadres and brans.idbrans=doktor.idbrans and doktor.iddokul=okul.idokul and hastane.idhastane=doktor.idhastane and (doktor.iddoktor=" + doktorid + ")";
                DA = new MySqlDataAdapter(doktorAra, baglanti);
                DataTable tabloDoktorAra = new DataTable();
                DA.Fill(tabloDoktorAra);
                dataGridView1.DataSource = tabloDoktorAra;
                dataGridView1.Visible = true;
                baglanti.Close();
            }
            catch (Exception)
            {
                
                MessageBox.Show("Böyle bir doktor kaydı bulunamadı.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

            baglanti.Close();




        }

        private void btIzinSorgula_Click(object sender, EventArgs e)
        {
            try
            {
                doktorid = null;
                baglanti.Open();
                string KalanIzinDoktorID = "SELECT iddoktor from doktor where doktor_tc=@doktor_tc";
                komut = new MySqlCommand(KalanIzinDoktorID, baglanti);
                komut.Parameters.AddWithValue("@doktor_tc", textBox4.Text);
                DR = komut.ExecuteReader();
                if (DR.Read())
                {
                    doktorid = DR["iddoktor"].ToString();
                }
                baglanti.Close();


                baglanti.Open();
                string KalanIzinSorgula = "Select doktor_adi,doktor_soyadi,doktor_izin from doktor where iddoktor=" + doktorid + "";
                DA = new MySqlDataAdapter(KalanIzinSorgula, baglanti);
                DataTable tabloIzinGetir = new DataTable();
                DA.Fill(tabloIzinGetir);
                dataGridView1.DataSource = tabloIzinGetir;
                dataGridView1.Visible = true;
                baglanti.Close();
                

            }
            catch (MySqlException)
            {
                MessageBox.Show("Bu TC'ye ait bilgi bulunmamaktadır.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglanti.Close();
            
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel1.Location = new Point(480, 75);
        }

        private void btIzinTarih_Click(object sender, EventArgs e)
        {
            try
            {
                doktorid = null;
                baglanti.Open();
                string KullanilanIzinID = "SELECT iddoktor from doktor where doktor_tc=@doktor_tc";
                komut = new MySqlCommand(KullanilanIzinID, baglanti);
                komut.Parameters.AddWithValue("@doktor_tc", textBox3.Text);
                DR = komut.ExecuteReader();
                if (DR.Read())
                {
                    doktorid = DR["iddoktor"].ToString();
                }
                baglanti.Close();

                baglanti.Open();
                string KullanilanIzin = "Select doktor.doktor_adi,doktor.doktor_soyadi,izin.izin_baslangic,izin.izin_bitis from izin,doktor where doktor.iddoktor=izin.iddoktor and (doktor.iddoktor=" + doktorid + ")";
                DA = new MySqlDataAdapter(KullanilanIzin, baglanti);
                DataTable tabloIzinKullanilan = new DataTable();
                DA.Fill(tabloIzinKullanilan);
                dataGridView1.DataSource = tabloIzinKullanilan;
                dataGridView1.Visible = true;
                baglanti.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Bu TC'ye ait bilgi bulunmamaktadır.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglanti.Close();
            
        }

        

        private void btHastaneSorgu_Click(object sender, EventArgs e)
        {
            int hastaneID;
            hastaneID = comboBox1.SelectedIndex + 1;

            baglanti.Open();
            string HastaneCalisanSorgu = "Select doktor.doktor_unvan,doktor.doktor_adi,doktor.doktor_soyadi,brans.brans_adi,hastane.hastane_adi,hastane.hastane_turu from hastane,doktor,brans where hastane.idhastane=doktor.idhastane and brans.idbrans=doktor.idbrans and hastane.idhastane="+hastaneID+"";
            DA = new MySqlDataAdapter(HastaneCalisanSorgu, baglanti);
            DataTable tabloHastaneSorgu = new DataTable();
            DA.Fill(tabloHastaneSorgu);
            dataGridView1.DataSource = tabloHastaneSorgu;
            dataGridView1.Visible = true;
            baglanti.Close();
        }

        private void btOkulSorgu_Click(object sender, EventArgs e)
        {
            int okulID;
            okulID = comboBox3.SelectedIndex + 1;
            baglanti.Open();
            string OkulSorgu = "Select doktor.doktor_adi,doktor.doktor_soyadi,okul.okul_adi,okul.okul_turu from okul,doktor where okul.idokul=doktor.iddokul and okul.idokul=" + okulID + "";
            DA = new MySqlDataAdapter(OkulSorgu, baglanti);
            DataTable tabloOkulSorgu = new DataTable();
            DA.Fill(tabloOkulSorgu);
            dataGridView1.DataSource = tabloOkulSorgu;
            dataGridView1.Visible = true;
            baglanti.Close();
        }

        private void btHastaneBilgi_Click(object sender, EventArgs e)
        {
            
                int hastaneID;
                hastaneID = comboBox2.SelectedIndex + 1;

                baglanti.Open();
                string HastaneSorgu = "Select hastane.hastane_adi,hastane.hastane_turu,adres.il,adres.ilce,adres.mahalle,adres.sokak from hastane,adres where hastane.idadres=adres.idadres and hastane.idhastane=" + hastaneID + "";
                DA = new MySqlDataAdapter(HastaneSorgu, baglanti);
                DataTable tabloHastane = new DataTable();
                DA.Fill(tabloHastane);
                dataGridView1.DataSource = tabloHastane;
            dataGridView1.Visible = true;
            baglanti.Close();
            
            
            
        }

        private void AsiTakip_Click(object sender, EventArgs e)
        {
            try
            {
                doktorid = null;
                baglanti.Open();
                string AsitakipDoktorID = "SELECT iddoktor from doktor where doktor_tc=@doktor_tc";
                komut = new MySqlCommand(AsitakipDoktorID, baglanti);
                komut.Parameters.AddWithValue("@doktor_tc", textBox5.Text);
                DR = komut.ExecuteReader();
                if (DR.Read())
                {
                    doktorid = DR["iddoktor"].ToString();
                }
                baglanti.Close();

                baglanti.Open();
                string asiDoktorSorgu = "Select doktor.doktor_adi,doktor.doktor_soyadi,asi.asi_adi,doktor_asi_vurulur.tarih,doktor_asi_vurulur.doz from doktor,asi,doktor_asi_vurulur where doktor.iddoktor=doktor_asi_vurulur.doktor_iddoktor and doktor_asi_vurulur.asi_idasi=asi.idasi and iddoktor=" + doktorid + "";
                DA = new MySqlDataAdapter(asiDoktorSorgu, baglanti);
                DataTable tabloAsi = new DataTable();
                DA.Fill(tabloAsi);
                dataGridView1.DataSource = tabloAsi;
                dataGridView1.Visible = true;
                baglanti.Close();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Bu TC'ye ait bilgi bulunmamaktadır.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglanti.Close();
        }

        private void btNobetSorgu_Click(object sender, EventArgs e)
        {
            try
            {
                doktorid = null;
                baglanti.Open();
                string NobetDoktorID = "SELECT iddoktor from doktor where doktor_tc=@doktor_tc";
                komut = new MySqlCommand(NobetDoktorID, baglanti);
                komut.Parameters.AddWithValue("@doktor_tc", textBox6.Text);
                DR = komut.ExecuteReader();
                if (DR.Read())
                {
                    doktorid = DR["iddoktor"].ToString();
                }
                baglanti.Close();

                baglanti.Open();
                string NobetSorgu = "Select doktor.doktor_adi,doktor.doktor_soyadi,nobet.nobet_tarihi from doktor,nobet where nobet.iddoktor=doktor.iddoktor and doktor.iddoktor=" + doktorid + "";
                DA = new MySqlDataAdapter(NobetSorgu, baglanti);
                DataTable tabloNobet = new DataTable();
                DA.Fill(tabloNobet);
                dataGridView1.DataSource = tabloNobet;
                dataGridView1.Visible = true;
                baglanti.Close();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Bu TC'ye ait bilgi bulunmamaktadır.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            baglanti.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel2.Location = new Point(480, 75);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel3.Location = new Point(480, 75);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel4.Location = new Point(480, 75);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel5.Location = new Point(480, 75);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = true;
            panel7.Visible = false;
            panel8.Visible = false;
            panel6.Location = new Point(480, 75);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = true;
            panel8.Visible = false;
            panel7.Location = new Point(480, 75);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = true;
            panel8.Location = new Point(480, 75);
        }

        private void btCikis_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private void sorgulama_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(genislik, yukseklik);
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
}

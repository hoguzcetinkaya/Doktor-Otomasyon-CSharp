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
    public partial class ekleme : Form
    {
        public ekleme()
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
                Application.Exit();
            }
        }

        int genislik, yukseklik;
        void ekrana_yazdir(string a)
        {
            baglanti.Open();
            string getir = "SELECT * from "+a+" order by idadres desc";
            DA = new MySqlDataAdapter(getir, baglanti);
            DataTable tablo = new DataTable();
            DA.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void ekleme_Load(object sender, EventArgs e)
        {
            baglanti_kontrol();
            btAdresEkle.Enabled = false;
            btDoktorEkle.Enabled = false;
            dataGridView1.Visible = false;
            panel1.Visible = false;
            genislik = this.Size.Width;
            yukseklik = this.Size.Height;

        }
        string degisken;
    private void btAdresEkle_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            string adresIDcek = "select max(idadres) from adres";
            komut = new MySqlCommand(adresIDcek, baglanti);
            DR = komut.ExecuteReader();
            if(DR.Read())
            {
                textBox6.Text = DR["max(idadres)"].ToString();
            }
            int adresSayac = Convert.ToInt32(textBox6.Text);
            adresSayac++;
            textBox6.Text = adresSayac.ToString();


            baglanti.Close();
            /*adres ekleme yeri*/
            
             string adresEkle = "INSERT INTO adres(idadres,il,ilce,mahalle,sokak) VALUES(@idadres,@il,@ilce,@mahalle,@sokak)";
             komut = new MySqlCommand(adresEkle, baglanti);
             komut.Parameters.AddWithValue("@idadres", textBox6.Text);
             komut.Parameters.AddWithValue("@il", textBox7.Text);
             komut.Parameters.AddWithValue("@ilce", textBox8.Text);
             komut.Parameters.AddWithValue("@mahalle", textBox9.Text);
             komut.Parameters.AddWithValue("@sokak", textBox10.Text);
             baglanti.Open();
             komut.ExecuteNonQuery();
             baglanti.Close();
            textBox11.Text = textBox6.Text;

            checkBox1.Checked = false;
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";

            panel2.Visible = false;
            panel1.Visible = true;
            panel1.Location = new Point(474, 76);
            btAdresEkle.Enabled = false;

            btCikis.Visible = false;
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true && textBox7.Text!="" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "")
            {
                btAdresEkle.Enabled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            degisken = "adres";
            ekrana_yazdir(degisken);
        }

        private void btDoktorEkle_Click(object sender, EventArgs e)
        {
            int tcUzunluk = textBox5.TextLength;
            if(tcUzunluk==11)
            {
                baglanti.Open();
                string doktorIDcek = "select max(iddoktor) from doktor";
                komut = new MySqlCommand(doktorIDcek, baglanti);
                DR = komut.ExecuteReader();
                if (DR.Read())
                {
                    textBox1.Text = DR["max(iddoktor)"].ToString();
                }
                int doktorSayac = Convert.ToInt32(textBox1.Text);
                doktorSayac++;
                textBox1.Text = doktorSayac.ToString();
                baglanti.Close();
                /*doktor ekleme */
                int izinhakki = 40;
                int durum = 1;
                label12.Text = (comboBox1.SelectedIndex + 1).ToString();
                label13.Text = (comboBox2.SelectedIndex + 1).ToString();
                label18.Text = (comboBox3.SelectedIndex + 1).ToString();

                string doktorEkle = "INSERT INTO doktor (iddoktor,doktor_adi,doktor_soyadi,doktor_unvan,doktor_tc,doktor_dogum_tarihi,doktor_izin,idhastane,idbrans,iddokul,idadres,durum) VALUES(@iddoktor,@doktor_adi,@doktor_soyadi,@doktor_unvan,@doktor_tc,@doktor_dogum_tarihi,@doktor_izin,@idhastane,@idbrans,@iddokul,@idadres,@durum)";
                komut = new MySqlCommand(doktorEkle, baglanti);
                komut.Parameters.AddWithValue("@iddoktor", textBox1.Text);
                komut.Parameters.AddWithValue("@doktor_adi", textBox2.Text);
                komut.Parameters.AddWithValue("@doktor_soyadi", textBox3.Text);
                komut.Parameters.AddWithValue("@doktor_unvan", comboBox4.Text);
                komut.Parameters.AddWithValue("@doktor_tc", textBox5.Text);
                komut.Parameters.AddWithValue("@doktor_dogum_tarihi", dateTimePicker1.Value);
                komut.Parameters.AddWithValue("@doktor_izin", izinhakki);
                komut.Parameters.AddWithValue("@idhastane", label12.Text);
                komut.Parameters.AddWithValue("@idbrans", label13.Text);
                komut.Parameters.AddWithValue("@iddokul", label18.Text);
                komut.Parameters.AddWithValue("@idadres", textBox11.Text);
                komut.Parameters.AddWithValue("@durum", durum);

                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();

                degisken = "doktor";
                ekrana_yazdir(degisken);
                panel1.Visible = false;
                MessageBox.Show("Ekleme başarıyla tamamlandı.","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                dataGridView1.Location = new Point(150, 300);
                dataGridView1.Visible = true;
                btYeniKayit.Visible = true;
                btCikis.Visible = true;

            }
            else
            {
                MessageBox.Show("Hatalı TC girişi doğru yapınız!!","HATA!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

           
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true && textBox2.Text != "" && textBox3.Text != ""  && textBox5.Text != "" && comboBox1.SelectedIndex>=0 && comboBox2.SelectedIndex>=0 && comboBox3.SelectedIndex>=0 && comboBox4.SelectedIndex>=0)
            {
                btDoktorEkle.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            degisken = "doktor";
            ekrana_yazdir(degisken);
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void btCikis_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            panel2.Visible = true;
            dataGridView1.Visible = false;
            btYeniKayit.Visible = false;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void ekleme_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(genislik, yukseklik);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }
    }
}

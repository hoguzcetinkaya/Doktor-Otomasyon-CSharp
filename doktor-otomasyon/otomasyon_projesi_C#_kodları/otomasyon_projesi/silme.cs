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
    public partial class silme : Form
    {
        public silme()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti;
        MySqlCommand komut;
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

        private void silme_Load(object sender, EventArgs e)
        {
            baglanti_kontrol();
            genislik = this.Size.Width;
            yukseklik = this.Size.Height;

        }
        string doktorid;
        private void btSil_Click(object sender, EventArgs e)
        {
            
            try
            {
                doktorid = null;

                baglanti.Open();
                string silIDLER = "SELECT iddoktor,idadres from doktor where doktor_adi=@doktor_adi AND doktor_soyadi=@doktor_soyadi AND doktor_tc=@doktor_tc";
                komut = new MySqlCommand(silIDLER, baglanti);
                komut.Parameters.AddWithValue("@doktor_adi", textBox1.Text);
                komut.Parameters.AddWithValue("@doktor_soyadi", textBox2.Text);
                komut.Parameters.AddWithValue("@doktor_tc", textBox3.Text);
                DR = komut.ExecuteReader();
                if (DR.Read())
                {
                    doktorid = DR["iddoktor"].ToString();
                    label3.Text = DR["idadres"].ToString();

                }
                baglanti.Close();



                string doktorAsiSil = "DELETE FROM doktor_asi_vurulur where doktor_iddoktor=@doktor_iddoktor";
                komut = new MySqlCommand(doktorAsiSil, baglanti);
                komut.Parameters.AddWithValue("@doktor_iddoktor", doktorid);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();

                
                string durumGuncelle = "UPDATE doktor set durum=0 where iddoktor=@iddoktor";
                komut = new MySqlCommand(durumGuncelle, baglanti);
                komut.Parameters.AddWithValue("@iddoktor", doktorid);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();


                string IzinSil = "DELETE FROM izin where iddoktor=@iddoktor";
                komut = new MySqlCommand(IzinSil, baglanti);
                komut.Parameters.AddWithValue("@iddoktor", doktorid);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();

                string NobetSil = "DELETE FROM nobet where iddoktor=@iddoktor";
                komut = new MySqlCommand(NobetSil, baglanti);
                komut.Parameters.AddWithValue("@iddoktor", doktorid);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();


                string Doktorsil = "DELETE FROM doktor where iddoktor=@iddoktor";
                komut = new MySqlCommand(Doktorsil, baglanti);
                komut.Parameters.AddWithValue("@iddoktor", doktorid);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();

                string AdresSil = "DELETE FROM adres where idadres=@idadres";
                komut = new MySqlCommand(AdresSil, baglanti);
                komut.Parameters.AddWithValue("@idadres", label3.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Silme işlemi başarıyla tamamlandı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                


            }
            catch (Exception)
            {

                MessageBox.Show("Bu TC'ye ait bilgi bulunmamaktadır.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglanti.Close();
                
        }

        private void btCikis_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void silme_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(genislik, yukseklik);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }
    }
}

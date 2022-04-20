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
    public partial class guncelleme : Form
    {
        /*Güncelleme : Tasarım Kodlama Youtube kanalını izleyerek yapıldı. https://www.youtube.com/watch?v=_Yo6FCyitwc */
        /*MessageBox kullanımları için : https://sanalkurs.net/c-messagebox-ozellikleri-ve-kullanimi-10231.html */
        /*DateTimePicker işlemleri için :https://www.youtube.com/watch?v=QRzPK7EAexo */
        /*Sadece harf ve sayı girişi için : https://www.muratyazici.com/c-textboxa-sadece-harf-girme-sadece-sayi-girme.html */
        /*Resize kullanımı için : Yavuz Selim Fatihoğlu Görsel Programlama dersimizden yararlandık.*/

        public guncelleme()
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

        private void izinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("izin");
        }

        string nobetDoktorID;
        private void button5_Click(object sender, EventArgs e)
        {

            nobetDoktorID = null;

            baglanti.Open();
            string NobetDoktorID = "SELECT iddoktor FROM doktor WHERE doktor_tc=@doktor_tc";
            komut = new MySqlCommand(NobetDoktorID, baglanti);
            komut.Parameters.AddWithValue("@doktor_tc", textBox3.Text);
            DR = komut.ExecuteReader();
            if (DR.Read())
            {
                nobetDoktorID = DR["iddoktor"].ToString();
            }

            baglanti.Close();

            if (nobetDoktorID != null)
            {
                baglanti.Open();
                string nobetIDcek = "select max(idnobet) from nobet";
                komut = new MySqlCommand(nobetIDcek, baglanti);
                DR = komut.ExecuteReader();
                if (DR.Read())
                {
                    textBox1.Text = DR["max(idnobet)"].ToString();
                }
                int nobetSayac = Convert.ToInt32(textBox1.Text);
                nobetSayac++;
                textBox1.Text = nobetSayac.ToString();
                baglanti.Close();



                string nobetEkle = "INSERT INTO nobet (idnobet,nobet_tarihi,iddoktor) VALUES (@idnobet,@nobet_tarihi,@iddoktor)";
                komut = new MySqlCommand(nobetEkle, baglanti);
                komut.Parameters.AddWithValue("@idnobet", textBox1.Text);
                komut.Parameters.AddWithValue("@nobet_tarihi", dateTimePicker1.Value);
                komut.Parameters.AddWithValue("@iddoktor", nobetDoktorID);
                baglanti.Open();
                komut.ExecuteNonQuery();
                MessageBox.Show("Nöbet seçme işlemi başarıyla tamamlandı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Bu TC'ye ait bilgi bulunmamaktadır.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            textBox3.Text = "";
            baglanti.Close();


        }
        int genislik, yukseklik;
        private void guncelleme_Load(object sender, EventArgs e)
        {
            baglanti_kontrol();
            textBox1.Enabled = false;
            genislik = this.Size.Width;
            yukseklik = this.Size.Height;


        }
        string izinDoktorID;
        private void button4_Click(object sender, EventArgs e)
        {

            izinDoktorID = null;

            baglanti.Open();
            string IzinDoktorID = "SELECT doktor_izin,iddoktor FROM doktor WHERE doktor_tc=@doktor_tc";
            komut = new MySqlCommand(IzinDoktorID, baglanti);
            komut.Parameters.AddWithValue("@doktor_tc", textBox2.Text);
            DR = komut.ExecuteReader();
            if (DR.Read())
            {
                izinDoktorID = DR["iddoktor"].ToString();
                label12.Text = DR["doktor_izin"].ToString();

            }
            baglanti.Close();

            if (izinDoktorID != null)
            {
                baglanti.Open();
                string izinIDcek = "select max(idizin) from izin";
                komut = new MySqlCommand(izinIDcek, baglanti);
                DR = komut.ExecuteReader();
                if (DR.Read())
                {
                    textBox4.Text = DR["max(idizin)"].ToString();
                }
                int izinSayac = Convert.ToInt32(textBox4.Text);
                izinSayac++;
                textBox4.Text = izinSayac.ToString();
                baglanti.Close();

                TimeSpan izinSuresi = izinTarih2.Value.Subtract(izinTarih1.Value);
                int fark = izinSuresi.Days;
                int gunhakki = Convert.ToInt32(label12.Text);
                if (fark < 0)
                {
                    MessageBox.Show("Yanlış tarih aralığı girdiniz !!");
                }
                else if (gunhakki == 0)
                {
                    MessageBox.Show("İzin hakkınız kalmamıştır !!");
                }
                else if (fark > gunhakki)
                {
                    MessageBox.Show("Seçtiğiniz aralık izin hakkınızdan fazladır !!");
                }
                else
                {
                    label7.Text = fark.ToString() + " gün";
                    int yeniIzinHakki = gunhakki - fark;

                    string izinEkle = "INSERT INTO izin (idizin,izin_baslangic,izin_bitis,iddoktor) VALUES (@idizin,@izin_baslangic,@izin_bitis,@iddoktor)";
                    komut = new MySqlCommand(izinEkle, baglanti);
                    komut.Parameters.AddWithValue("@idizin", textBox4.Text);
                    komut.Parameters.AddWithValue("@izin_baslangic", izinTarih1.Value);
                    komut.Parameters.AddWithValue("@izin_bitis", izinTarih2.Value);
                    komut.Parameters.AddWithValue("@iddoktor", izinDoktorID);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    string IzinGuncelle = "update doktor set doktor_izin=@doktor_izin where iddoktor=@iddoktor";
                    komut = new MySqlCommand(IzinGuncelle, baglanti);
                    komut.Parameters.AddWithValue("@doktor_izin", yeniIzinHakki);
                    komut.Parameters.AddWithValue("@iddoktor", izinDoktorID);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }
                textBox2.Text = "";
                label11.Visible = true;
                label7.Visible = true;
                MessageBox.Show("İzin seçme işlemi başarıyla tamamlandı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Bu TC'ye ait bilgi bulunmamaktadır.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        string asiGuncelleDoktorID;
        private void btAsiGuncelle_Click_1(object sender, EventArgs e)
        {

            asiGuncelleDoktorID = null;
            baglanti.Open();
            string asiDoktorID = "SELECT iddoktor FROM doktor WHERE doktor_tc=@doktor_tc";
            komut = new MySqlCommand(asiDoktorID, baglanti);
            komut.Parameters.AddWithValue("@doktor_tc", textBox5.Text);
            DR = komut.ExecuteReader();
            if (DR.Read())
            {
                asiGuncelleDoktorID = DR["iddoktor"].ToString();

            }
            baglanti.Close();

            label13.Text = (comboBox1.SelectedIndex + 1).ToString();

            if (asiGuncelleDoktorID != null)
            {
                string asiEkle = "INSERT INTO doktor_asi_vurulur (doktor_iddoktor,asi_idasi,tarih,doz) VALUES(@doktor_iddoktor,@asi_idasi,@tarih,@doz)";
                komut = new MySqlCommand(asiEkle, baglanti);
                komut.Parameters.AddWithValue("@doktor_iddoktor", asiGuncelleDoktorID);
                komut.Parameters.AddWithValue("@asi_idasi", label13.Text);
                komut.Parameters.AddWithValue("@tarih", asiTarih.Value);
                if (radioButton1.Checked == true)
                {
                    komut.Parameters.AddWithValue("@doz", 1);
                }
                if (radioButton2.Checked == true)
                {
                    komut.Parameters.AddWithValue("@doz", 2);
                }
                if (radioButton3.Checked == true)
                {
                    komut.Parameters.AddWithValue("@doz", 3);
                }
                baglanti.Open();
                komut.ExecuteNonQuery();
                textBox5.Text = "";
                comboBox1.Text = "";
                MessageBox.Show("Aşı seçme işlemi başarıyla tamamlandı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                baglanti.Close();

                textBox5.Text = "";
                comboBox1.Text = "";


                baglanti.Close();
            }
            else
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

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel1.Location = new Point(453, 155);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel2.Location = new Point(453, 155);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            panel3.Location = new Point(453, 155);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void guncelleme_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(genislik, yukseklik);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}

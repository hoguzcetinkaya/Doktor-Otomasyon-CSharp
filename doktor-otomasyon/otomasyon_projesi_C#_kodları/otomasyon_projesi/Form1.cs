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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti;
        
        
        void baglanti_kontrol()
        {
            baglanti = new MySqlConnection("SERVER = localhost; DATABASE = otomasyon_doktor; UID = root; PASSWORD = 37gg87as23ha9LL.");
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

        int genislik,yukseklik;
        private void Form1_Load(object sender, EventArgs e)
        {
            genislik = this.Size.Width;
            yukseklik = this.Size.Height;
            baglanti_kontrol();
            
        }

        private void btEkleme_Click(object sender, EventArgs e)
        {
            ekleme Ekle = new ekleme();
            Ekle.Show();
            this.Hide();
        }

        private void btSilme_Click(object sender, EventArgs e)
        {
            silme sil = new silme();
            sil.Show();
            this.Hide();
        }

        private void btGuncelleme_Click(object sender, EventArgs e)
        {
            guncelleme Guncelle = new guncelleme();
            Guncelle.Show();
            this.Hide();
        }

        private void btSorgulama_Click(object sender, EventArgs e)
        {
            sorgulama Sorgula = new sorgulama();
            Sorgula.Show();
            this.Hide();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(genislik, yukseklik);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult cevap=new DialogResult();
            cevap=MessageBox.Show("Çıkmak istiyor musunuz?","ÇIKIŞ",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            
            if(cevap==DialogResult.Yes)
            {
                Application.Exit();
            }

            
        }
    }
}

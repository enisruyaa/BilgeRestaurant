using BilgeRestaurant.Models.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BilgeRestaurant
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void SecileniSifirla(ComboBox a)
        {
            a.SelectedIndex = -1;
        }

        private void VerileriListele()
        {
            List<AnaYemek> anaYemekler = new List<AnaYemek>()
            {
                new AnaYemek{ Isim = " Karnı Yarık " , Fiyat = 120},
                new AnaYemek { Isim = " Kebap " , Fiyat = 200 },
                new AnaYemek { Isim = " Köfte Ekemek " , Fiyat = 150 }
            };
            cmbAnaYemek.DataSource = anaYemekler;
            SecileniSifirla(cmbAnaYemek);

            List<AraSicak> araSicaklar = new List<AraSicak>()
            {
                new AraSicak{ Isim = " Karides Güveç " , Fiyat = 280 },
                new AraSicak { Isim = "Paçanga Böreği " , Fiyat = 100  },
                new AraSicak { Isim = "Fırında Kaşarlı Mantar" , Fiyat = 180 }
            };

            cmbAraSicak.DataSource = araSicaklar;
            SecileniSifirla(cmbAraSicak);

            List<Tatli> tatlilar = new List<Tatli>()
            {
                new Tatli { Isim = " Triliçe " , Fiyat = 90 },
                new Tatli { Isim = " Magnolya " , Fiyat = 80 },
                new Tatli { Isim = " Kazan Dibi " , Fiyat = 100 }
            };
            cmbTatli.DataSource = tatlilar;
            SecileniSifirla(cmbTatli);

            List<Icecek> icecekler = new List<Icecek>()
            {
                new Icecek { Isim = "Kola" , Fiyat = 40 },
                new Icecek { Isim = "Fanta" , Fiyat = 40 },
                new Icecek { Isim = "Sprite" , Fiyat = 40 },
                new Icecek { Isim = "İcetea" , Fiyat = 40 },
                new Icecek { Isim = "Çay" , Fiyat = 20 }

            };
            cmbIcecek.DataSource = icecekler;
            SecileniSifirla(cmbIcecek);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            VerileriListele();
        }

        private void btnSiparisVer_Click(object sender, EventArgs e)
        {
            if (txtMasaNo.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Lütfen Bir Masaya Geçiniz");
                return;
            }
            if (cmbAnaYemek.SelectedIndex < 0 && cmbAraSicak.SelectedIndex < 0  && cmbTatli.SelectedIndex < 0 && cmbIcecek.SelectedIndex <0)
            {
                MessageBox.Show("En Az Bir Tane Sipraiş Oluşturmalısınız");
                return;
            }
            Siparis s = new Siparis(txtMasaNo.Text);
            if (cmbAnaYemek.SelectedIndex > -1) s.SecilenAnaYemek = cmbAnaYemek.SelectedItem as AnaYemek;
            if (cmbAraSicak.SelectedIndex > -1) s.SecilenAraSicak = cmbAraSicak.SelectedItem as AraSicak;
            if (cmbTatli.SelectedIndex > -1) s.SecilenTatli = cmbTatli.SelectedItem as Tatli;
            if (cmbIcecek.SelectedIndex > -1) s.SecilenIcecek = cmbIcecek.SelectedItem as Icecek;
            lstSiparisler.Items.Add(s);
            txtMasaNo.Text = "";
            cmbAnaYemek.SelectedIndex = cmbAraSicak.SelectedIndex = cmbIcecek.SelectedIndex = cmbTatli.SelectedIndex = -1;
        }

        private void btnCiro_Click(object sender, EventArgs e)
        {
            decimal ciro = 0;
            foreach (Siparis item in lstSiparisler.Items)ciro += item.Fiyat;
            MessageBox.Show($" Bugünün Cirosu : {ciro} ");
            txtMasaNo.Text = "";
        }

    }
}

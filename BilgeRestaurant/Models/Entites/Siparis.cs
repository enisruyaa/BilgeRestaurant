using BilgeRestaurant.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeRestaurant.Models.Entites
{
    public class Siparis : BaseEntity
    {
        public Siparis(string masaNo)
        {
            Isim = masaNo;
        }

        //Bu kısımda Sipraiş classını açmamızın sebebi programımız siparişin ne olduğunu bilmiyor onu tanıttık.

        // İlk Sormamız Gereken Şey Siparişin neyi var ve bu sorunun cevapları bize property'leri getirecek

        public AnaYemek SecilenAnaYemek { get; set; }

        public AraSicak SecilenAraSicak { get; set; }

        public Tatli SecilenTatli { get; set; }

        public Icecek SecilenIcecek { get; set; }

        public void FiyatEkle (YemekCesidi a) // Enumda gelen kısımlara göre Base Fiyatına seçilen ürünün fiyatını ekledik.
        {

            switch (a)
            {
                case YemekCesidi.AnaYemek:
                    Fiyat += SecilenAnaYemek.Fiyat;
                    break;

                case YemekCesidi.AraSicak:
                    Fiyat += SecilenAraSicak.Fiyat;
                    break;

                case YemekCesidi.Tatli:
                    Fiyat += SecilenTatli.Fiyat;
                    break;

                case YemekCesidi.Icecek:
                    Fiyat += SecilenIcecek.Fiyat;
                    break;
            }
        }

        public decimal TutarHesapla() // Seçlien Ürünlerin Fiyatlarını Hesapladık.
        {
            if (SecilenAnaYemek != null) FiyatEkle(YemekCesidi.AnaYemek);
            if (SecilenAraSicak != null) FiyatEkle(YemekCesidi.AraSicak);
            if (SecilenTatli != null) FiyatEkle(YemekCesidi.Tatli);
            if (SecilenIcecek != null) FiyatEkle(YemekCesidi.Icecek);

            return Fiyat;
        }

        public override string ToString() // Bu kısımda 'da listbox'a eklenecek olan siparişlerin nesne olarak eklenecekeri için RAM yolu gözükeceği için stringin override (Polymorphisim)'ini kullanarak yazdırma ayarlamalarımızı yaptık. (Eğer list Box değil'de bir başka control seçseydik onada'da geçerli olacaktı.)
        {
            string secileniYazdir = null;
            if (SecilenAnaYemek != null) secileniYazdir += $"{SecilenAnaYemek.Isim} -> Fiyatı : {SecilenAnaYemek.Fiyat}";
            if (SecilenAraSicak != null) secileniYazdir += $" {SecilenAraSicak.Isim} -> Fiyatı : {SecilenAraSicak.Fiyat} ";
            if (SecilenIcecek != null) secileniYazdir += $" {SecilenIcecek.Isim} -> Fiyatı : {SecilenIcecek.Fiyat}";
            if (SecilenTatli != null) secileniYazdir += $"{SecilenTatli.Isim} -> Fiyatı : {SecilenTatli.Fiyat}";
            return $"{Isim} Masasına : {secileniYazdir} -> Toplam Tutar : {TutarHesapla():C2} ";
            // Bu kısımda Isim olarak yazdığımız şey aslında masa numarasıdır.
        }
    }
}

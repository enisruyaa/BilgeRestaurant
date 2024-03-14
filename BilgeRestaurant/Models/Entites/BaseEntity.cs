using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeRestaurant.Models.Entites
{
    public abstract class BaseEntity 
    {
        public string Isim { get; set; }

        public decimal Fiyat { get; set; }

        // Her Ürünün Bir ismi ve Bir Fiyatı Olacağı İçin Bunu Base Entity'e Koyduk Abstract sınıf yapmamızın sebebi ise bu sınıfın instance'sinin alınmamasını sağlamak ve diğer sınıflara miras vermekle yükümlü olması

        public override string ToString()
        {
            return $" {Isim} -> {Fiyat} ";
        }

        // Burada Polymorphisim Kullanmamın Sebebi Combo Box'ta Gözükecek Ürünlerin Normalde RAM' yolu gözükmesini enegellemek ve ürünün ismi ve fiyatının yan yana gözükmsini sağlamak. 
    }
}

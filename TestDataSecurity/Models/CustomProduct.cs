using System.ComponentModel.DataAnnotations.Schema;

namespace TestDataSecurity.Models
{
    public partial class Product //Burdaki adını değiştirdik çünkü diğer Product sınıfında scaffold toolunu kullandığımızda veritabanı tablosunda olmadığı için silinecekti. Bu yüzden değiştirdik ve artık product çağırdığımız da burdaki propuda otomatikmen içine ekleyecek. (Solution içinde ki adı CustomProduct)
    {
        [NotMapped]
        public string EncrypedId { get; set; } //Şifreleyeceğimiz url nin ıd si 
    }
}

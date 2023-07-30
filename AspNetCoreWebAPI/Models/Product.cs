using System.ComponentModel.DataAnnotations;

namespace AspNetCoreWebAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Ürün Adı")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
        [Display(Name = "Resim")]
        public string? Image { get; set; }
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
        [Display(Name = "Kategori")]
        public virtual Category? Category { get; set; }
    }
}

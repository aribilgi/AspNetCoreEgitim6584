namespace AspNetCoreEgitim6584.Models
{
    public class KullaniciSayfasiViewModel
    {
        public Kullanici Kullanici { get; set; }
        public Adres Adres { get; set; }
        public List<Uye>? Uyeler { get; set; }
    }
}

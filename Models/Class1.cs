namespace Etkinlik_Takip_Sistemi.Models
{
    public class IncelemeViewModel
    {
        public int IncelemeID { get; set; }
        public string EtkinlikAdi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Yorum { get; set; }
        public int? Puan { get; set; }
    }
}

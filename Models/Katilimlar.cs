//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Etkinlik_Takip_Sistemi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Katilimlar
    {
        public int KatilimID { get; set; }
        public Nullable<int> EtkinlikID { get; set; }
        public Nullable<int> KullaniciID { get; set; }
        public string KatilimDurumu { get; set; }
    
        public virtual Etkinlikler Etkinlikler { get; set; }
        public virtual Kullanicilar Kullanicilar { get; set; }
    }
}

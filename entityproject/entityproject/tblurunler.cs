//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace entityproject
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblurunler
    {
        public int UrunId { get; set; }
        public string urunAd { get; set; }
        public Nullable<short> stok { get; set; }
        public Nullable<decimal> Alisfiyat { get; set; }
        public Nullable<decimal> satisFiyat { get; set; }
        public Nullable<int> Katogori { get; set; }
    
        public virtual tblkatogori tblkatogori { get; set; }
    }
}

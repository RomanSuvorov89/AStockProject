//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diplom.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rams
    {
        public int id { get; set; }
        public Nullable<int> idManufacture { get; set; }
        public string nameRam { get; set; }
        public Nullable<int> freqRam { get; set; }
        public Nullable<int> typeRam { get; set; }
        public string taiming { get; set; }
        public Nullable<int> capRam { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Count { get; set; }
    
        public virtual Manufacturers Manufacturers { get; set; }
        public virtual partsFreq partsFreq { get; set; }
        public virtual RamType RamType { get; set; }
    }
}

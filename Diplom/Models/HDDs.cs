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
    
    public partial class HDDs
    {
        public int id { get; set; }
        public string nameHDD { get; set; }
        public Nullable<int> capatity { get; set; }
        public Nullable<int> idManufacture { get; set; }
        public Nullable<int> typeHDD { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Count { get; set; }
    
        public virtual HDDType HDDType { get; set; }
        public virtual Manufacturers Manufacturers { get; set; }
    }
}
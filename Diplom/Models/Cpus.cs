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
    
    public partial class Cpus
    {
        public int id { get; set; }
        public Nullable<int> idManufacture { get; set; }
        public string nameCpu { get; set; }
        public Nullable<int> socketCpu { get; set; }
        public Nullable<int> coresCpu { get; set; }
        public string freqCpu { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Count { get; set; }
    
        public virtual Manufacturers Manufacturers { get; set; }
        public virtual Sockets Sockets { get; set; }
    }
}
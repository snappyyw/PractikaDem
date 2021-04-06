//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dem.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Need
    {
        public int id { get; set; }
        public Nullable<int> idClient { get; set; }
        public Nullable<int> idRealtor { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public Nullable<int> MinPrice { get; set; }
        public Nullable<int> MaxPrice { get; set; }
        public string MinSquare { get; set; }
        public string MaxSquare { get; set; }
        public Nullable<int> MinNumberOfRooms { get; set; }
        public Nullable<int> MaxNumberOfRooms { get; set; }
        public Nullable<int> MaxNumberOfFloors { get; set; }
        public Nullable<int> MinNumberOfFloors { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Realtor Realtor { get; set; }
    }
}
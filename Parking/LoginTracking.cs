//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Parking
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoginTracking
    {
        public int LoginId { get; set; }
        public int SystemUserId { get; set; }
        public Nullable<System.DateTime> LoginDate { get; set; }
        public Nullable<System.TimeSpan> TotalOnlineTime { get; set; }
        public string IpAddress { get; set; }
    
        public virtual SystemUser SystemUser { get; set; }
    }
}

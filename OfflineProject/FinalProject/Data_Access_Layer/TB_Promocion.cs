//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data_Access_Layer
{
    using System;
    using System.Collections.Generic;
    
    public partial class TB_Promocion
    {
        public TB_Promocion()
        {
            this.TB_Producto = new HashSet<TB_Producto>();
        }
    
        public int ID_Promocion { get; set; }
        public string TipoPromocion { get; set; }
        public string Descripcion { get; set; }
    
        public virtual ICollection<TB_Producto> TB_Producto { get; set; }
    }
}
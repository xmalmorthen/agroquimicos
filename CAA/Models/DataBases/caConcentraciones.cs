//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CAA.Models.DataBases
{
    using System;
    using System.Collections.Generic;
    
    public partial class caConcentraciones
    {
        public caConcentraciones()
        {
            this.caIngredientesActivos = new HashSet<caIngredientesActivos>();
        }
    
        public int id { get; set; }
        public double Concentracion { get; set; }
        public int idUnidadMedida { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime fIns { get; set; }
        public Nullable<System.DateTime> fAct { get; set; }
    
        public virtual caUnidadesMedida caUnidadesMedida { get; set; }
        public virtual ICollection<caIngredientesActivos> caIngredientesActivos { get; set; }
    }
}

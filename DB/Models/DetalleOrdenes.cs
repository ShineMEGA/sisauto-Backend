using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace DB.Models
{
    public class DetalleOrdenes
    {
        [Key] // Llave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Autonumérico
        public int DetalleOrdenID { get; set; }
        public int OrdenID { get; set; }
        public int ServicioID { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        [JsonIgnore]
        public virtual Ordenes? Orden { get; set; } // Propiedad de navegación
        public virtual Servicios? Servicio { get; set; }
        
    }
}

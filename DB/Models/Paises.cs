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
    public class Paises
    {
        [Key] // Llave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Autonumérico
        public int PaisID { get; set; }
        public string Nombre { get; set; }
        [JsonIgnore]
        public ICollection<Clientes> ?Clientes { get; set; } // Propiedad de navegación hacia los clientes asociados
    }

}

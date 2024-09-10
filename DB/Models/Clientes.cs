using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Clientes : IValidatableObject
    {
        [Key] // Llave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Autonumérico
        public int ClienteID { get; set; }
        //[Required]
        //[StringLength(10,MinimumLength =2)]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        [RegularExpression(@"^\+?52? ?\(?\d{2,3}\)? ?\d{7,8}$", ErrorMessage = "El número de teléfono no es válido.")]
        public string Telefono { get; set; }
        [ForeignKey("PaisID")] // SE DEBE COLOCAR EN FORMATO TEXTO el campo de la llave foranea
        public int PaisID { get; set; } // Clave foránea
        [JsonIgnore]
        public Paises ?Pais { get; set; } // Propiedad de navegación hacia el país asociado

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Nombre.Length>10 || Nombre.Length<2) 
            {
                yield return new ValidationResult("La longitud del nombre es entre 2 y 10 caracteres", new[] {"Nombre"}); 
            }
        }
    }

}

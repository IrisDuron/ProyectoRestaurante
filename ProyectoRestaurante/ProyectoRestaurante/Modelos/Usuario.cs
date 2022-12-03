using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Usuario
    {
        [Required(ErrorMessage = "El Codigo Usuario es Obligatorio")]
        public string CodigoUsuario { get; set; }
        [Required(ErrorMessage = "El Nombre es Obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Rol es Obligatorio")]
        public string Rol { get; set; }
        [Required(ErrorMessage = "La Clave es Obligatorio")]
        public string Clave { get; set; }
        public int EstaActivo { get; set; }


    }
}

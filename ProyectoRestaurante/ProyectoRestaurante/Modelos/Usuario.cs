using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Usuario
    {
        public string CodigoUsuario { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public string Clave { get; set; }
        public int EstaActivo { get; set; }


    }
}

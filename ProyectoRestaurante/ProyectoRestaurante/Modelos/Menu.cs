using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
   
        public class    Menu
        {
            [Required(ErrorMessage = "El código es obligatorio")]
            public int CodigoMenu { get; set; }
            [Required(ErrorMessage = "El nombre es obligatorio")]
            public string Nombre { get; set; }

            [Required(ErrorMessage = "La Descripcion es obligatoria")]
            public string Descripcion { get; set; }

            [Required(ErrorMessage = "El precio es obligatorio")]
             public decimal Precio { get; set; }

            [Required(ErrorMessage = "La categoria es obligatoria")]
            public string Categoria { get; set; }


            [Required(ErrorMessage = "La Cantidad es obligatorio")]

            public int Cantidad { get; set; }
            
           
        }
    
}

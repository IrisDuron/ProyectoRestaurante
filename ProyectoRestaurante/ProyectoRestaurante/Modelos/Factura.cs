﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Factura
    {
        public int Id { get; set; }
        public string IdentidadCliente { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
    }
}

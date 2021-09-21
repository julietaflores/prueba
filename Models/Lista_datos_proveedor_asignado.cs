using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace plataforma3.Models
{
    public class Lista_datos_proveedor_asignado
    {
        public decimal Personaid_cliente { get; set; }
        public decimal serviciopersonaid { get; set; }
        public decimal personaid { get; set; }

        public string personanombres { get; set; }

        public string personaapellidos { get; set; }

        public string personacompleto { get; set; }
        public string RequiereServicioOpcion { get; set; }
        public decimal Opcion { get; set; }

    }
}
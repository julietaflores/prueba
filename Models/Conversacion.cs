using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace plataforma3.Models
{
    public class Conversacion
    {
        public decimal ConversacionId { get; set; }
        public decimal ConversacionPersonaIdEmisor { get; set; }

        public decimal ConversacionPersonaIdReceptor { get; set; }
        public string ServAsigId { get; set; }
        public string ConversacionContenido { get; set; }

        public DateTime ConversacionFechaHora { get; set; }

        public string foto1 { get; set; }
        public string foto2 { get; set; }
    }
}
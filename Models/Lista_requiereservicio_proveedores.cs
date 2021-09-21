using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace plataforma3.Models
{
    public class Lista_requiereservicio_proveedores
    {

        public string requiereservicioid { get; set; }
        public decimal requiereservicioproveedoresid { get; set; }
        public bool requiereservicioproveedoresadj { get; set; }
        public decimal requiereservicioprovcotizacion { get; set; }
        public DateTime  requiereservicioprovfhtrabajo { get; set; }
        public string  requiereservicioprovdescripcion { get; set; }
        public decimal serviciopersonaid { get; set; }
        public DateTime requiereservicioprovfhresp { get; set; }

        public decimal statusrequiereid { get; set; }
    }
}
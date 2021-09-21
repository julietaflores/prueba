using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using plataforma3.Models;
using System.Data.SqlClient;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Runtime.InteropServices;
using FirebaseAPI;
using FireSharp.Serialization;
using FireSharp.Extensions;

namespace plataforma3.Controllers
{
    public class DetalleController : Controller
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "l6nc5NF2IKi6HZGribJbaUeLk1tBDUIUzNglVXlS",
            BasePath = "https://service-web-258723.firebaseio.com/"
        };
        IFirebaseClient client;

        llamadas llamadas = new llamadas();

        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Detalle");
            }
        }

        public ActionResult Indexlbc()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Detalle");
            }
        }

        public ActionResult ListaReq()
        {
            if (Session["UserID"] != null)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Detalle");
            }
        }

        public ActionResult ReqTerminados()
        {
            if (Session["UserID"] != null)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Detalle");
            }
        }
        public ActionResult Proveedores()
        {
            if (Session["UserID"] != null)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Detalle");
            }
        }


        public ActionResult Reporte()
        {
            if (Session["UserID"] != null)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Detalle");
            }
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult mapa(string search_text_form)
        {

            if (Session["UserID"] != null)
            {
                ViewBag.datoid = search_text_form;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Detalle");
            }



        }

        public ActionResult RealizaTuPagodeComision()
        {
            return View();

        }



        public JsonResult GetPersonaGPS(String id)
        {
            List<m_ubicacion> allsearch = new List<m_ubicacion>();

            var ii = 0;
            var datos = id;
                    var ty = 0;
                    foreach (var item1 in datos)
                    {
                        var caracter = datos.Substring(ty, 1);
                        if (caracter == ",")
                        {
                            ii = ty;
                        }
                        ty++;
                    }
                    var u = 0;
                    var lati = "";
                    var longg = "";
                    foreach (var item11 in datos)
                    {
                        if (u < ii)
                        {
                            var caracter = datos.Substring(u, 1);
                            lati = lati + caracter;
                        }
                        else
                        {
                            var caracter = datos.Substring(u, 1);
                            longg = longg + caracter;
                        }
                        u++;
                    }

                    var lop = longg.Substring(1, longg.Count() - 1);
                    allsearch.Add(new m_ubicacion
                    {
                        latitud = lati,
                        longitud = Convert.ToString(lop)
                    });
              
          
            return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        [HttpPost]
        public ActionResult Index_l12(decimal UserId, decimal TPersona)
        {
            Session["UserID"] = UserId;
            Session["TPersona"] = TPersona;
    
            string direccion = "";
            if (TPersona == 1)
            {
                direccion = "Index";
            }
            else
            {
                direccion = "Indexlbc";
            }
            return RedirectToAction(direccion, "Detalle");
        }




        public ActionResult Logout()
        {
            Session["UserID"] = null;
            Session["TPersona"] = null;
            return RedirectToAction("Login", "Detalle");
        }


       
        public JsonResult m_servicio()
        {
            List<m_servicio> allsearch1 = new List<m_servicio>();
            allsearch1 = llamadas.lista3();

            foreach (var item in allsearch1)
            {
                if (item.cont==1)
                {

                    item.color = "#1cc88a";
                }

                if (item.cont == 2)
                {

                    item.color = "#A4502E";
                }

                if (item.cont == 3)
                {

                    item.color = "#5276C4";
                }

                if (item.cont == 4)
                {

                    item.color = "#070F21";
                }

                if (item.cont == 5)
                {

                    item.color = "#BC1BD9";
                }

                if (item.cont == 6)
                {

                    item.color = "#64D0EC";
                }

                if (item.cont == 7)
                {

                    item.color = "#AD213E";
                }

                if (item.cont == 8)
                {

                    item.color = "#0FDF0C";
                }
                if (item.cont == 9)
                {

                    item.color = "#DAD51E";
                }

                if (item.cont == 10)
                {

                    item.color = "#2A0211";
                }
            }




          
            return new JsonResult { Data = allsearch1, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }



        public JsonResult m_usuario()
        {
            List<m_usuario> allsearch1 = new List<m_usuario>();
            allsearch1 = llamadas.lista2();


            return new JsonResult { Data = allsearch1, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult m_proveedor()
        {
            List<m_prove> allsearch1 = new List<m_prove>();
            allsearch1 = llamadas.lista1();


            return new JsonResult { Data = allsearch1, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }



        public JsonResult lista_x_an(int dato)
        {
            DateTime fechatemp;
            fechatemp = DateTime.Today;
            var año = fechatemp.Year;
            var mes = fechatemp.Month;
            var fechap = new DateTime(fechatemp.Year, fechatemp.Month + 1, 1).AddDays(-1).Day;
            List<m_año> allsearch = new List<m_año>();
            var y = "";
            var m = "";
            int total = 0;
            var mesm = 12;
            if (año==dato)
            {
                mesm = mes;
            }
               while (mesm > 0)
               {
                   if (mesm == 12)
                   {
                       fechap = new DateTime(dato, 1, 1).AddDays(-1).Day;
                   }
                   else
                   {
                       fechap = new DateTime(dato, mesm + 1, 1).AddDays(-1).Day;
                   }

                   y = dato + "-" + mesm + "-01";
                   m = dato + "-" + mesm + "-" + fechap;
                   total = llamadas.listaaño(y, m);

                   allsearch.Add(new m_año
                   {
                       mes = mesm,
                       año = año,
                       cantidad = total
                   });
                   mesm--;
               }
            return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        public JsonResult geolocalizacion(decimal personaid , decimal personadireccionid)
        {

            string valor = llamadas.Geolocalizacin(personaid, personadireccionid);


            return new JsonResult { Data = valor, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }






        public JsonResult detallereq(string reqid)
        {
        
            List<detalle_sr> allsearch = new List<detalle_sr>();

            allsearch = llamadas.listadet1(reqid);


            return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }



        public JsonResult detallereq1(string reqid)
        {


         
            List<detalle_sr1> allsearch = new List<detalle_sr1>();
            allsearch = llamadas.listadet11(reqid);
            return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };


        }




        public ActionResult Conversacion(string id)
        {
            if (Session["UserID"] != null)
            {
                List<Conversacion> allsearch = new List<Conversacion>();
                allsearch = llamadas.conver(id);   
                return View(allsearch.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Detalle");
            }
        }

        public JsonResult devolver_servicio_de_Req_adudicado(string req_id)
        {
            try
            {

                List<Servicioid_adjudicado> allsearch = new List<Servicioid_adjudicado>();
                allsearch = llamadas.likerequerimiento(req_id);

                return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public JsonResult devolver_proveedores(string like_proveedores)
        {
            try
            {

                List<Lista_proveedores> allsearch = new List<Lista_proveedores>();
                allsearch = llamadas.lista_de_personas_proveedor(like_proveedores);

                return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public JsonResult lista_de_proveedores_activos_de_un_servicio_x(decimal idservicio, decimal menos_pro, string req_id)
        {
          
            List<Lista_datos_proveedor_asignado> allsearch = new List<Lista_datos_proveedor_asignado>();
            allsearch = llamadas.ListaProveedor(idservicio, menos_pro, req_id);
          
            return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }




        public async Task<JsonResult> Actualizar_servicio_persona_imagen(decimal personaid, string url) {

            ClaseConexion conexxion = new ClaseConexion("cadenaCnx");
            conexxion.Conectar();
            string results4 = "update serviciopersona set ServicioPersonaURLFoto='" + url + "' where  PersonaId=" + personaid;
            conexxion.CrearComando(results4);
            conexxion.EjecutarComando();
            conexxion.Desconectar();
            return new JsonResult { Data = "Imagen Actualizada", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        public async Task<JsonResult> ActualizarrequiereservicioproveedoresAsync(string req_id, decimal spid, decimal personaid, decimal opcion )
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
                ClaseConexion conexxion = new ClaseConexion("cadenaCnx");
                string direccion1 = llamadas.direccionpersonaadjudicada(req_id);
                string direccion2 = llamadas.direccionpersonaparaadjudicar(req_id, spid);
                string servasigid = llamadas.obtenerserviasig(req_id);
                int canti = llamadas.obtenerconversacion(servasigid);
                conexxion.Conectar();
                //mensajess
                if (canti > 0)
                {
                    string results5 = "delete from NotificacionPersona  where  RequiereServicioid='" + req_id + "' and ConceptoNotificacionId=9";
                    conexxion.CrearComando(results5);
                    conexxion.EjecutarComando();
                    string resuls6 = "delete from  conversacion where servasigid='" + servasigid + "'";
                    conexxion.CrearComando(resuls6);
                    conexxion.EjecutarComando();
                    if (client != null)
                    {
                        decimal clienteid = Convert.ToDecimal(llamadas.obtenerpersonaid(req_id));
                        decimal proveedorid = personaid;
                        FirebaseResponse response1 = await client.DeleteAsync("Mensajes/" + clienteid + "/" + proveedorid + "/" + req_id);
                        FirebaseResponse response2 = await client.DeleteAsync("Mensajes/" + proveedorid + "/" + clienteid + "/" + req_id);
                    }
                }


                if ( direccion2 =="")
                {
                    List<Lista_requiereservicio_proveedores> allsearch1 = new List<Lista_requiereservicio_proveedores>();
                    allsearch1 = llamadas.ListaProveedores_des(req_id);
                    foreach (Lista_requiereservicio_proveedores item in allsearch1)
                    {

                      
                        string requiereservicioid = item.requiereservicioid;
                        decimal requiereservicioproveedoresid = item.requiereservicioproveedoresid+1;
                        bool requiereservicioproveedoresadj = item.requiereservicioproveedoresadj;
                        decimal requiereservicioprovcotizacion = item.requiereservicioprovcotizacion;
                        int i789 = (int)Math.Ceiling(requiereservicioprovcotizacion);
                        DateTime requiereservicioprovfhtrabajo = item.requiereservicioprovfhtrabajo;
                        string requiereservicioprovdescripcion = item.requiereservicioprovdescripcion;
                        decimal serviciopersonaid = item.serviciopersonaid;
                        DateTime requiereservicioprovfhresp = item.requiereservicioprovfhresp;
                        decimal statusrequiereid = item.statusrequiereid;
                        string resultsact = "insert into RequiereServicioProveedores values('"+req_id+"',"+requiereservicioproveedoresid+",0,"+i789+",'"+requiereservicioprovfhtrabajo+"','"+requiereservicioprovdescripcion+"',"+spid+",'"+requiereservicioprovfhresp+"',1)";
                        conexxion.CrearComando(resultsact);
                        conexxion.EjecutarComando();
                    }
                    direccion2 = llamadas.direccionpersonaparaadjudicar(req_id, spid);
                }


                string nombrereasignado = llamadas.obtenernombreproveedorreasignado(personaid);
                string foto = llamadas.obtenerfotoproveedorreasignado(spid);
                string results = "update requiereservicioproveedores set statusrequiereid=1 where requiereservicioid='" + req_id + "' ";
                string results1 = "update requiereservicioproveedores set statusrequiereid=4 where requiereservicioid='" + req_id + "' and serviciopersonaid=" + spid;
                string results2 = "update  servasig  set proveedorid=" + personaid + " where requiereservicioid='" + req_id + "'";
                conexxion.CrearComando(results);
                conexxion.EjecutarComando();

                conexxion.CrearComando(results1);
                conexxion.EjecutarComando();

                conexxion.CrearComando(results2);
                conexxion.EjecutarComando();


                string results3 = llamadas.notificacionpersonaid(req_id);
                string results4 = "update notificacionpersona set personaid=" + personaid + " where  notificacionpersonaid=" + results3;

                conexxion.CrearComando(results4);
                conexxion.EjecutarComando();
                await UpdateFirebase1(req_id, direccion1, direccion2, nombrereasignado, foto, personaid, opcion);
                conexxion.Desconectar();





                return new JsonResult { Data = "Actualizados", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


  

    
        public  async Task<int> UpdateFirebase1(string reqid, string direccion1, string direccion2, string nombrereasignado, string foto, decimal personaid, decimal opcion)
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "l6nc5NF2IKi6HZGribJbaUeLk1tBDUIUzNglVXlS",
                BasePath = "https://service-web-258723.firebaseio.com/"
            };
            IFirebaseClient client;
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {


                var data1 = new Data1
                {
                    EstadoRecepcion = 0,
                    PersonaProveedorId = "",
                    ProveedorNombre = "",
                    RequiereServicioId = "",
                    StatusRequiereId = 0,
                    TipoEstado = 0               
                };

             


                var RequiereServicioS = new RequiereServicioS
                {
                    EstadoReqServId = "",
                    PersonaDireccionNombre = "",
                    PersonaDireccionS = "",
                    PersonaId = 0,
                    PersonaNombre = "",
                    PersonaTelefono = "",
                    PersonaURLFoto = "",
                    RequerimientoPrecio = "",
                    RequiereServicioDescripcion = "",
                    RequiereServicioFHCaduca = "",
                    RequiereServicioFHDeseada = "",
                    RequiereServicioURLFoto1 = "",
                    RequiereServicioURLFoto2 = "",
                    RequiereServicioURLFoto3 = "",
                    RequiereServicioURLVideo = "",
                    RequiereServicioid = ""
                };
                var ServAsigS = new ServAsigS
                {

                    ServAsigId = "",
                    ProveedorNombre = "",
                    ServAsigFHInicio = "",
                    ServAsigFHFin = "",
                    ServAsigFHPago = "",
                    StatusServAsigId = "",
                    servAsigCalificacion = ""
                };


               // if (opcion==1) {
                    FirebaseResponse response = await client.GetAsync("Sincronizacion/" + reqid + "/RequiereServicioProveedoresS/" + direccion1);
                    if (response.Body != "null")
                    {
                        Data1 obj = response.ResultAs<Data1>();
                        obj.StatusRequiereId = 1;
                        data1 = obj;
                        await client.UpdateAsync("Sincronizacion/" + reqid + "/RequiereServicioProveedoresS/" + direccion1, data1);

                    }

                    FirebaseResponse response1 = await client.GetAsync("Sincronizacion/" + reqid + "/RequiereServicioProveedoresS/" + direccion2);
                    if (response1.Body != "null")
                    {
                        Data1 obj = response1.ResultAs<Data1>();
                        obj.StatusRequiereId = 4;
                        data1 = obj;
                        FirebaseResponse responseUpdate = await client.UpdateAsync("Sincronizacion/" + reqid + "/RequiereServicioProveedoresS/" + direccion2, data1);

                    }
                    else
                    {
                        var data48 = new Data1
                        {
                            EstadoRecepcion = 1,
                            PersonaProveedorId = personaid.ToString(),
                            ProveedorNombre = nombrereasignado,
                            RequiereServicioId = reqid,
                            StatusRequiereId = 4,
                            TipoEstado = 0

                        };
                        await client.UpdateAsync("Sincronizacion/" + reqid + "/RequiereServicioProveedoresS/" + direccion1, data48);
                    }



                    FirebaseResponse response2 = await client.GetAsync("Sincronizacion/" + reqid + "/RequiereServicioS");
                    if (response2.Body != "null")
                    {
                        RequiereServicioS obj = response2.ResultAs<RequiereServicioS>();
                        obj.PersonaURLFoto = "https://serviceweb.bo/Resources/MediaIcons/" + foto;
                        RequiereServicioS = obj;
                        await client.UpdateAsync("Sincronizacion/" + reqid + "/RequiereServicioS", RequiereServicioS);
                        // Data1 result = responseUpdate.ResultAs<Data1>();
                    }
                    FirebaseResponse response3 = await client.GetAsync("Sincronizacion/" + reqid + "/ServAsigS");
                    if (response3.Body != "null")
                    {
                        ServAsigS obj = response3.ResultAs<ServAsigS>();
                        obj.ProveedorNombre = nombrereasignado;
                        ServAsigS = obj;
                        await client.UpdateAsync("Sincronizacion/" + reqid + "/ServAsigS", ServAsigS);
                        // Data1 result = responseUpdate.ResultAs<Data1>();
                    }
              //  }


             
            }

            return 0;
        }
        public JsonResult devolver_nombre(string req_id)
        {
            try
            {
                List<Nombre_proveedor> allsearch = new List<Nombre_proveedor>();
                allsearch = llamadas.BuscaProveedor(req_id);
                return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public JsonResult devolver_lista_servicios(decimal personaid)
        {
            try
            {
                List<Lista_servicios_proveedor> allsearch = new List<Lista_servicios_proveedor>();
                allsearch = llamadas.BuscaServicio_p(personaid);
                return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        [HttpGet]
        public ActionResult Details(string id)
        {

            if (Session["UserID"] != null)
            {

             
                ViewBag.dt = id;
                return View();

            }
            else
            {
                return RedirectToAction("Login", "Detalle");
            }

        }
        internal class Data1
        {
            public int EstadoRecepcion { get; set; }
            public string PersonaProveedorId { get; set; }
            public string ProveedorNombre { get; set; }
            public string RequiereServicioId { get; set; }
            public int StatusRequiereId { get; set; }
            public int TipoEstado { get; set; }
        }

        internal class RequiereServicioS
        {
            public string EstadoReqServId { get; set; }
           
            public string PersonaDireccionNombre { get; set; }
            public string PersonaDireccionS { get; set; }
            public decimal PersonaId { get; set; }
            public string PersonaNombre { get; set; }
            public string PersonaTelefono { get; set; }
            public string PersonaURLFoto { get; set; }
            public string RequerimientoPrecio { get; set; }
            public string RequiereServicioDescripcion { get; set; }
            public string RequiereServicioFHCaduca { get; set; }
            public string RequiereServicioFHDeseada { get; set; }
            public string RequiereServicioURLFoto1 { get; set; }
            public string RequiereServicioURLFoto2 { get; set; }
            public string RequiereServicioURLFoto3 { get; set; }
            public string RequiereServicioURLVideo { get; set; }
            public string RequiereServicioid { get; set; }
            public List<IdiomaS> ServicioId { get; set; }
         
        }

        public class IdiomaS 
        {
            public string IdiomaSigla { get; set; }
            public string Definicion { get; set; }
        }
        internal class ServAsigS
        {

            public string ProveedorNombre { get; set; }
            public string ServAsigFHFin { get; set; }
            public string ServAsigFHInicio { get; set; }
            public string ServAsigFHPago { get; set; }
            public string ServAsigId { get; set; }
            public string StatusServAsigId { get; set; }
            public string servAsigCalificacion { get; set; }
        }

    }
}

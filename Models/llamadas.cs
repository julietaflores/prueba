using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace plataforma3.Models
{
    public class llamadas
    {



        public llamadas() : base()
        {
        }

        public llamadas(string cadConx)
        {

        }
        public ClaseConexion dbConexion { get; set; }


        public List<m_servicio> CargarBE(DataRow[] dr)
        {
            List<m_servicio> lst = new List<m_servicio>();
            decimal cony = 1;
            foreach (var item in dr)
            {


                lst.Add(CargarBE(item, cony));
                cony = cony + 1;
            }
            return lst;
        }

        public m_servicio CargarBE(DataRow dr, decimal cony)
        {
            m_servicio obj = new m_servicio();
            obj.cont = cony;
            obj.idp = Convert.ToDecimal(dr["ServicioId"].ToString());
            obj.Nombrec = dr["ServicioNombre"].ToString();
            obj.cantidadc = Convert.ToInt32(dr["cantidad"].ToString());

            return obj;
        }

        public List<m_servicio> lista3()
        {
            List<m_servicio> obj = null;
            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"select top 10 r.ServicioId ,ss.ServicioNombre,  COUNT(r.ServicioId) as cantidad from RequiereServicio r
inner join Servicio ss  on ss.ServicioId= r.ServicioId
inner join Persona p on p.PersonaId= r.PersonaId
where r.PersonaId  NOT IN(SELECT pp.PersonaId   FROM PersonalPreuba  pp) 
and p.CiudadId=2 and ss.ServicioId>=500 and ss.ServicioId!= 513
group by r.Servicioid ,ss.ServicioNombre
order by COUNT(r.ServicioId) desc");
                DataRow[] dr = conx.ObtenerFilas(sql);
                if (dr != null)
                {
                    obj = CargarBE(dr);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }





        public List<m_usuario> CargarBE2(DataRow[] dr)
        {
            List<m_usuario> lst = new List<m_usuario>();
            int cony = 1;
            foreach (var item in dr)
            {
                lst.Add(CargarBE2(item, cony));
                cony = cony + 1;
            }
            return lst;
        }

        public m_usuario CargarBE2(DataRow dr, int cony)
        {
            m_usuario obj = new m_usuario();
            obj.i = cony;
            obj.idp = Convert.ToDecimal(dr["PersonaId"].ToString());
            obj.Nombrec = dr["PersonaNombres"].ToString() +" " + dr["PersonaApellidos"].ToString();
            obj.cantidadc = Convert.ToInt32(dr["cantidad"].ToString());

            return obj;
        }

        public List<m_usuario> lista2()
        {
            List<m_usuario> obj = null;
            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"select top 10 p.PersonaId ,p.PersonaNombres,p.PersonaApellidos ,COUNT(r.RequiereServicioId) as cantidad from RequiereServicio r 
inner join Persona p on p.PersonaId= r.PersonaId
where r.PersonaId  NOT IN(SELECT pp.PersonaId   FROM PersonalPreuba  pp) 
group by p.PersonaId,p.PersonaNombres,p.PersonaApellidos
order by COUNT(r.RequiereServicioId) desc");
                DataRow[] dr = conx.ObtenerFilas(sql);
                if (dr != null)
                {
                    obj = CargarBE2(dr);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }





        public List<m_prove> CargarBE1(DataRow[] dr)
        {
            List<m_prove> lst = new List<m_prove>();
            int cony = 1;
            foreach (var item in dr)
            {
                lst.Add(CargarBE1(item, cony));
                cony = cony + 1;
            }
            return lst;
        }

        public m_prove CargarBE1(DataRow dr, int cony)
        {
            m_prove obj = new m_prove();
            obj.i = cony;
            obj.idp = Convert.ToDecimal(dr["ProveedorId"].ToString());
            obj.Nombrec = dr["PersonaNombres"].ToString() + " " + dr["PersonaApellidos"].ToString();
            obj.cantidadc = Convert.ToInt32(dr["cantidad"].ToString());

            return obj;
        }

        public List<m_prove> lista1()
        {
            List<m_prove> obj = null;
            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@" select top 10 ss.ProveedorId ,p.PersonaNombres, p.PersonaApellidos, COUNT(r.RequiereServicioId)  as cantidad from RequiereServicio r
  inner join ServAsig ss on ss.RequiereServicioId = r.RequiereServicioId
  inner join Persona p on p.PersonaId= ss.ProveedorId
  where  ss.ProveedorId  NOT IN(SELECT pp.PersonaId   FROM PersonalPreuba  pp) and ss.StatusServAsigId in (1,2,3,4) and r.EstadoReqServId=2
  group by ss.ProveedorId,p.PersonaNombres, p.PersonaApellidos
  order by COUNT(r.RequiereServicioId) desc");
                DataRow[] dr = conx.ObtenerFilas(sql);
                if (dr != null)
                {
                    obj = CargarBE1(dr);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }





        public int listaaño(string f1, string f2)
        {
            int obj = 0;
            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"SELECT sg.* FROM ServAsig sg INNER JOIN RequiereServicio r ON  sg.RequiereServicioId = r.RequiereServicioId 
           INNER JOIN Persona pe  ON sg.ProveedorId = pe.PersonaId and sg.ProveedorId NOT IN(SELECT pp.PersonaId   FROM PersonalPreuba  pp) 
           where (sg.StatusServAsigId = 3 or sg.StatusServAsigId = 4)  and   pe.CiudadId=2  and sg.ServAsigFHInicio between '" + f1 + " 00:00:00' and '" + f2 + " 23:59:59'");
                DataRow[] dr = conx.ObtenerFilas(sql);
                if (dr != null)
                {

                    int cant = dr.Count();

                    if (cant > 0)
                    {
                        obj = cant;
                    }
                    else
                    {
                        obj = 0;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }



        public string Geolocalizacin(decimal personaid, decimal personadireccionid)
        {
            
            string obj = "";


            if (Convert.ToInt32(personadireccionid)>0)
            {
                ClaseConexion conx = new ClaseConexion("cadenaCnx");
                try
                {
                    string sql = String.Format(@"select pd.PersonaDireccionGeo from Persona p
inner join PersonaDireccion pd on pd.PersonaId= p.PersonaId
where p.PersonaId=" + Convert.ToInt32(personaid) + " and pd.PersonaDireccionId=" + Convert.ToInt32(personadireccionid));
                    DataRow[] dr = conx.ObtenerFilas(sql);
                    if (dr != null)
                    {

                        foreach (DataRow row in dr)
                        {

                           obj= row[0].ToString(); 
                        }


                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            else
            {
                obj = "100";

            }
           
            return obj;
        }





        public List<detalle_sr> CargarBEdet1(DataRow[] dr)
        {
            List<detalle_sr> lst = new List<detalle_sr>();
  
            foreach (var item in dr)
            {
                lst.Add(CargarBE2det1(item));
           
            }
            return lst;
        }

        public detalle_sr CargarBE2det1(DataRow dr)
        {
            detalle_sr obj = new detalle_sr();
            obj.nombre = dr["ServicioDetalleDescripcion"].ToString();
            obj.precio = dr["ServicioDetallePrecioUnitario"].ToString();
            obj.cantidad = dr["ServicioDetalleCantidad"].ToString();

            return obj;
        }

        public List<detalle_sr> listadet1(string reqid)
        {
            List<detalle_sr> obj = null;
            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"select sd.ServicioDetalleDescripcion, sd.ServicioDetallePrecioUnitario, rd.ServicioDetalleCantidad from RequiereServicioDetalle rd
inner join ServicioDetalle  sd on sd.ServicioId = rd.ServicioId and sd.ServicioDetalleId= rd.ServicioDetalleId
where rd.RequiereServicioId='"+reqid+ "'  and rd.ServicioDetalleCantidad>0");
                DataRow[] dr = conx.ObtenerFilas(sql);
                if (dr != null)
                {
                    obj = CargarBEdet1(dr);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }



        public List<detalle_sr1> CargarBEdet11(DataRow[] dr)
        {
            List<detalle_sr1> lst = new List<detalle_sr1>();

            foreach (var item in dr)
            {
                lst.Add(CargarBE2det11(item));

            }
            return lst;
        }

        public detalle_sr1 CargarBE2det11(DataRow dr)
        {
            detalle_sr1 obj = new detalle_sr1();
            obj.serviciodetalleid = dr["ServicioDetalleId"].ToString();
            obj.descripcion = dr["ServicioDetalleDescripcion"].ToString();
            obj.costo_inicial= dr["ServicioDetalleCostoInicial"].ToString();
            obj.costo_final = dr["ServicioDetalleCostoFinal "].ToString();

            return obj;
        }

        public List<detalle_sr1> listadet11(string reqid)
        {
            List<detalle_sr1> obj = null;
            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"select sd.ServicioDetalleId, sd.ServicioDetalleDescripcion, sd.ServicioDetalleCostoInicial, sd.ServicioDetalleCostoFinal from RequiereServicio r
inner join ServicioDetalle sd on sd.ServicioId= r.ServicioId
where r.RequiereServicioId='"+reqid+"'");
                DataRow[] dr = conx.ObtenerFilas(sql);
                if (dr != null)
                {
                    obj = CargarBEdet11(dr);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }







        public List<Conversacion> conversacion(DataRow[] dr)
        {
            List<Conversacion> lst = new List<Conversacion>();

            foreach (var item in dr)
            {
                lst.Add(conversacion(item));

            }
            return lst;
        }

        public Conversacion conversacion(DataRow dr)
        {
            Conversacion obj = new Conversacion();
            obj.ConversacionId = Convert.ToDecimal(dr["ConversacionId"].ToString());
            obj.ConversacionPersonaIdEmisor = Convert.ToDecimal(dr["ConversacionPersonaIdEmisor"].ToString());
            obj.ConversacionPersonaIdReceptor = Convert.ToDecimal(dr["ConversacionPersonaIdReceptor"].ToString());
            obj.ServAsigId = dr["ServAsigId"].ToString();
            obj.ConversacionContenido = dr["ConversacionContenido"].ToString();
            obj.ConversacionFechaHora = Convert.ToDateTime(dr["ConversacionFechaHora"].ToString());
            obj.foto1= dr["emisor"].ToString();
            obj.foto2 = dr["receptor"].ToString();

            return obj;
        }

        public List<Conversacion> conver(string reqid)
        {
            List<Conversacion> obj = null;
            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"select c.* ,pp.PersonaURLFoto as emisor,pp1.PersonaURLFoto as receptor from Conversacion c
inner join Persona pp on pp.PersonaId= c.ConversacionPersonaIdEmisor
inner join Persona pp1 on pp1.PersonaId= c.ConversacionPersonaIdReceptor
where c.ServAsigId='"+reqid+"'");
                DataRow[] dr = conx.ObtenerFilas(sql);
                if (dr != null)
                {
                    obj = conversacion(dr);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }




        public List<Servicioid_adjudicado> likereq(DataRow[] dr)
        {
            List<Servicioid_adjudicado> lst = new List<Servicioid_adjudicado>();

            foreach (var item in dr)
            {
                lst.Add(likereq(item));

            }
            return lst;
        }

        public Servicioid_adjudicado likereq(DataRow dr)
        {
            Servicioid_adjudicado obj = new Servicioid_adjudicado();
            obj.id_servicio = dr["ServicioId"].ToString();
            obj.requiereservicioid = dr["RequiereServicioId"].ToString();
          
            return obj;
        }

        public List<Servicioid_adjudicado> likerequerimiento(string reqid)
        {
            List<Servicioid_adjudicado> obj = null;
            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"Select s.RequiereServicioId, s.ServicioId from requiereservicio s where  s.requiereservicioid  like '" + reqid+"%'");
                DataRow[] dr = conx.ObtenerFilas(sql);
                if (dr != null)
                {
                    obj = likereq(dr);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }





        public List<Nombre_proveedor> Buscap(DataRow[] dr)
        {
            List<Nombre_proveedor> lst = new List<Nombre_proveedor>();

            foreach (var item in dr)
            {
                lst.Add(Buscap(item));

            }
            return lst;
        }

        public Nombre_proveedor Buscap(DataRow dr)
        {
            Nombre_proveedor obj = new Nombre_proveedor();
            obj.nombre_completo = dr["PersonaNombres"].ToString()+" "+ dr["PersonaApellidos"].ToString(); 
            obj.id_proveedor = Convert.ToDecimal(dr["PersonaId"].ToString());
            obj.opcion_de_req = dr["RequiereServicioOpcion"].ToString();

            return obj;
        }

        public List<Nombre_proveedor> BuscaProveedor(string reqid)
        {
            List<Nombre_proveedor> obj = null;
            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"select p.PersonaNombres, p.PersonaApellidos, p.PersonaId , rr.RequiereServicioOpcion from  persona p inner join servasig sg on sg.proveedorid = p.personaid  inner join RequiereServicio rr on rr.RequiereServicioId= sg.RequiereServicioId where sg.requiereservicioid='"+reqid+"'");
                DataRow[] dr = conx.ObtenerFilas(sql);
                if (dr != null)
                {
                    obj = Buscap(dr);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }





        public List<Lista_datos_proveedor_asignado> listaap(DataRow[] dr)
        {
            List<Lista_datos_proveedor_asignado> lst = new List<Lista_datos_proveedor_asignado>();

            foreach (var item in dr)
            {
                lst.Add(listaap(item));

            }
            return lst;
        }

        public Lista_datos_proveedor_asignado listaap(DataRow dr)
        {
            Lista_datos_proveedor_asignado obj = new Lista_datos_proveedor_asignado();
            obj.Personaid_cliente = Convert.ToDecimal(dr["cliente"].ToString());
            obj.serviciopersonaid = Convert.ToDecimal(dr["ServicioPersonaId"].ToString());
            obj.personaid = Convert.ToDecimal(dr["PersonaId"].ToString());
            obj.personanombres = dr["PersonaNombres"].ToString();
            obj.personaapellidos = dr["PersonaApellidos"].ToString();
            obj.personacompleto = dr["PersonaNombres"].ToString() + " " + dr["PersonaApellidos"].ToString();
            obj.RequiereServicioOpcion = dr["RequiereServicioOpcion"].ToString();
            obj.Opcion = Convert.ToDecimal(dr["Opcion"].ToString());
            return obj;
        }

        public List<Lista_datos_proveedor_asignado> ListaProveedor(decimal servicioid, decimal personaid, string req_id)
        {
            List<Lista_datos_proveedor_asignado> obj = null;
            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"select rt.PersonaId as cliente, sp.ServicioPersonaId, sp.PersonaId, p.PersonaNombres, p.PersonaApellidos , rt.RequiereServicioOpcion,
case when (rt.RequiereServicioOpcion = 'Normal') then 1 else 2  end as Opcion from persona p
 inner join serviciopersona sp on sp.personaid = p.personaid  inner join RequiereServicio rt on rt.ServicioId = sp.ServicioId
where sp.servicioid ='" + Convert.ToInt32(servicioid)+ "' and rt.RequiereServicioId='"+req_id+"' and sp.statusservicioid = 1 and sp.estadoservicioid = 1 and sp.personaid!='" + Convert.ToInt32(personaid)+"'");
                DataRow[] dr = conx.ObtenerFilas(sql);
                if (dr != null)
                {
                    obj = listaap(dr);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }

        public string notificacionpersonaid(string req_id)
        {
            string obj = "";
      
                ClaseConexion conx = new ClaseConexion("cadenaCnx");
                try
                {
                    string sql = String.Format(@"select top 1 np.NotificacionPersonaId  from notificacionpersona np where np.requiereservicioid='" + req_id + "' and conceptonotificacionid=5");
                    DataRow[] dr = conx.ObtenerFilas(sql);
                    if (dr != null)
                    {

                        foreach (DataRow row in dr)
                        {

                        obj = row[0].ToString();
                        }


                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

         

            return obj;
        }


        public string obtenerserviasig(string req_id)
        {
            string obj = "";

            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"select ServAsigId from ServAsig where RequiereServicioId='" + req_id+"'");
                DataRow[] dr = conx.ObtenerFilas(sql);
                if (dr != null)
                {
                    foreach (DataRow row in dr)
                    {
                        obj = row[0].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }
        public string obtenerpersonaid(string req_id)
        {
            string obj = "";

            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"select PersonaId from RequiereServicio where RequiereServicioId='" + req_id + "'");
                DataRow[] dr = conx.ObtenerFilas(sql);
                if (dr != null)
                {
                    foreach (DataRow row in dr)
                    {
                        obj = row[0].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }

        public int obtenerconversacion(string servasigid)
        {
            int obj = 0;

            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"select * from Conversacion where ServAsigId='"+servasigid+"'");
                DataRow[] dr = conx.ObtenerFilas(sql);
                if (dr != null)
                {
                    int cant = dr.Count();

                    if (cant > 0)
                    {
                        obj = cant;
                    }
                    else
                    {
                        obj = 0;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }


        public string direccionpersonaadjudicada(string req_id)
        {
            string obj = "";

            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"select rp.RequiereServicioProveedoresId from RequiereServicioProveedores rp where rp.RequiereServicioId='"+req_id+"'  and rp.StatusRequiereId=4");
                DataRow[] dr = conx.ObtenerFilas(sql);
                if (dr != null)
                {
                    foreach (DataRow row in dr)
                    {
                        obj = row[0].ToString();
                        int valor = Convert.ToInt32(obj) - 1;
                        obj = Convert.ToString(valor);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }


        public string direccionpersonaparaadjudicar(string req_id, decimal  serviciopersonaid)
        {
            string obj = "";

            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"select rp.RequiereServicioProveedoresId from RequiereServicioProveedores rp  where rp.RequiereServicioId='"+req_id+"' and rp.ServicioPersonaId=" + Convert.ToInt32(serviciopersonaid)) ;
                DataRow[] dr = conx.ObtenerFilas(sql);
                if (dr != null)
                {
                    foreach (DataRow row in dr)
                    {
                        obj = row[0].ToString();
                        int valor = Convert.ToInt32(obj) - 1;
                        obj = Convert.ToString(valor);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }



        public string obtenernombreproveedorreasignado(decimal personaid)
        {
            string obj = "";

            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"select sp.PersonaNombres from persona sp where sp.PersonaId="+ Convert.ToInt32(personaid));
                DataRow[] dr = conx.ObtenerFilas(sql);
                if (dr != null)
                {
                    foreach (DataRow row in dr)
                    {
                        obj = row[0].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }


        public string obtenerfotoproveedorreasignado(decimal serviciopersonaid)
        {
            string obj = "";

            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"select sp.ServicioPersonaURLFoto from serviciopersona sp where sp.ServicioPersonaId=" + Convert.ToInt32(serviciopersonaid)) ;
                DataRow[] dr = conx.ObtenerFilas(sql);
                if (dr != null)
                {
                    foreach (DataRow row in dr)
                    {
                        obj = row[0].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }


        public List<Lista_requiereservicio_proveedores> listaap_prov(DataRow[] dr)
        {
            List<Lista_requiereservicio_proveedores> lst = new List<Lista_requiereservicio_proveedores>();

            foreach (var item in dr)
            {
                lst.Add(listaap_prov(item));

            }
            return lst;
        }

        public Lista_requiereservicio_proveedores listaap_prov(DataRow dr)
        {
            Lista_requiereservicio_proveedores obj = new Lista_requiereservicio_proveedores();
            obj.requiereservicioid = dr["RequiereServicioId"].ToString();
            obj.requiereservicioproveedoresid = Convert.ToDecimal(dr["RequiereServicioProveedoresId"].ToString());
            obj.requiereservicioproveedoresadj = Convert.ToBoolean(dr["RequiereServicioProveedoresAdj"].ToString());
            obj.requiereservicioprovcotizacion = Convert.ToDecimal(dr["RequiereServicioProvCotizacion"].ToString());
            obj.requiereservicioprovfhtrabajo = Convert.ToDateTime(dr["RequiereServicioProvFHTrabajo"].ToString());
            obj.requiereservicioprovdescripcion = dr["RequiereServicioProvDescipcion"].ToString();
            obj.serviciopersonaid = Convert.ToDecimal(dr["ServicioPersonaId"].ToString());
            obj.requiereservicioprovfhresp = Convert.ToDateTime(dr["RequiereServicioProvFHResp"].ToString());
            obj.statusrequiereid = Convert.ToDecimal(dr["StatusRequiereId"].ToString());
            return obj;
        }

        public List<Lista_requiereservicio_proveedores> ListaProveedores_des( string req_id)
        {
            List<Lista_requiereservicio_proveedores> obj = null;
            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"select top 1 * from RequiereServicioProveedores where RequiereServicioId='"+req_id+"' order by RequiereServicioProveedoresId desc");
                DataRow[] dr = conx.ObtenerFilas(sql);
                if (dr != null)
                {
                    obj = listaap_prov(dr);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }





        public List<Lista_proveedores> likepersonapro(DataRow[] dr)
        {
            List<Lista_proveedores> lst = new List<Lista_proveedores>();

            foreach (var item in dr)
            {
                lst.Add(likepersonapro(item));

            }
            return lst;
        }

        public Lista_proveedores likepersonapro(DataRow dr)
        {
            Lista_proveedores obj = new Lista_proveedores();
            obj.personaid = Convert.ToDecimal(dr["PersonaId"].ToString());
            obj.nombre = dr["nombre"].ToString();

            return obj;
        }

        public List<Lista_proveedores> lista_de_personas_proveedor(string nombre_pro)
        {
            List<Lista_proveedores> obj = null;
            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"Select p.PersonaId,CONCAT(p.PersonaNombres,' ' ,p.PersonaApellidos) as nombre from Persona p  where  p.PersonaNombres  like '%" + nombre_pro + "%'");
                DataRow[] dr = conx.ObtenerFilas(sql);
                if (dr != null)
                {
                    obj = likepersonapro(dr);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }










        public List<Lista_servicios_proveedor> Buscap_servicio(DataRow[] dr)
        {
            List<Lista_servicios_proveedor> lst = new List<Lista_servicios_proveedor>();
            foreach (var item in dr)
            {
                lst.Add(Buscap_servicio(item));
            }
            return lst;
        }

        public Lista_servicios_proveedor Buscap_servicio(DataRow dr)
        {
            Lista_servicios_proveedor obj = new Lista_servicios_proveedor();
            obj.nombre_servicio = dr["nombre_servicio"].ToString();
            obj.servicioid = Convert.ToDecimal(dr["ServicioId"].ToString());
            return obj;
        }

        public List<Lista_servicios_proveedor> BuscaServicio_p(decimal personaid)
        {
            List<Lista_servicios_proveedor> obj = null;
            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"select CONCAT(e.EquivalenciaValor,'    (',es.EstadoServicioNombre,')')  as nombre_servicio, s.ServicioId from ServicioPersona  sp
inner join Servicio s on s.ServicioId= sp.ServicioId
inner join EstadoServicio es on es.EstadoServicioId= sp.EstadoServicioId
inner join Equivalencia e on e.EquivalenciaObjetoId = s.ServicioId
where  e.ObjetoId=12 and e.IdiomaId=2 and sp.PersonaId=" + Convert.ToInt32(personaid));
                DataRow[] dr = conx.ObtenerFilas(sql);
                if (dr != null)
                {
                    obj = Buscap_servicio(dr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }




    }
}
using cmpComercio.Comercio;
using cmpComercio.Transaccion;
using cmpComercio.Usuario;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ZonaPagoApp.ConsumoServicio
{
    public class ConsumoServicios
    {
        public static void PostItem()
        {
            JObject jsonObj = new JObject();

            var url = $"http://pbiz.zonavirtual.com/api/Prueba/Consulta";
            var request = (HttpWebRequest)WebRequest.Create(url);
            string json = $"{{\"comercio_codigo\":\"\",\"comercio_nombre\":\"\"" +
                $",\"comercio_nit\":\"\"" +
                $",\"comercio_direccion\":\"\"" +
                $",\"Trans_codigo\":\"\"" +
                $",\"Trans_medio_pago\":\"\"" +
                $",\"Trans_estado\":\"\"" +
                $",\"Trans_total\":\"\"" +
                $",\"Trans_fecha\":\"\"" +
                $",\"Trans_concepto\":\"\"" +
                $",\"usuario_identificacion\":\"\"" +
                $",\"usuario_nombre\":\"\"" +
                $",\"usuario_email\":\"\"}}";

            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            var listProductos = JsonConvert.DeserializeObject<List<ExpandoObject>>(responseBody);

                            foreach (dynamic prod in listProductos)
                            {
                                //Console.WriteLine("Código: " + prod.codigo + " - Cantidad: " + prod.cantidad);
                                //comercios
                                clsComercio oComercio = new clsComercio(prod.comercio_codigo, prod.comercio_nombre, prod.comercio_nit, prod.comercio_direccion);
                                oComercio.Insertar_Comercio();

                                //Usuarios
                                clsUsuario oUsuario = new clsUsuario(prod.usuario_identificacion, prod.usuario_nombre, prod.usuario_email);
                                oUsuario.Insertar_usuario();

                                //transacciones
                                clsTransaccion oTransaccion = new clsTransaccion(Convert.ToInt64(prod.Trans_codigo), Convert.ToInt32(prod.Trans_medio_pago), Convert.ToInt32(prod.Trans_estado),
                                prod.Trans_total, Convert.ToDateTime(prod.Trans_fecha), prod.Trans_concepto, prod.comercio_codigo, prod.usuario_identificacion);
                                oTransaccion.Insertar_Transaccion();
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
                PostItem();
            }
        }

    }
}

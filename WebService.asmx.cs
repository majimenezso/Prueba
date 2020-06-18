using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Web.UI;
using System.Configuration;
using System.Data.SqlClient;


namespace Desarrollo
{
    /// <summary>
    /// Descripción breve de WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {



        #region variable de conexion

        private SqlDataAdapter _adaptador;//prepara el comando y la conexión a establecer.
        private SqlCommandBuilder _constructorDelComando;//contruye el comando.
        private DataTable _tabla;//almacena los datos volcados por el comando.
        private string _cadenaDeConexion = ConfigurationManager.AppSettings.Get("CDC");/*trayendo el valor de la llave CDC creada en el
                                                                                 * archivo Web.config(string de conexión)*/
        #endregion  variable de conexion 

        [WebMethod]
        public string Conexion()
        {
            return _cadenaDeConexion;//retornando string de conexion
        }

        /// <summary>
        /// función web que una consulta al motor
        /// </summary>
        /// <param name="instruccion">instrucción en sql</param>
        /// <returns>retorna un DataTable</returns>
        [WebMethod]

        public DataTable Consulta(string instruccion)
        {
            instruccion = "Set Language Spanish " + instruccion;
            _adaptador = new SqlDataAdapter(instruccion, _cadenaDeConexion);//instanciando el adaptador.
            _constructorDelComando = new SqlCommandBuilder(_adaptador);//construyendo el comando.
            _tabla = new DataTable();//instanciando una tabla vacía.
           _adaptador.Fill(_tabla);//ejecutando y llenando la tabla.
            return _tabla;//retornando la tabla.
        }





    }
}

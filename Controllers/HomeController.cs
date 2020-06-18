using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Desarrollo.Controllers
{
    public class HomeController : Controller
    {
        private DataTable _tabla;
        public string usu;
        public string con;

        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string x, string y)
        {

            // se crea un objeto del servicio web
            WebService SV = new WebService(); //instanciando el Servicio.

            // se verifica que los textbox no esten vacios
            if (x != "" && y != "")
            {
                usu = "WHERE usuario ='" + x + "';";
            }

            // se realiza la consulta al servicio web

            _tabla = SV.Consulta("select usuario,contrasena from Usuarios");


            for (int i = 0; i < 5; i++)
            {
                // se obtinene los regitros de la tabla Usuarios
                string contraseña = _tabla.Rows[i][1].ToString(); // hace la busqueda en fila y columna con el rows
                string usuar = _tabla.Rows[i][0].ToString();

                con = y;
                // se verifican que las entradas coincidas con las almacenas
                if (usuar == x && contraseña == y)
                {

                    ViewBag.Message = "bienvenido" + "\n" + usuar;
                }
            }

            return View();
        }


     

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
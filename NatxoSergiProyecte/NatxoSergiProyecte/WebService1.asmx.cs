using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SQLite;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace NatxoSergiProyecte
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        public string DBpath = HttpRuntime.AppDomainAppPath + "basedatos.db";

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public DataTable Login(int user)
        {
            DataTable dt = new DataTable();

            SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");

            conn.Open();
            using (conn)
            {
                SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Client WHERE idn='" + user + "'", conn);
                SQLiteDataReader reader = comm.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            return dt;
        }
    }
}

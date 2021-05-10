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

        [WebMethod]
        public DataTable initiateSesion(string user, string pass)
        {

            DataTable dt = new DataTable();
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(pass));
                pass = BitConverter.ToString(data).Replace("-", string.Empty);
            }
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");

            conn.Open();
            using (conn)
            {
                SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Client WHERE name ='" + user + "'", conn);
                SQLiteDataReader reader = comm.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            return dt;
        }
        [WebMethod]
        public DataTable initiateSesionRecepcionist(string user, string pass)
        {

            DataTable dt = new DataTable();
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(pass));
                pass = BitConverter.ToString(data).Replace("-", string.Empty);
            }
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");

            conn.Open();
            using (conn)
            {
                SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Recepcionist WHERE name ='" + user + "'", conn);
                SQLiteDataReader reader = comm.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            return dt;
        }
        [WebMethod]
        public DataTable dataClient(int id)
        {

            DataTable dt = new DataTable();
         
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");

            conn.Open();
            using (conn)
            {
                SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Client WHERE id ='" + id + "'", conn);
                SQLiteDataReader reader = comm.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            return dt;
        }
        [WebMethod]
        public DataTable dataRecepcionist(int id)
        {

            DataTable dt = new DataTable();

            SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");

            conn.Open();
            using (conn)
            {
                SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Recepcionist WHERE id ='" + id + "'", conn);
                SQLiteDataReader reader = comm.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            return dt;
        }
      

        [WebMethod]
        public DataTable dataReserve(int id,int role)
        {

            DataTable dt = new DataTable();

            SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");

            conn.Open();
            using (conn)
            {
                SQLiteCommand comm;
                if (role == 0) {
                   comm= new SQLiteCommand("SELECT * FROM reserve WHERE idClient ='" + id + "'", conn);
                }
                else
                {
                    comm = new SQLiteCommand("SELECT * FROM reserve WHERE idRecepcionist ='" + id + "'", conn);
                }
                SQLiteDataReader reader = comm.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            return dt;
        }

        [WebMethod]
        public void deleteReserve(int id)
        {
           

            SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");

            conn.Open();
            using (conn)
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter();

                SQLiteCommand comm = new SQLiteCommand("DELETE  FROM Reserve WHERE id ='" + id + "'", conn);
                
                adapter.DeleteCommand = comm;
                adapter.DeleteCommand.ExecuteNonQuery();
                
            }
        }

        [WebMethod]
        public void addReserve(int idRecepcionist,int idnClient , string arrivalDate , string finishDate , string typeRoom)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");

            conn.Open();
            using (conn)
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter();

                SQLiteCommand comm = new SQLiteCommand("INSERT INTO reserve(idRecepcionist,idnClient,arrivaldate,finishdate,typeRoom)VALUES('" + idRecepcionist + "','" + idnClient + "','" + arrivalDate + "','" + finishDate + "','" + typeRoom + "')", conn);

                try
                {
                    adapter.InsertCommand = comm;
                    adapter.InsertCommand.ExecuteNonQuery();
                }
                catch
                {
                    Console.WriteLine("Insertion of reserve failed");
                }



            }
        }

        [WebMethod]
        public void addClient(int idnClient, string nameClient, string passClient ,string surname, int creditCard , int idRecepcionist)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");

            conn.Open();
            using (conn)
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter();

                SQLiteCommand comm = new SQLiteCommand("INSERT INTO Client(idn,name,password,surname,creditCard,idRecepcionist)VALUES('" + idnClient +"','"+ nameClient+ "','" + passClient+ "','"+ surname+"','" + creditCard + "','" + idRecepcionist + "')", conn);
                
                try
                {
                    adapter.InsertCommand = comm;
                    adapter.InsertCommand.ExecuteNonQuery();
                }
                catch
                {
                    Console.WriteLine("Insertion of client failed");
                }
                
                

            }
        }

        [WebMethod]
        public DataTable searchClientWithName(string name)
        {
            int id = 0;


            DataTable dt = new DataTable();

            SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");

            conn.Open();
            using (conn)
            {
                SQLiteCommand comm;
                
                    comm = new SQLiteCommand("SELECT * FROM Client WHERE name ='" + name + "'", conn);
                
                
                   
                
                SQLiteDataReader reader = comm.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            
            return dt;
        }

        [WebMethod]
        public DataTable getClientByRecepcionist(int idRecepcionist)
        {
            DataTable dt = new DataTable();

            SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");

            conn.Open();
            using (conn)
            {
                SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Client WHERE idRecepcionist ='" + idRecepcionist + "'", conn);
                SQLiteDataReader reader = comm.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            return dt;
        }

        [WebMethod]
        public void modifyReserve(int reserve,int idnClient , string arrivalDate, string finishdate , string typeRoom)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");

            conn.Open();
            using (conn)
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter();

                SQLiteCommand comm = new SQLiteCommand("UPDATE reserve SET idnClient = '"+idnClient+"',arrivaldate = '"+arrivalDate+ "',finishdate = '" + finishdate + "',typeRoom = '" + typeRoom + "'  WHERE id = " + reserve+"; ", conn);

                try
                {
                    adapter.UpdateCommand = comm;
                    adapter.UpdateCommand.ExecuteNonQuery();
                }
                catch
                {
                    Console.WriteLine("Update of client failed");
                }



            }
        }
    }
}

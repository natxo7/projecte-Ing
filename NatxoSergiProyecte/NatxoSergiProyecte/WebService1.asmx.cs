﻿using System;
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
            //DataTable dt = new DataTable();

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


    }
}

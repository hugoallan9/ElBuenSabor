using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Practica1
{
    public class BaseDatos
    {
        public const string operacion_exitosa = "EXITOSA";
        private SqlDataAdapter sda = null;
        public string id;

        private String server = "ASUSTOUCH\\SQLEXPRESS";  
        private String datos = "buenSabor";    //Nombre de la Base de Datos
        string conect; //string de conexion
        private SqlConnection thisConnection = null;//objeto conexion, unicamente para transacciones

         public BaseDatos()
        {
            conect = " Data Source=" + server + ";Initial Catalog=" + datos + ";  Integrated Security = True";
        }

         public SqlTransaction iniciarTransaccion()
         {
             this.thisConnection = new SqlConnection(conect);
             this.thisConnection.Open();
             return thisConnection.BeginTransaction();
        }

         public void rollbackTransaccion(SqlTransaction sqlTran)
         {
             sqlTran.Rollback();
         }

         public void commitTransaccion(SqlTransaction sqlTran)
         {
            sqlTran.Commit();
             //desconectar();

         }

         public void desconectar()
         {
             if (thisConnection != null)
             {
                 thisConnection.Close();
                 thisConnection = null;
             }

         }

         public int numeroDatos(string consulta)
         {
             int t = 0;

             string sql = consulta;

             this.thisConnection = new SqlConnection(conect);
             SqlCommand thisCommandd = new SqlCommand(sql, thisConnection);
             thisConnection.Open();

             SqlDataReader aux = thisCommandd.ExecuteReader();

             while (aux.Read())
             { t++; }

             // Cerramos la conexión

             thisConnection.Close();
             return t;
         }
         
         
         public Boolean verificarconexion()
        {

            try
            {

                SqlConnection thisConnection = new SqlConnection(conect);
                thisConnection.Open();

                thisConnection.Close();
                return true;
            }
            catch (Exception e)
            {
                //throw new Exception(e.Message);

            }
            return false;
        }

        public bool actualizar(String consulta)
        {
            bool existe = true;
            try
            {
                //COMANDO PARA PODER Actualizar DATOS A LA BD
                string coomand = consulta;
                if (thisConnection == null)
                {
                    thisConnection = new SqlConnection(conect);
                    thisConnection.Open();
                }
                SqlCommand thisCommandd = new SqlCommand(coomand, thisConnection);

                thisCommandd.ExecuteNonQuery();
                desconectar();

            }
            catch (Exception e)
            {

                existe = false;

            }
            return existe;
        }

        public SqlDataReader Consulta(string consulta)
        {

            string sql = consulta;
            if (this.thisConnection == null)
                this.thisConnection = new SqlConnection(conect);
            SqlCommand thisCommandd = new SqlCommand(sql, thisConnection);
            thisConnection.Open();

            SqlDataReader lector = thisCommandd.ExecuteReader(); ;
            return lector;
        }

         public String insertarDatos(string consulta, SqlTransaction trans)
        {


            //COMANDO PARA PODER INSERTAR DATOS A LA BD

            if (this.thisConnection == null)
            {
                this.thisConnection = new SqlConnection(conect);
                thisConnection.Open();
            }
            // Enlist a command in the current transaction.
            SqlCommand command = this.thisConnection.CreateCommand();
            command.Transaction = trans;
            command.CommandText = consulta;

            command.ExecuteNonQuery();



            return "Ingreso exitoso";
        }

        public String borrarDatos(string comando)
        {

            String existe = null;
            try
            {
                //COMANDO PARA PODER borrar DATOS A LA BD
                string coomand = comando;
                if (this.thisConnection == null)
                {
                    this.thisConnection = new SqlConnection(conect);
                    thisConnection.Open();
                }
                SqlCommand thisCommandd = new SqlCommand(coomand, thisConnection);

                thisCommandd.ExecuteNonQuery();
                desconectar();
                existe = "Operacion realiza efectivamente";

            }
            catch (Exception e)
            {
                existe = e.Message;
                throw new Exception(e.Message);


            }
            return existe;
        }

        /** 
            metodo usado para insertar datos a la bd.
            * parametros comando:supone que es un comnado insert,insert normal
            * retorna: EXITOSA si fue realizada exitosamente o el mensaje de error
         
            */
        public String insertarDatos(string comando)
        {

            String existe = null;
            try
            {
                //COMANDO PARA PODER INSERTAR DATOS A LA BD
                string coomand = comando;
                if (thisConnection == null)
                    thisConnection = new SqlConnection(conect);
                SqlCommand thisCommandd = new SqlCommand(coomand, thisConnection);
                thisConnection.Open();
                thisCommandd.ExecuteNonQuery();

                existe = "OK";

            }
            catch (Exception e)
            {
                existe = "No tuve exito, algo pusiste mal";



            }
            return existe;
        }

    }
}
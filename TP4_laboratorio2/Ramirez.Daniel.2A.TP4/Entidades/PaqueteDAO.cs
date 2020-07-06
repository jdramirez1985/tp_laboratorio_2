using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Campos
        static SqlConnection _conexion;
        static SqlCommand _comando;
        #endregion

        #region Metodos
        static PaqueteDAO()
        {
            PaqueteDAO._conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
            PaqueteDAO._comando = new SqlCommand();
        }
        /// <summary>
        /// Inserta un Paquete en la base de datos ""correo-sp-2017"
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        public static bool Insetar(Paquete p)
        {
            
            PaqueteDAO._comando.CommandType = System.Data.CommandType.Text;
            PaqueteDAO._comando.Connection = PaqueteDAO._conexion;
            
            bool Ok = false;
            string sql = "INSERT INTO Paquetes (direccionEntrega, trackingID, alumno) VALUES('" + p.DireccionEntrega + "','" + p.TrackingID + "','Ramirez, Jeremías Daniel')";
            try
            {
                PaqueteDAO._comando.CommandText = sql;
                PaqueteDAO._conexion.Open();
                PaqueteDAO._comando.ExecuteNonQuery();
                Ok = true;
            }
            catch (Exception)
            {
                
            }
            finally
            {
                if (Ok)
                    PaqueteDAO._conexion.Close();
            }
            return Ok;
        }
        #endregion
    }
}

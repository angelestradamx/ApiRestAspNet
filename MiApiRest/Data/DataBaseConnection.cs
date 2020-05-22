using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

namespace MiApiRest.Data
{
    public class DataBaseConnection
    {

        public static int ExecuteQuery(string spName, SqlParameter[] parameters)
        {
            int ds = 0;
            SqlConnection conn = Conexion();

            try
            {
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(parameters);

                    cmd.Parameters.Add("@answer", SqlDbType.Int);
                    cmd.Parameters["@answer"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    ds = int.Parse(cmd.Parameters["@answer"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                ds = 0;
            }
            finally
            {
                conn.Close();
            }


            return ds;
        }

        public static DataSet ExecuteQueryDataSet(string spName, SqlParameter[] parameters)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = Conexion();
            try
            {
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(parameters);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);                   
                    da.Fill(ds);                 
                }
            }
            catch (Exception ex)
            {
                ds = null;
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }

        private static SqlConnection Conexion()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["SQLConnString"].ConnectionString;
            return conn;
        }

    }
}
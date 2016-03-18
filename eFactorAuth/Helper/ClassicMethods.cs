using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace eFactorAuth.Helper
{
    public class ClassicMethods
    {
        private SqlConnection conn;
        public ClassicMethods()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AuthContext"].ConnectionString);
        }
        public string ObtenAleatorioRegistrado(string usuario)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand comm = new SqlCommand("eFactor.damePswAleatorio", conn);
                SqlParameter outputIdParam = new SqlParameter("@Out", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 100 };
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(outputIdParam);
                comm.Parameters.Add(new SqlParameter("@nombre", usuario));
                comm.ExecuteNonQuery();
                conn.Close();
                return outputIdParam.Value.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace AySonuHesap
{
    class Functions
    {
        private string ConStr = @"Server=.;Database=Takip;Integrated Security=True;";

        public DataTable GetData(string query)
        {
            using (SqlConnection con = new SqlConnection(ConStr))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public int SetData(string query)
        {
            using (SqlConnection con = new SqlConnection(ConStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetDataWithParameters(string query, SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(ConStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddRange(parameters);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public int SetDataWithParameters(string query, SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(ConStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddRange(parameters);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public object GetScalarData(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection con = new SqlConnection(ConStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                con.Open();
                return cmd.ExecuteScalar();
            }
        }
    }
}
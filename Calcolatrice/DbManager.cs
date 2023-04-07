using System.Data;
using System.Data.SqlClient;

namespace CalculatorCode
{
    public class DbManager
    {
        string connstr = string.Empty;
        public DbManager(string connstr)
        {   
            this.connstr = connstr;
        }

        public (string, Object) Insert(string query)
        {
            string error = string.Empty;
            SqlConnection conn = new SqlConnection(this.connstr);
            Object LastKey = new Object();
            
            try
            {
                SqlCommand sqlCommand = new SqlCommand($"{query}; SELECT scope_identity()", conn);
                conn.Open();
                LastKey = sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return (error, LastKey);
        }

        public (string, DataSet) Select(string query, Dictionary<string, Object>? parameter = null)
        {
            string error = string.Empty;
            SqlConnection conn = new SqlConnection(this.connstr);
            DataSet ds = new DataSet();

            try
            {
                SqlCommand sqlCommand = new SqlCommand($"{query};", conn);

                if (parameter != null)
                {
                    foreach (KeyValuePair<string, Object> param in parameter)
                    {
                        sqlCommand.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                {
                    adapter.Fill(ds);
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return (error, ds);
        }
    }
}
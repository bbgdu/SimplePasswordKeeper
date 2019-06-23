using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager
{
    class mpfunc
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        public bool verify(mdetails p)
        {
            bool okay = false;   
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string query = "select masterpassword from mp where masterpassword = @masterpassword";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@masterpassword", p.masterpassword);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();


                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    okay = true;
                }
                else
                {
                    okay = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return okay;
        }
        public bool insertintomp(mdetails p)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                String sql = "INSERT INTO mp values(@masterpassword)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@masterpassword", p.masterpassword);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        public string Getmp()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);  
                String sql = "SELECT * FROM mp";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
             string ll = (string)cmd.ExecuteScalar();
            conn.Close();
            return ll;
        }
        #region DeleteAll Data from DAtabase
        public bool DeleteAll()
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "DELETE FROM mp";

                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    //Query Successfull
                    isSuccess = true;
                }
                else
                {
                    //Query Failed
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        #endregion

    }
}

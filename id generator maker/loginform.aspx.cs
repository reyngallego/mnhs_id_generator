using System;
using System.Configuration;
using System.Data.SqlClient;

namespace id_generator_maker
{
    public partial class loginform : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            string connectionString = ConfigurationManager.ConnectionStrings["StudentRecordsConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM ADMIN WHERE username = @username AND password = @password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    // Redirect to the home page or dashboard upon successful login
                    Response.Redirect("dashboard.aspx");
                }
                else
                {
                    // Display error message for invalid credentials
                    Response.Write("<script>alert('Invalid username or password');</script>");
                }
            }
        }
    }
}

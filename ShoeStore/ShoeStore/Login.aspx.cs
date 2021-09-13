using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ShoeStore
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            LoginCustomer();
        }
        public void LoginCustomer()
        {
            
            string constr = ConfigurationManager.ConnectionStrings["CONSTDB"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("stp_LoginUser");
            DataTable dt = new DataTable();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Username", TxtUsername.Text);
            cmd.Parameters.AddWithValue("@Password", TxtPassword.Text);
            cmd.Connection = con;
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if(dt!=null && dt.Rows.Count > 0)
            {
                Session["Username"] = dt.Rows[0]["username"].ToString();
                Response.Redirect("Default.aspx");
            }
            else
            {
                lbl_error.Visible = true;
                lbl_error.Text = "Your Username and Password Does not Match!";
            }
            
            con.Close();
           
        }
    }
}
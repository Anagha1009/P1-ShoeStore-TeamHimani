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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (InsertData())
            {
                Response.Redirect("Login.aspx");
            }
        }


        #region "Insert Customer Data"
        public bool InsertData()
        {
            bool FunctionReturnValue = false;

            try
            {
                SqlConnection SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONSTDB"].ToString());
                SqlCommand SqlComm = new SqlCommand();

                SqlComm.Connection = SqlConn;
                SqlComm.CommandType = CommandType.StoredProcedure;
                SqlComm.CommandText = "stp_InsertData";

                SqlComm.Parameters.AddWithValue("Name", TxtName.Text);
                SqlComm.Parameters.AddWithValue("Email", TxtEmail.Text);
                SqlComm.Parameters.AddWithValue("Contact", TxtContact.Text);
                SqlComm.Parameters.AddWithValue("UserName", TxtUserName.Text);
                SqlComm.Parameters.AddWithValue("Password", TxtPassword.Text);

                if (SqlConn.State == ConnectionState.Closed)
                {
                    SqlConn.Open();
                }

                SqlComm.ExecuteNonQuery();

                if (SqlConn.State == ConnectionState.Open)
                {
                    SqlConn.Close();
                }

                SqlComm.Dispose();
                SqlConn.Dispose();

                FunctionReturnValue = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return FunctionReturnValue;
        }
        #endregion


    }
}
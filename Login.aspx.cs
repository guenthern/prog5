using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Prog3.App_Code_folder;
using System.Data.SqlClient;
using System.Configuration;

namespace Prog3
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UWPCS3870ConnectionString1"].ConnectionString);
            //    conn.Open();
            //    string insertQuery = "Select Email from Users where UserName = '" + txtUserName + "' and Password = '" + txtPass + "'";

            //    SqlCommand com = new SqlCommand(insertQuery, conn);
            //    string item = com.ExecuteReader().ToString();
            //    //com.ExecuteNonQuery();
            Session["Prog5_User"] = txtUserName.Text;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UWPCS3870ConnectionString1"].ConnectionString);
            conn.Open();
            string insertQuery = "Delete from ShopingBag where Customer = @keyID";

            SqlCommand com = new SqlCommand(insertQuery, conn);
            com.Parameters.AddWithValue("@keyID", Session["Prog5_User"]);
            com.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("Default.aspx");

        //    conn.Close();
        }
    }
}
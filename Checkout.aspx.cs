using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Prog3
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UWPCS3870ConnectionString1"].ConnectionString);
            conn.Open();
            string insertQuery = "select * from ShopingBag";

            SqlCommand com = new SqlCommand(insertQuery, conn);
            GridView1.DataSource = com.ExecuteReader();
            GridView1.DataBind();
            conn.Close();
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UWPCS3870ConnectionString1"].ConnectionString);
            conn.Open();
            string insertQuery = "Delete from ShopingBag where Customer = @keyID";

            SqlCommand com = new SqlCommand(insertQuery, conn);
            com.Parameters.AddWithValue("@keyID", Session["Prog5_User"]);
            com.ExecuteNonQuery();
            conn.Close();
            Session["Prog3_Index"] = 0;
            Session["Prog3_ID"] = "";
            Session["Prog2_ProductID"] = "";
            Session["Prog2_ProductPrice"] = "";
            Session["Prog2_ProductQuantity"] = "";
            Session["Prog2_Computed"] = false;
            Session["Prog5_User"] = "";
            Response.Redirect("Login.aspx");
        }
    }
}
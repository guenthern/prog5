﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Prog3.App_Code_folder;
using System.Data.SqlClient;
using System.Configuration;

namespace Prog3
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            
            SQLDataClass.setupProdAdapter();
            
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["Prog3_Index"] = 0;
            Session["Prog3_ID"] = "";
            Session["Prog2_ProductID"] = "";
            Session["Prog2_ProductPrice"] = "";
            Session["Prog2_ProductQuantity"] = "";
            Session["Prog2_Computed"] = false;
            Session["Prog5_User"] = "";          
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UWPCS3870ConnectionString1"].ConnectionString);
            conn.Open();
            string insertQuery = "Delete from ShopingBag where Customer = @keyID";

            SqlCommand com = new SqlCommand(insertQuery, conn);
            com.Parameters.AddWithValue("@keyID", Session["Prog5_User"]);
            com.ExecuteNonQuery();
            conn.Close();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            
        }

        public static void getAllProducts()
        {
            if (SQLDataClass.prodAdapter == null)
                SQLDataClass.setupProdAdapter();
        }
    }
}
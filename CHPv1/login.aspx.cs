﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace CHPv1
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\chp;Initial Catalog=chpyp;Integrated Security=True");
            con.Open();

            string username = tbxUsername.Text;
            string password = tbxPassword.Text;

            SqlCommand cmd = new SqlCommand("select * from [chpyp].[dbo].[user] where username='" + username + "' and password ='" + password + "'", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                Session["kadi"] = username;
                Response.Redirect("main.aspx");
            }
                
            con.Close();
        }
    }
}

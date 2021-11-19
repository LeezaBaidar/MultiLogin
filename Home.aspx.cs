using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace MultiLogin
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-LRNPN6M;Initial Catalog=multilogin;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("select * from multilogin where username='" + txtUser.Text + "' and password = '" + txtPassWord.Text + "' and usertype='" + DropDownList1.SelectedItem.ToString() + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count>0)
            {
                Response.Write("<script>alert('You are logged in as " + dt.Rows[0][3] + "')</script>");
                if (DropDownList1.SelectedIndex == 0)
                {
                    Server.Transfer("Admin.aspx");
                } else if (DropDownList1.SelectedIndex == 1)
                {
                    Server.Transfer("User.aspx");
                }else if (DropDownList1.SelectedIndex == 2)
                {
                    Server.Transfer("Teacher.aspx");
                }
            else
            {
                Response.Write("Error in your input");
            }
        }
    }
}
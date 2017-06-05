using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class MasterPage : System.Web.UI.MasterPage
{

    protected override void AddedControl(Control control, int index)
    {
        // This is necessary because Safari and Chrome browsers don't display the Menu control correctly.
        // Add this to the code in your master page.
        if (Request.ServerVariables["http_user_agent"].IndexOf("Safari", StringComparison.CurrentCultureIgnoreCase) != -1)
            this.Page.ClientTarget = "uplevel";

        base.AddedControl(control, index);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
            string pageName = this.ContentPlaceHolder1.Page.GetType().FullName;
            string queryString = "";
            string TieneSubmenu01 = "N";
            string TieneSubmenu02 = "N";
            string TieneSubmenu03 = "N";
            string TieneSubmenu04 = "N";
            string TieneSubmenu05 = "N";
            string TieneSubmenu06 = "N";
            string TieneSubmenu07 = "N";
            string TieneSubmenu08 = "N";
            string TieneSubmenu09 = "N";
            string TieneSubmenu10 = "N";
            string TieneSubmenu11 = "N";
            string TieneSubmenu12 = "N";
            string TieneSubmenu13 = "N";
            string TieneSubmenu14 = "N";
            string TieneSubmenu15 = "N";
            string TieneSubmenu16 = "N";
            string TieneSubmenu17 = "N";
            string TieneSubmenu18 = "N";
            string TieneSubmenu19 = "N";
            string TieneSubmenu20 = "N";

            if (pageName == "ASP.login_aspx")
            { 
                FormsAuthentication.SignOut();
                queryString = "SELECT IdHead FROM Menu_Items WHERE 1=2 ";
            }
            else   
            {
                /* nuevo para saber si tiene submenues */
                queryString = "SELECT I.IdHead PadreId,count(*) " +
                                 "FROM Menu_Items I " +
                                 "inner join Menu_Tipos T on T.IdItemMenu=I.IdItemMenu " +
                                 "inner join Usuarios U on U.IdMenu = T.IdMenu " +
                                 "WHERE U.Usuario='" + HttpContext.Current.User.Identity.Name + "' " +
                                 "GROUP BY I.IdHead";
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConSql"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader[0].ToString() == "1"  && reader[1].ToString() != "1") { TieneSubmenu01 = "S"; }
                        if (reader[0].ToString() == "2"  && reader[1].ToString() != "1") { TieneSubmenu02 = "S"; }
                        if (reader[0].ToString() == "3"  && reader[1].ToString() != "1") { TieneSubmenu03 = "S"; }
                        if (reader[0].ToString() == "4"  && reader[1].ToString() != "1") { TieneSubmenu04 = "S"; }
                        if (reader[0].ToString() == "5"  && reader[1].ToString() != "1") { TieneSubmenu05 = "S"; }
                        if (reader[0].ToString() == "6"  && reader[1].ToString() != "1") { TieneSubmenu06 = "S"; }
                        if (reader[0].ToString() == "7"  && reader[1].ToString() != "1") { TieneSubmenu07 = "S"; }
                        if (reader[0].ToString() == "8"  && reader[1].ToString() != "1") { TieneSubmenu08 = "S"; }
                        if (reader[0].ToString() == "9"  && reader[1].ToString() != "1") { TieneSubmenu09 = "S"; }
                        if (reader[0].ToString() == "10" && reader[1].ToString() != "1") { TieneSubmenu10 = "S"; }
                        if (reader[0].ToString() == "11" && reader[1].ToString() != "1") { TieneSubmenu11 = "S"; }
                        if (reader[0].ToString() == "12" && reader[1].ToString() != "1") { TieneSubmenu12 = "S"; }
                        if (reader[0].ToString() == "13" && reader[1].ToString() != "1") { TieneSubmenu13 = "S"; }
                        if (reader[0].ToString() == "14" && reader[1].ToString() != "1") { TieneSubmenu14 = "S"; }
                        if (reader[0].ToString() == "15" && reader[1].ToString() != "1") { TieneSubmenu15 = "S"; }
                        if (reader[0].ToString() == "16" && reader[1].ToString() != "1") { TieneSubmenu16 = "S"; }
                        if (reader[0].ToString() == "17" && reader[1].ToString() != "1") { TieneSubmenu17 = "S"; }
                        if (reader[0].ToString() == "18" && reader[1].ToString() != "1") { TieneSubmenu18 = "S"; }
                        if (reader[0].ToString() == "19" && reader[1].ToString() != "1") { TieneSubmenu19 = "S"; }
                        if (reader[0].ToString() == "20" && reader[1].ToString() != "1") { TieneSubmenu20 = "S"; }
                    }
                    connection.Close();
                }
                /* FIN - nuevo para saber si tiene submenues */

                
                queryString = "SELECT I.IdItemMenu, I.Descripcion, I.Posicion, I.IdHead, I.Icono, I.Url " +
                                 "FROM Menu_Items I " +
                                 "inner join Menu_Tipos T on T.IdItemMenu=I.IdItemMenu " +
                                 "inner join Usuarios U on U.IdMenu = T.IdMenu " +
                                 "WHERE U.Usuario='" + HttpContext.Current.User.Identity.Name + "' " +
                                 "ORDER BY I.IdHead,I.Posicion";
            }
            
 

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConSql"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                MenuItem mnuMenuItem = new MenuItem();  
                int NumeroItem = 0;
                HtmlGenericControl li2 = new HtmlGenericControl("li");
                HtmlGenericControl submen = new HtmlGenericControl("ul");
                string menuConSubmenu = "@";

                while (reader.Read())
                {
                    if (reader[2].ToString() == reader[3].ToString())
                    {
                        NumeroItem += 1;
                        menuConSubmenu = "@";

                        HtmlGenericControl anchor = new HtmlGenericControl("a");
                        string ClaseMenu = "dropdown";
                        if (reader[5].ToString() != "")
                            { anchor.Attributes.Add("href", reader[5].ToString()); }
                        else
                            { anchor.Attributes.Add("href", "#"); }
                        if (reader[3].ToString() == "1" && TieneSubmenu01 == "S") { anchor.Attributes.Add("class", "dropdown-toggle"); ClaseMenu = "dropdown"; }
                        if (reader[3].ToString() == "2" && TieneSubmenu02 == "S") { anchor.Attributes.Add("class", "dropdown-toggle"); ClaseMenu = "dropdown"; }
                        if (reader[3].ToString() == "3" && TieneSubmenu03 == "S") { anchor.Attributes.Add("class", "dropdown-toggle"); ClaseMenu = "dropdown"; }
                        if (reader[3].ToString() == "4" && TieneSubmenu04 == "S") { anchor.Attributes.Add("class", "dropdown-toggle"); ClaseMenu = "dropdown"; }
                        if (reader[3].ToString() == "5" && TieneSubmenu05 == "S") { anchor.Attributes.Add("class", "dropdown-toggle"); ClaseMenu = "dropdown"; }
                        if (reader[3].ToString() == "6" && TieneSubmenu06 == "S") { anchor.Attributes.Add("class", "dropdown-toggle"); ClaseMenu = "dropdown"; }
                        if (reader[3].ToString() == "7" && TieneSubmenu07 == "S") { anchor.Attributes.Add("class", "dropdown-toggle"); ClaseMenu = "dropdown"; }
                        if (reader[3].ToString() == "8" && TieneSubmenu08 == "S") { anchor.Attributes.Add("class", "dropdown-toggle"); ClaseMenu = "dropdown"; }
                        if (reader[3].ToString() == "9" && TieneSubmenu09 == "S") { anchor.Attributes.Add("class", "dropdown-toggle"); ClaseMenu = "dropdown"; }
                        if (reader[3].ToString() == "10" && TieneSubmenu10 == "S") { anchor.Attributes.Add("class", "dropdown-toggle"); ClaseMenu = "dropdown"; }
                        if (reader[3].ToString() == "11" && TieneSubmenu11 == "S") { anchor.Attributes.Add("class", "dropdown-toggle"); ClaseMenu = "dropdown"; }
                        if (reader[3].ToString() == "12" && TieneSubmenu12 == "S") { anchor.Attributes.Add("class", "dropdown-toggle"); ClaseMenu = "dropdown"; }
                        if (reader[3].ToString() == "13" && TieneSubmenu13 == "S") { anchor.Attributes.Add("class", "dropdown-toggle"); ClaseMenu = "dropdown"; }
                        if (reader[3].ToString() == "14" && TieneSubmenu14 == "S") { anchor.Attributes.Add("class", "dropdown-toggle"); ClaseMenu = "dropdown"; }
                        if (reader[3].ToString() == "15" && TieneSubmenu15 == "S") { anchor.Attributes.Add("class", "dropdown-toggle"); ClaseMenu = "dropdown"; }
                        if (reader[3].ToString() == "16" && TieneSubmenu16 == "S") { anchor.Attributes.Add("class", "dropdown-toggle"); ClaseMenu = "dropdown"; }
                        if (reader[3].ToString() == "17" && TieneSubmenu17 == "S") { anchor.Attributes.Add("class", "dropdown-toggle"); ClaseMenu = "dropdown"; }
                        if (reader[3].ToString() == "18" && TieneSubmenu18 == "S") { anchor.Attributes.Add("class", "dropdown-toggle"); ClaseMenu = "dropdown"; }
                        if (reader[3].ToString() == "19" && TieneSubmenu19 == "S") { anchor.Attributes.Add("class", "dropdown-toggle"); ClaseMenu = "dropdown"; }
                        if (reader[3].ToString() == "20" && TieneSubmenu20 == "S") { anchor.Attributes.Add("class", "dropdown-toggle"); ClaseMenu = "dropdown"; }
                        anchor.InnerText = reader[1].ToString();
                        if (NumeroItem == 1) { Li1.Controls.Add(anchor); Li1.Attributes.Add("class", ClaseMenu); }
                        if (NumeroItem == 2) { Li2.Controls.Add(anchor); Li2.Attributes.Add("class", ClaseMenu); }
                        if (NumeroItem == 3) { Li3.Controls.Add(anchor); Li3.Attributes.Add("class", ClaseMenu); }
                        if (NumeroItem == 4) { Li4.Controls.Add(anchor); Li4.Attributes.Add("class", ClaseMenu); }
                        if (NumeroItem == 5) { Li5.Controls.Add(anchor); Li5.Attributes.Add("class", ClaseMenu); }
                        if (NumeroItem == 6) { Li6.Controls.Add(anchor); Li6.Attributes.Add("class", ClaseMenu); }
                        if (NumeroItem == 7) { Li7.Controls.Add(anchor); Li7.Attributes.Add("class", ClaseMenu); }
                        if (NumeroItem == 8) { Li8.Controls.Add(anchor); Li8.Attributes.Add("class", ClaseMenu); }
                        if (NumeroItem == 9) { Li9.Controls.Add(anchor); Li9.Attributes.Add("class", ClaseMenu); }
                        if (NumeroItem == 10) { Li10.Controls.Add(anchor); Li10.Attributes.Add("class", ClaseMenu); }
                        if (NumeroItem == 11) { Li11.Controls.Add(anchor); Li11.Attributes.Add("class", ClaseMenu); }
                        if (NumeroItem == 12) { Li12.Controls.Add(anchor); Li12.Attributes.Add("class", ClaseMenu); }
                        if (NumeroItem == 13) { Li13.Controls.Add(anchor); Li13.Attributes.Add("class", ClaseMenu); }
                        if (NumeroItem == 14) { Li14.Controls.Add(anchor); Li14.Attributes.Add("class", ClaseMenu); }
                        if (NumeroItem == 15) { Li15.Controls.Add(anchor); Li15.Attributes.Add("class", ClaseMenu); }
                        if (NumeroItem == 16) { Li16.Controls.Add(anchor); Li16.Attributes.Add("class", ClaseMenu); }
                        if (NumeroItem == 17) { Li17.Controls.Add(anchor); Li17.Attributes.Add("class", ClaseMenu); }
                        if (NumeroItem == 18) { Li18.Controls.Add(anchor); Li18.Attributes.Add("class", ClaseMenu); }
                        if (NumeroItem == 19) { Li19.Controls.Add(anchor); Li19.Attributes.Add("class", ClaseMenu); }
                        if (NumeroItem == 20) { Li20.Controls.Add(anchor); Li20.Attributes.Add("class", ClaseMenu); }

                    }
                    else
                    {
                        if (menuConSubmenu == "@")
                        {
                            submen = new HtmlGenericControl("ul");
                            submen.Attributes.Add("class", "dropdown-menu");
                            if (NumeroItem == 1) { Li1.Controls.Add(submen); }
                            if (NumeroItem == 2) { Li2.Controls.Add(submen); }
                            if (NumeroItem == 3) { Li3.Controls.Add(submen); }
                            if (NumeroItem == 4) { Li4.Controls.Add(submen); }
                            if (NumeroItem == 5) { Li5.Controls.Add(submen); }
                            if (NumeroItem == 6) { Li6.Controls.Add(submen); }
                            if (NumeroItem == 7) { Li7.Controls.Add(submen); }
                            if (NumeroItem == 8) { Li8.Controls.Add(submen); }
                            if (NumeroItem == 9) { Li9.Controls.Add(submen); }
                            if (NumeroItem == 10) { Li10.Controls.Add(submen); }
                            if (NumeroItem == 11) { Li11.Controls.Add(submen); }
                            if (NumeroItem == 12) { Li12.Controls.Add(submen); }
                            if (NumeroItem == 13) { Li13.Controls.Add(submen); }
                            if (NumeroItem == 14) { Li14.Controls.Add(submen); }
                            if (NumeroItem == 15) { Li15.Controls.Add(submen); }
                            if (NumeroItem == 16) { Li16.Controls.Add(submen); }
                            if (NumeroItem == 17) { Li17.Controls.Add(submen); }
                            if (NumeroItem == 18) { Li18.Controls.Add(submen); }
                            if (NumeroItem == 19) { Li19.Controls.Add(submen); }
                            if (NumeroItem == 20) { Li20.Controls.Add(submen); }
                            menuConSubmenu = NumeroItem.ToString();
                        }

                        HtmlGenericControl linea2 = new HtmlGenericControl("li");
                        submen.Controls.Add(linea2);

                        HtmlGenericControl anchor = new HtmlGenericControl("a");
                        anchor.Attributes.Add("href", reader[5].ToString());
                        anchor.InnerText = reader[1].ToString();
                        linea2.Controls.Add(anchor);
                    }
                }  
                reader.Close();
                if (NumeroItem < 1) 
                {
                    HtmlGenericControl anchor = new HtmlGenericControl("a");
                    anchor.Attributes.Add("href", "login.aspx");
                    anchor.InnerText = "Ingresar";
                    Li1.Controls.Add(anchor); Li1.Attributes.Add("class", "dropdown");
                }
                if (NumeroItem < 2) { Li2.Visible = false;  }
                if (NumeroItem < 3) { Li3.Visible = false;  }
                if (NumeroItem < 4) { Li4.Visible = false;  }
                if (NumeroItem < 5) { Li5.Visible = false;  }
                if (NumeroItem < 6) { Li6.Visible = false;  }
                if (NumeroItem < 7) { Li7.Visible = false;  }
                if (NumeroItem < 8) { Li8.Visible = false;  }
                if (NumeroItem < 9) { Li9.Visible = false;  }
                if (NumeroItem < 10) { Li10.Visible=false; }
                if (NumeroItem < 11) { Li11.Visible = false; }
                if (NumeroItem < 12) { Li12.Visible = false; }
                if (NumeroItem < 13) { Li13.Visible = false; }
                if (NumeroItem < 14) { Li14.Visible = false; }
                if (NumeroItem < 15) { Li15.Visible = false; }
                if (NumeroItem < 16) { Li16.Visible = false; }
                if (NumeroItem < 17) { Li17.Visible = false; }
                if (NumeroItem < 18) { Li18.Visible = false; }
                if (NumeroItem < 19) { Li19.Visible = false; }
                if (NumeroItem < 20) { Li20.Visible = false; }

            }

        if (!Page.IsPostBack)
        { 
        //    Label2.Text += "Not postback"; 
        }
        else
        { 
        //    Label2.Text += "Postback"; 
        }
    }
}

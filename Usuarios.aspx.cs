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
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


public partial class formulario1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Tipo"] == "Modificacion")
            {
//                DropGrupo.Items.Insert(0, new ListItem(" ", "0"));
                LTitulo.Text = "Modificación de Usuarios";
                BnInsertar.Text = "Modificar";
                TUsuario.Text = HttpUtility.HtmlDecode(Request.QueryString["Us"]);
                string queryString = "SELECT usuario,clave,descripcion_tarea,nombre,apellido,telefono,mail,idgrupo,cliente ";
                queryString += " FROM usuarios_web ";
                queryString += " where usuario=" + TUsuario.Text + " and (idgrupo=2 OR idgrupo=3)";
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnPagina"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TUsuario.Text = Convert.ToString(reader[0]);
                        TClave.Text = Convert.ToString(reader[1]);
                        Tdt.Text = Convert.ToString(reader[2]);
                        TNombre.Text = Convert.ToString(reader[3]);
                        TApe.Text = Convert.ToString(reader[4]);
                        TTel.Text = Convert.ToString(reader[5]);
                        TMail.Text = Convert.ToString(reader[6]);
                        if (Convert.ToString(reader[7]) != "1")
                        {
                            DropGrupo.SelectedValue = Convert.ToString(reader[7]);
                        }
                        else
                        {
                            DropGrupo.Visible = false;
                        }
                        if (Convert.ToString(reader[7]) != "1")
                        {
                            DropEmp.SelectedValue = Convert.ToString(reader[8]);
                        }
                        else
                        {
                            DropEmp.Visible = false;
                        }
                        TUsuario.ReadOnly = true;
                    }
                }
            }
            else
            {
                LTitulo.Text = "Ingreso de Usuarios";
                BnInsertar.Text = "Insertar";
            }
        }
    }
    protected void BnInsertar_Click(object sender, EventArgs e)
    {
            Validar();
            if (Errores.Text == "")
            {
                if (Request.QueryString["Tipo"] != "Modificacion")
                {
                    if (Existe() == "NO")
                    {
                      GrabaUsuario();
                      Page.ClientScript.RegisterStartupScript(this.GetType(), "AKey", "MensajeOK();", true);
                    }
                    else
                    {
                      Errores.Text = "Usuario ya existente, Por favor modifique los datos";
                    }
                 }
                else
                 {
                    ActuUsuario();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "AKey", "MensajeOK2();", true);
                 }
            }
    }
    void Validar()
    {
        Errores.Text = "";
        if (TUsuario.Text.Length == 0)
        {
            LUsuario.ForeColor = System.Drawing.Color.Red;
            Errores.Text = "Atención: Los datos marcados en rojo son obligatorios ";
        }
        else
        {
            LUsuario.ForeColor = System.Drawing.Color.Black;
        }
        if (TClave.Text.Length == 0)
        {
            LClave.ForeColor = System.Drawing.Color.Red;
            Errores.Text = "Atención: Los datos marcados en rojo son obligatorios ";
        }
        else
        {
            LUsuario.ForeColor = System.Drawing.Color.Black;
        }
    }
    void GrabaUsuario()
    {
        string queryString2 = "INSERT INTO usuarios_web	";
        queryString2 += "([Usuario]";
        queryString2 += ",[Clave]";
        queryString2 += ",[Descripcion_Tarea]";
        queryString2 += ",[Idgrupo]";
        queryString2 += ",[Mail]";
        queryString2 += ",[Telefono]";
        queryString2 += ",[Nombre]";
        queryString2 += ",[Apellido]";
        queryString2 += ",[Cliente]";
        queryString2 += ",[Sector]";
        queryString2 += ",[Fecha_Alta])";
        queryString2 += "   VALUES				";
        queryString2 += "  ('" + TUsuario.Text + "'		";
        queryString2 += "  ,'" + TClave.Text + "'		";
        queryString2 += "  ,'" + Tdt.Text + "'		";
        queryString2 += "  ," + DropGrupo.SelectedValue + "		";
        queryString2 += "  ,'" + TMail.Text + "'		";
        queryString2 += "  ,'" + TTel.Text + "'		";
        queryString2 += "  ,'" + TNombre.Text + "'		";
        queryString2 += "  ,'" + TApe.Text + "'		";
        queryString2 += "  ,'" + DropEmp.SelectedValue + "'		";
        queryString2 += "  ,'" + DropSector.SelectedValue + "'		";
        queryString2 += "   ,'" + DateTime.Now.ToShortDateString() + "')		";
        using (SqlConnection connection2 = new SqlConnection(ConfigurationManager.ConnectionStrings["cnPagina"].ConnectionString))
        {
            SqlCommand command2 = new SqlCommand(queryString2, connection2);
            connection2.Open();
            command2.ExecuteNonQuery();
        }
    }
    void ActuUsuario()
    {
        string queryString = "UPDATE usuarios_web	";
        queryString += " set ";
        queryString += "[Clave]='" + TClave.Text + "'";
        queryString += ",[descripcion_tarea]='" + Tdt.Text + "'";
        queryString += ",[nombre]='" + TNombre.Text + "'";
        queryString += ",[Apellido]='" + TApe.Text + "'";
        queryString += ",[telefono]='" + TTel.Text + "'";
        queryString += ",[mail]='" + TMail.Text + "'";
        if (DropEmp.Visible == true)
        {
            queryString += ",[idgrupo]=" + DropGrupo.SelectedValue + "";
        }
        if (DropEmp.Visible == true)
        {
            queryString += ",[Cliente]='" + DropEmp.SelectedValue + "'";
        }
        queryString += ",[Sector]='" + DropSector.SelectedValue + "'";
        queryString += " WHERE [usuario]='" + TUsuario.Text + "'";
        if (DropEmp.Visible == true)
        {
            queryString += " and cliente='" + DropEmp.SelectedValue + "'";
        }
        //Errores.Text = queryString;
             using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnPagina"].ConnectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
    string Existe()
    {
        string Existe = "NO";
        string queryString = "SELECT [usuario]";
        queryString += " FROM Usuarios_web ";
        queryString += " WHERE usuario='" + TUsuario.Text + "'";
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnPagina"].ConnectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Existe = "SI";
            }
            reader.Close();
        }
        return Existe;
    }

}

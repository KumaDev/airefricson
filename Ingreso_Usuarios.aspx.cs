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
using System.Linq;
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
                LTitulo.Text = "Modificación de Usuarios";
                BnInsertar.Text = "Modificar";
                TID.Text = Request.QueryString["IDUsu"];
                string queryString = "SELECT Descripcion_Clave01,TipoDato_Clave01,Longitud_Clave01,Descripcion_Clave02,TipoDato_Clave02,Longitud_Clave02,Descripcion_Clave03,TipoDato_Clave03,Longitud_Clave03,Descripcion_Clave04,TipoDato_Clave04,Longitud_Clave04,Descripcion_Clave05,TipoDato_Clave05,Longitud_Clave05,Descripcion_Clave06,TipoDato_Clave06,Longitud_Clave06,Descripcion_Clave07,TipoDato_Clave07,Longitud_Clave07,Descripcion_Clave08,TipoDato_Clave08,Longitud_Clave08,Descripcion_Clave09,TipoDato_Clave09,Longitud_Clave09,Descripcion_Clave10,TipoDato_Clave10,Longitud_Clave10 ";
                queryString += " FROM Comprobantes ";
                queryString += " where IdDocumento='" + TID.Text + "' ";
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConSql"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                    }
                }

            }
            else
            {
                LTitulo.Text = "Ingreso de Usuarios";
                BnInsertar.Text = "Grabar";
                TID.Text = Request.QueryString["IDUsu"];
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
                GrabaUsuario();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "AKey", "MensajeOK();", true);
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
        if (TID.Text.Length == 0)
        {
            LID.ForeColor = System.Drawing.Color.Red;
            Errores.Text = "Atención: Los datos marcados en rojo son obligatorios. ";
        }
        else
        {
            LID.ForeColor = System.Drawing.Color.Black;
        }

    }
    void GrabaUsuario()
    {
        string queryString2 = "INSERT INTO Comprobantes	";
        queryString2 += "([IdDocumento]";
        queryString2 += ",[Documento]";
        queryString2 += ",[Descripcion_Clave01]";
        queryString2 += ",[TipoDato_Clave01]";
        queryString2 += ",[Longitud_Clave01]";       
        queryString2 += ",[Descripcion_Clave02]";
        queryString2 += ",[TipoDato_Clave02]";
        queryString2 += ",[Longitud_Clave02]";
        queryString2 += ",[Descripcion_Clave03]";
        queryString2 += ",[TipoDato_Clave03]";
        queryString2 += ",[Longitud_Clave03]";
        queryString2 += ",[Descripcion_Clave04]";
        queryString2 += ",[TipoDato_Clave04]";
        queryString2 += ",[Longitud_Clave04]";
        queryString2 += ",[Descripcion_Clave05]";
        queryString2 += ",[TipoDato_Clave05]";
        queryString2 += ",[Longitud_Clave05]";
        queryString2 += ",[Descripcion_Clave06]";
        queryString2 += ",[TipoDato_Clave06]";
        queryString2 += ",[Longitud_Clave06]";
        queryString2 += ",[Descripcion_Clave07]";
        queryString2 += ",[TipoDato_Clave07]";
        queryString2 += ",[Longitud_Clave07]";
        queryString2 += ",[Descripcion_Clave08]";
        queryString2 += ",[TipoDato_Clave08]";
        queryString2 += ",[Longitud_Clave08]";
        queryString2 += ",[Descripcion_Clave09]";
        queryString2 += ",[TipoDato_Clave09]";
        queryString2 += ",[Longitud_Clave09]";
        queryString2 += ",[Descripcion_Clave10]";
        queryString2 += ",[TipoDato_Clave10]";
        queryString2 += ",[Longitud_Clave10]";
        queryString2 += ",[Sys_User]";
        queryString2 += ",[Sys_Time]";
        queryString2 += ",[Sys_Date]";
        queryString2 += ",[Cliente])";
        queryString2 += "   VALUES				";
        queryString2 += "  ('" + TID.Text.ToUpper() + "'		";
        queryString2 += "  ,'" + HttpContext.Current.User.Identity.Name + "'		";
        queryString2 += "  ,'" + DateTime.Now.ToShortTimeString() + "'		";
        queryString2 += "  ,'" + DateTime.Now.ToShortDateString() + "'		";
      //  Errores.Text = queryString2;
          using (SqlConnection connection2 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConSql"].ConnectionString))
        {
            SqlCommand command2 = new SqlCommand(queryString2, connection2);
            connection2.Open();
            command2.ExecuteNonQuery();
        }
    }
    void ActuUsuario()
    {
        string queryString = "UPDATE Comprobantes	";
        queryString += " set ";
        queryString += "[IdDocumento]='" + TID.Text.ToUpper() + "'";
        queryString += ",[Sys_User]='" + HttpContext.Current.User.Identity.Name + "'";
        queryString += ",[Sys_Time]='" + DateTime.Now.ToShortTimeString() + "'";
        queryString += ",[Sys_Date]='" + DateTime.Now.ToShortDateString() + "'";
        queryString += " WHERE [IdDocumento]='" + TID.Text + "'";
     //  Errores.Text = queryString;
           using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConSql"].ConnectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            command.ExecuteNonQuery();
        }

    }
}

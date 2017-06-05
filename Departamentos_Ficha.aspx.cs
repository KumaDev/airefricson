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
                LTitulo.Text = "Modificación de Departamentos";
                BnInsertar.Text = "Modificar";
                TID.Text = Request.QueryString["ID"];
                string queryString = "SELECT Departamento,Activo,PorDefecto ";
                queryString += " FROM Departamentos ";
                queryString += " where IdDepartamento=" + TID.Text + " ";
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConSql"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TDepartamento.Text = Convert.ToString(reader[0]);
                        if (Convert.ToString(reader[1])=="1")
                        { TActivo.Checked = true; }
                        else
                        { TActivo.Checked = false; }
                        if (Convert.ToString(reader[2]) == "1")
                        { TPorDefecto.Checked = true; }
                        else
                        { TPorDefecto.Checked = false; }

                    }
                }
                clase_auditoria objclass1 = new clase_auditoria();
                objclass1.Graba_Temp_Auditoria("Departamentos", "IdDepartamento", TID.Text, HttpContext.Current.User.Identity.Name);
            }
            else
            {
                LTitulo.Text = "Ingreso de Departamentos";
                BnInsertar.Text = "Grabar";
                TID.Text = "0";
                clase_auditoria objclass1 = new clase_auditoria();
                objclass1.Graba_Temp_Auditoria("Departamentos", "IdDepartamento", "0", HttpContext.Current.User.Identity.Name);
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
                Grabar();
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "AKey", "MensajeOK();", true);
                ModalMensaje.Text = "Registro agregado.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            }
            else
            {
                Actualiza();
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "AKey", "MensajeOK2();", true);
                ModalMensaje.Text = "Registro modificado.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            }
        }
    }
    void Validar()
    {
        Errores.Text = "";
        if (TDepartamento.Text.Length == 0)
        {
            TDepartamento.BorderColor= System.Drawing.Color.Red;
            Errores.Text = "Atención: Los datos marcados en rojo son obligatorios. ";
        }
        else
        {
            TDepartamento.BorderColor = System.Drawing.Color.Black;
        }

        string queryString = "Select top 1 isnull(idDepartamento,0) from Departamentos where pordefecto=1 and iddepartamento<>"+TID.Text;
        Int16 NroPorDefecto = 0;
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConSql"].ConnectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                NroPorDefecto = Convert.ToInt16(reader[0]);
            }
        }
        if (NroPorDefecto != 0)
        {
			if (TPorDefecto.Checked==true)
			{   Errores.Text = "Atención: No se puede grabar , ya existe otro departamento por defecto.";}
        }


    }
    void Grabar()
    {
        string queryString = "Select top 1 isnull(idDepartamento,0) from Departamentos order by IdDepartamento Desc";
        Int16 NroId = 0;
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConSql"].ConnectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                NroId = Convert.ToInt16(reader[0]);
            }
        }
        NroId += 1;
        string queryString2 = "INSERT INTO Departamentos	";
        queryString2 += "(IdDepartamento";
        queryString2 += ",Departamento";
        queryString2 += ",Activo";
        queryString2 += ",PorDefecto)";
        queryString2 += "   VALUES	";
        queryString2 += "  (" + Convert.ToString(NroId) + " ";
        queryString2 += ",'" + TDepartamento.Text + "' ";
        if (TActivo.Checked == true)
        { queryString2 += ",1"; }
        else
        { queryString2 += ",0"; }
        if (TPorDefecto.Checked == true)
        { queryString2 += ",1"; }
        else
        { queryString2 += ",0"; }
        queryString2 += ")";
        using (SqlConnection connection2 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConSql"].ConnectionString))
        {
            SqlCommand command2 = new SqlCommand(queryString2, connection2);
            connection2.Open();
            command2.ExecuteNonQuery();
        }
        clase_auditoria objclass1 = new clase_auditoria();
        objclass1.Compara_Auditoria("Departamentos", "IdDepartamento", Convert.ToString(NroId) , "ALTA", HttpContext.Current.User.Identity.Name);
    }
    void Actualiza()
    {
        string queryString = "UPDATE Departamentos	";
        queryString += " set ";
        if (TActivo.Checked==true)
        { queryString += "Activo=1 ,"; }
        else
        { queryString += "Activo=0 ,"; }
        if (TPorDefecto.Checked == true)
        { queryString += "PorDefecto=1 ,"; }
        else
        { queryString += "PorDefecto=0 ,"; }
        queryString += "Departamento='" + TDepartamento.Text + "'";
        queryString += " WHERE IdDepartamento='" + TID.Text + "'";
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConSql"].ConnectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            command.ExecuteNonQuery();
        }
        clase_auditoria objclass1 = new clase_auditoria();
        objclass1.Compara_Auditoria("Departamentos", "IdDepartamento", TID.Text,"MODIFICACION", HttpContext.Current.User.Identity.Name);
    }
}

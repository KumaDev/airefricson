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

public partial class formulario1 : System.Web.UI.Page
{
    string fecha_ok = "";
    string Formula;
    string Aleatorio = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Datos_Iniciales();
        }
    }
    void Datos_Iniciales()
    { 
        string queryString = "SELECT Nombre,Apellido,IdDepartamento,ActiveDirectory ";
        queryString += "FROM usuarios  ";
        queryString += " WHERE usuario='" + HttpContext.Current.User.Identity.Name + "'";
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConSql"].ConnectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                LNombre.Text = Convert.ToString(reader[0]);
                LApellido.Text = Convert.ToString(reader[1]);
                LDepto.Text = Convert.ToString(reader[2]);
                LActive.Text = Convert.ToString(reader[3]);
            }
        }
    }
}
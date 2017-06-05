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
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;
using System.Runtime.InteropServices;

public partial class login : System.Web.UI.Page
{
    //private query qrs;
    private string default_page;
    private static IntPtr tokenHandle = new IntPtr(0);
    private static IntPtr dupeTokenHandle = new IntPtr(0);
    private static WindowsImpersonationContext impersonatedUser;
    private const int LOGON32_LOGON_NETWORK = 3;

    private bool LoginUsr = false;

    [DllImport("advapi32.dll", SetLastError = true)]

    public static extern bool LogonUser(
        String lpszUsername,
        String lpszDomain,
        String lpszPassword,
        int dwLogonType,
        int dwLogonProvider,
        ref IntPtr phToken);


    const int LOGON32_PROVIDER_DEFAULT = 0;
    const int LOGON32_LOGON_INTERACTIVE = 2;

    protected void Page_Load(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        txtUsuario.Focus();
        this.Form.DefaultButton = this.btIngreso.UniqueID;
    }

    private int comprobarUsuario(string Usuario, string Clave) 
    {


		int Grupo=0;
              
        Usuario = Usuario.Replace("'", " ");
        Clave = Clave.Replace("'", " ");
        int ActiveDirectory = 2;
        string queryStringAD = "SELECT ActiveDirectory FROM usuarios " +
                             "WHERE usuario='" + Usuario + "'";
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConSql"].ConnectionString))
        {
            SqlCommand command = new SqlCommand(queryStringAD, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ActiveDirectory = Convert.ToInt16(reader[0]);
            }
            reader.Close();
        }


        if (ActiveDirectory == 0)
        { 
            string queryString = "SELECT 1 FROM dbo.usuarios u " +
                                 "WHERE u.usuario='" + Usuario + "' and u.clave='" + Clave + "'";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConSql"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Grupo = Convert.ToInt16(reader[0]) ;
                }
                reader.Close();
            }
        }
        else
        {
		  bool res = IsValidUsr(Usuario,Clave);
            if (res)
            {
                Grupo = 1;
                if (ActiveDirectory == 2)
                { AltaUsuario(Usuario, Clave); }
			}
        }
        return (Grupo);
    }
	
    private bool IsValidUsr(string Usuario, string Clave)
    {
        try
        {
            //int IdApp = 0, IdUsr = 0;
            string NomDominio;
            //IdApp = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("idApp"));
            NomDominio = System.Configuration.ConfigurationManager.AppSettings.Get("DominioPfizer");

            tokenHandle = IntPtr.Zero;
            bool returnValue = LogonUser(
                                Usuario,
                                NomDominio,
                                Clave,
                                LOGON32_LOGON_NETWORK,
                                LOGON32_PROVIDER_DEFAULT,
                                ref tokenHandle);

            if (returnValue == true)
            {
                 return true ;
            }
            return false;
           //return (IdApp != 0 && IdUsr != 0); // paola
        }
        catch (Exception ex)
        {
            LabelAviso.Text = ex.ToString();
            return false;
        }
    }
	

    protected void btIngreso_Click(object sender, EventArgs e)
    {
        bool aceptado = false;
        LabelAviso.Text = "";
        if (comprobarUsuario(txtUsuario.Text, txtPassword.Text) > 0)
        {
            aceptado = true;
        }
        else
        {
            aceptado = false;
        }
        if (aceptado)
        {
            Session["usuario"] = txtUsuario.Text;
            FormsAuthentication.RedirectFromLoginPage(txtUsuario.Text, false);
        }
        else
        {
            LabelAviso.Text = LabelAviso.Text + "No estás autorizado a entrar en este sitio" ;
        }
    }

    private void AltaUsuario(string Usuario, string Clave)
    {
        clase_auditoria objclass1 = new clase_auditoria();
        objclass1.Graba_Temp_Auditoria("Usuarios", "IdUsuario", "0", Usuario);
        string IdMenu = "0";
        string IdDepartamento = "0";
        string queryString = "Select top 1 isnull(idUsuario,0) from Usuarios order by IdUsuario Desc";
        Int16 NroId = 0;
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConSql"].ConnectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            { NroId = Convert.ToInt16(reader[0]);  }
        }
        NroId += 1;
        string queryString2 = "INSERT INTO Usuarios	";
        queryString2 += "(IdUsuario";
        queryString2 += ",Usuario";
        queryString2 += ",Clave";
        queryString2 += ",Nombre";
        queryString2 += ",Apellido";
        queryString2 += ",Mail";
        queryString2 += ",Telefono";
        queryString2 += ",IdDepartamento";
        queryString2 += ",Activo";
        queryString2 += ",Bloqueado";
        queryString2 += ",ActiveDirectory";
        queryString2 += ",IdMenu)";
        queryString2 += "   VALUES	";
        queryString2 += "  (" + Convert.ToString(NroId) + " ";
        queryString2 += ",'" + Usuario + "' ";
        queryString2 += ",'"+Clave+"'"; 
        queryString2 += ",''";
        queryString2 += ",''";
        queryString2 += ",''";
        queryString2 += ",''";
        queryString2 += ","+IdDepartamento+"";
        queryString2 += ",1";
        queryString2 += ",0";
        queryString2 += ",1";
        queryString2 += ","+IdMenu+")";
        using (SqlConnection connection2 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConSql"].ConnectionString))
        {
            SqlCommand command2 = new SqlCommand(queryString2, connection2);
            connection2.Open();
            command2.ExecuteNonQuery();
        }
        clase_auditoria objclass2 = new clase_auditoria();
        objclass2.Compara_Auditoria("Usuarios", "IdUsuario", Convert.ToString(NroId), "ALTA",Usuario);
    }
}



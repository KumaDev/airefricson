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

public partial class loginprueba : System.Web.UI.Page
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

    private void LoginOK ()
    {
        bool aceptado = false;
        //
        // Prueba 2. Usando claves encriptadas con SHA1
        if (comprobarUsuario(txtUsuario.Text, txtPassword.Text)>0)
        {
            aceptado = true;
        }
        else
        {
            aceptado = false;
        }
        //
        // si es un usuario de los "previstos"
        // redirigirlo a la página "principal", por defecto: Default.aspx
        if (aceptado)
        {
            Session["usuario"] = txtUsuario.Text;
            FormsAuthentication.RedirectFromLoginPage(txtUsuario.Text, false);
        }
        else
        {
            // sino.. a la de error de login
            LabelAviso.Text = "No estás autorizado a entrar en este sitio";
        }
    }

    private int comprobarUsuario(string Usuario, string Clave) 
    {


		int Grupo=0;
              
        Usuario = Usuario.Replace("'", " ");
        Clave = Clave.Replace("'", " ");
        int ActiveDirectory = 1;

        bool res = IsValidUsr(Usuario,Clave);
            if (res)
            {
                    Grupo = 1;
			}
        return (Grupo);
    }
	
    private bool IsValidUsr(string Usuario, string Clave)
    {
        string str = "";
        try
        {
            int IdApp = 0, IdUsr = 0;

            IdApp = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("idApp"));

            tokenHandle = IntPtr.Zero;
            bool returnValue = LogonUser(
                                Usuario,
                                "AMER",
                                Clave,
                                LOGON32_LOGON_NETWORK,
                                LOGON32_PROVIDER_DEFAULT,
                                ref tokenHandle);

            if (returnValue == true)
            {
                 return true ;
            }
           return (IdApp != 0 && IdUsr != 0); // paola
        }
        catch (Exception ex)
        {
            str = ex.ToString();
            return false;
        }
    }
	

    protected void btIngreso_Click(object sender, EventArgs e)
    {
        LoginOK();
    }

}



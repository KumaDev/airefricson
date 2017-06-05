using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Permissions;
using System.Security.Principal;
using System.Runtime.InteropServices;

public partial class Login : System.Web.UI.Page
{
    //private query qrs;
    private conex cn;
    private string default_page;
    private static IntPtr tokenHandle = new IntPtr(0);
    private static IntPtr dupeTokenHandle = new IntPtr(0);
    private static WindowsImpersonationContext impersonatedUser;
    private const int LOGON32_LOGON_NETWORK = 3;

    private bool LoginUsr = false;

    /*[DllImport("advapi32.dll", SetLastError = true)]
    public static extern bool LogonUser(
        String lpszUsername,
        String lpszDomain,
        String lpszPassword,
        int dwLogonType,
        int dwLogonProvider,
        ref IntPtr phToken);*/
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

    }
    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            bool res = IsValidUsr();
            if (res)
            {
                Session["user"] = txtLogin.Text;
                Response.Redirect("Principal.aspx?usr=" + txtLogin.Text, true);
            }
            else
            {
                mb.Show("The user or password is incorrect. Please try again.");
            }
        }
        catch (Exception ex)
        {
            mb.Show("The server has an error. Please try again.");
        }
        //Response.Redirect("Principal.aspx", true);
    }
    private bool IsValidUsr()
    {
        string str = "";
        try
        {
            int IdApp = 0, IdUsr = 0;

            IdApp = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("idApp"));

            tokenHandle = IntPtr.Zero;
            bool returnValue = LogonUser(

                                this.txtLogin.Text,

                                cbodom.SelectedValue,

                                this.txtPassword.Text,

                                LOGON32_LOGON_NETWORK,

                                LOGON32_PROVIDER_DEFAULT,

                                ref tokenHandle);

            /*
             bool returnValue =  LogonUser(

                                this.txtLogin.Text,

                                txtDom.SelectedValue,

                                this.txtPassword.Text, 

                                LOGON32_LOGON_NETWORK, 

                                LOGON32_PROVIDER_DEFAULT, 

                                ref tokenHandle);
 
              
             */
            /*this.txtLogin.Text,
            //System.Configuration.ConfigurationManager.AppSettings.Get("dominio"),
            "amer.pfizer.com",
            this.txtPassword.Text,
            3,//LOGON32_LOGON_INTERACTIVE
            LOGON32_PROVIDER_DEFAULT,
            ref tokenHandle);
*/

            if (returnValue == true)
            {
                string strSQL;
                /* SqlCommand cmd;
                 SqlDataAdapter da;
                 DataSet ds = new DataSet("app_usr");
                 */
                LoginUsr = true;

                //llamo al SP que devuelve los valores para un combo determinado        
                strSQL = System.Configuration.ConfigurationManager.AppSettings.Get("dbsecurity").ToString() + "..sp_getAplicacionesUsuarios ";//SEGURIDAD..sp_getAplicacionesUsuarios ";
                strSQL += IdApp.ToString() + ",null,";
                // strSQL += "7,null,";
                strSQL += this.txtLogin.Text.Trim();
/*
                cmd = new SqlCommand();
                cmd.CommandText = strSQL;
                cmd.CommandType = CommandType.Text;
                clsConexion db = new clsConexion();
                cmd.Connection = db.DBConnection;
                //cmd.Connection 
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "app_usr_table");*/
                DataTable DT = new DataTable();
                cn = new conex();
                DT = cn.ejecutaQuerydatosSQL(strSQL, System.Configuration.ConfigurationManager.AppSettings.Get("csql").ToString());//"Data Source=POMAMRAPP01;Initial Catalog=GRS;Persist Security Info=True;User ID=sqladmin;Password=sqladmin123");
                if (DT.Rows.Count ==0 )
                {
                     return false ;
                }
                else
                {
                 return true ;
                }
                /*
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    IdApp = Convert.ToInt32(ds.Tables[0].Rows[0]["idApp"]);
                    IdUsr = Convert.ToInt32(ds.Tables[0].Rows[0]["idUsr"]);

                    if (IdApp != 0 && IdUsr != 0)
                    {
                        // Login OK y con ACCESO a la aplicacion
                        Session["ID_USUARIO"] = Convert.ToInt32(ds.Tables[0].Rows[0]["idUsr"]);
                        Session["ID_APP"] = Convert.ToInt32(ds.Tables[0].Rows[0]["idApp"]);
                        Session["NOMBRE"] = Convert.ToString(ds.Tables[0].Rows[0]["nombre"]);
                        Session["LOGIN"] = ds.Tables[0].Rows[0]["login"].ToString();
                        default_page = ds.Tables[0].Rows[0]["defaultPage"].ToString();
                        //
                        FormsAuthentication.Initialize();
                        FormsAuthentication.SetAuthCookie((string)Session["nombre"], false);
                    }
                }
                 * */
            }
           return (IdApp != 0 && IdUsr != 0); // paola
        }
        catch (Exception ex)
        {
            str = ex.ToString();
            return false;
        }
    }
}

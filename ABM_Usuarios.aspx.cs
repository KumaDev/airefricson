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




public partial class formulario1 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
	        {
              // LCliente.Text = Trae_Cliente(); 
	        }
    }

    protected void BtInsertar_Click(object sender, EventArgs e)
    {
        string Pagina = "Ingreso_Usuarios.aspx?Tipo=Insertar";
        Server.Transfer(Pagina);

    }
    protected void GridUsuarios_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Pagina = "Ingreso_Usuarios.aspx?Tipo=Modificacion";
        Pagina += "&IDUsu=" + GridUsuarios.SelectedRow.Cells[0].Text + "";
        Server.Transfer(Pagina);
    }
}

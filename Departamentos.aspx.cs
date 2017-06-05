using System;
using System.Data;
using System.Drawing;
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
            //Inicio
            this.GridMaestro.Sort("IdDepartamento", SortDirection.Ascending);
            string queryString = "SELECT count(*) FROM Departamentos ";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConSql"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Registros.Text = Convert.ToString(reader[0])+" Registros";
                }
            }
        }
        else
        {
            RefrescarGrid();
        }
    }

    protected void BtInsertar_Click(object sender, EventArgs e)
    {
        string Pagina = "Departamentos_Ficha.aspx?Tipo=Insertar";
        Server.Transfer(Pagina);

    }
    protected void GridMaestro_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Pagina = "Departamentos_Ficha.aspx?Tipo=Modificacion";
        Pagina += "&ID=" + GridMaestro.SelectedRow.Cells[1].Text + " ";
        Server.Transfer(Pagina);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
		RefrescarGrid();
    }
    protected void RefrescarGrid()
    {
        if (txtSearch.Text != "")
        {
            SqlDataMaestro.SelectCommand = "SELECT IdDepartamento,Departamento,Activo,PorDefecto FROM Departamentos WHERE Departamento like '%" + txtSearch.Text + "%' ";
            SqlDataMaestro.DataBind();
            GridMaestro.DataBind();
        }
        else
        {
            SqlDataMaestro.SelectCommand = "SELECT IdDepartamento,Departamento,Activo,PorDefecto FROM Departamentos";
            SqlDataMaestro.DataBind();
            GridMaestro.DataBind();
        }
        //GridMaestro.UseAccessibleHeader = true;
        //GridMaestro.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    protected void Titulos(object sender, GridViewRowEventArgs e)
    {
        string controlID = Page.Request.Params["__EVENTTARGET"];
        string SortID = Page.Request.Params["__EVENTARGUMENT"];

        if (e.Row.RowType == DataControlRowType.Header)
        {
            foreach (TableCell cell in e.Row.Cells)
            {
                if (cell.HasControls())
                {
                    LinkButton sortLink = (LinkButton)cell.Controls[0];
                    if (GridMaestro.SortExpression != "")
                    {
                        if (sortLink.CommandArgument == GridMaestro.SortExpression)
                        {
                            if (GridMaestro.SortDirection == SortDirection.Ascending)
                                sortLink.Text += "  <i class='fa fa-fw fa-sort-amount-asc'></i>";
                            else
                                sortLink.Text += "  <i class='fa fa-fw fa-sort-amount-desc'></i>";
                        }
                        else
                        {
                            sortLink.Text += "  <i class='fa fa-fw fa-sort'></i>";
                        }
                    }
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridMaestro, "Select$" + e.Row.RowIndex);
            e.Row.ToolTip = "Click para seleccionar.";
        }
    }
    protected void btExportToExcel_Click(object sender, EventArgs e)
    {
        // SET DATABASE CONNECTION.
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConSql"].ConnectionString))
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                // GET THE DATA FROM SQL SERVER TABLE.
                if (GridMaestro.SortDirection == SortDirection.Ascending)
                { cmd.CommandText = SqlDataMaestro.SelectCommand + " order by " + GridMaestro.SortExpression + " asc"; }
                else
                { cmd.CommandText = SqlDataMaestro.SelectCommand + " order by " + GridMaestro.SortExpression + " Desc"; }
                con.Open();

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;

                DataTable dt = new DataTable();
                sda.Fill(dt);

                // CALCULATE RUNNING TOTAL (WILL DISPLAY AT THE FOOTER OF EXCEL WORKBOOK.)
                Decimal dTotalPrice = 0;
                //for (int i = 0; i <= dt.Rows.Count - 1; i++)
                //{
                //    dTotalPrice += dt.Rows[i].Field<Decimal>(2);
                //}

                // NOW ASSIGN DATA TO A DATAGRID.
                DataGrid dg = new DataGrid();
                dg.DataSource = dt;
                dg.DataBind();

                // THE EXCEL FILE.
                string sFileName = "Departamentos-" + DateTime.Now.ToString("yyyymmdd") + ".xls";

                // SEND OUTPUT TO THE CLIENT MACHINE USING "RESPONSE OBJECT".
                Response.ClearContent();
                Response.Buffer = true;
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                Response.Charset = "UTF-8";
                Response.AddHeader("content-disposition", "attachment; filename=" + sFileName);
                Response.ContentType = "application/vnd.ms-excel";
                Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
                EnableViewState = true;

                System.IO.StringWriter objSW = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter objHTW = new System.Web.UI.HtmlTextWriter(objSW);

                dg.HeaderStyle.Font.Bold = true;     // SET EXCEL HEADERS AS BOLD.
                dg.RenderControl(objHTW);

                // STYLE THE SHEET AND WRITE DATA TO IT.
                Response.Write("<style> TABLE { border:solid 1px #999; } " +
                    "TD { border:solid 1px #D5D5D5; text-align:center } </style>");
                Response.Write(objSW.ToString());

                // ADD A ROW AT THE END OF THE SHEET SHOWING A RUNNING TOTAL OF PRICE.
                //Response.Write("<table><tr><td><b>Total: </b></td><td></td><td><b>" + dTotalPrice.ToString("N2") + "</b></td></tr></table>");

                Response.End();
                dg = null;
            }
        }
    }

}

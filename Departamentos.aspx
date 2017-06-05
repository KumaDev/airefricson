<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Departamentos.aspx.cs" Inherits="formulario1"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
    
    <form id="form1" runat="server">

<%--     <div class="row center" >
        <h1>Departamentos</h1>
     </div>
     <hr />--%>
          <div class="box">
            <div class="box-header">
              <h3 class="box-title">Tabla de Departamentos</h3>
            </div>

      <div class="box-body">  
        <div class="row">
          <div class="col-md-9">
              <div class="input-group">
                <span class="input-group-addon"> Busqueda <i class="fa fa-search"></i></span>
                <asp:TextBox ID="txtSearch" runat="server" onkeyup="Search(this);" ClientIDMode="Static" CssClass="form-control"  ></asp:TextBox>
                <button id="btnSearch" type="button" runat="server" class="SeachClick" onserverclick="btnSearch_Click" style="display: none;"></button>
               </div>
          </div> 
          <div class="col-md-3">
                <button runat="server" id="BtInsertar" class="btn btn-primary pull-right" onserverclick="BtInsertar_Click" Width="136px">
                    <i class="fa fa-plus"></i> 
                     Insertar
                </button>
          </div> 
        </div> 
      </div>
            <div class="box-body table-responsive ">  

   <asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager>

             <asp:UpdatePanel ID="upl" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
             <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="serverclick" />
                <asp:AsyncPostBackTrigger ControlID="txtSearch" />
                <asp:PostBackTrigger ControlID="GridMaestro"/> 
             </Triggers>
             <ContentTemplate> 


                <asp:GridView ID="GridMaestro" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" 
                    CssClass="table table-bordered table-striped table-hover"
                    HeaderStyle-CssClass="th"
                    DataSourceID="SqlDataMaestro"
                    OnSelectedIndexChanged="GridMaestro_SelectedIndexChanged" 
                    OnRowDataBound="Titulos"
                    DataKeyNames="IdDepartamento" PageSize="8" >
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" ButtonType="Link" HeaderText="Modificar" SelectText="<i class='fa fa-fw fa-hand-o-right'></i>" />
                        <asp:BoundField DataField="IdDepartamento" HeaderText="Id" SortExpression="IdDepartamento"></asp:BoundField>
                        <asp:BoundField DataField="Departamento" HeaderText="Departamento" SortExpression="Departamento"></asp:BoundField>
                        <asp:BoundField DataField="Activo" HeaderText="Activo" SortExpression="Activo"></asp:BoundField>
                        <asp:BoundField DataField="PorDefecto" HeaderText="PorDefecto" SortExpression="PorDefecto"></asp:BoundField>
                    </Columns>
                    <PagerStyle CssClass="bs-pagination" />
                </asp:GridView>
             </ContentTemplate>
             </asp:UpdatePanel>
            </div>
            <div class="box-footer">
               <div class="row center">
                  <div class="col-md-3">
                    <asp:Label Id="Registros" Text="0 Registros" runat="server"/>
                  </div>
                  <div class="col-md-3">
                  </div>
                  <div class="col-md-3">
                  </div>
                  <div class="col-md-3">
                    <button runat="server" id="btExportToExcel" class="btn btn-primary pull-right" onserverclick="btExportToExcel_Click" Width="336px">
                        <i class="fa fa-file-excel-o"></i> 
                         Exportar a Excel
                    </button>
                  </div>
               </div>
            </div>

		  </div>
		  
                <asp:SqlDataSource ID="SqlDataMaestro" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConSql %>" 
                    SelectCommand="SELECT IdDepartamento,Departamento,Activo,PorDefecto FROM Departamentos order by IdDepartamento" >
                </asp:SqlDataSource>



 </form>
</asp:Content>



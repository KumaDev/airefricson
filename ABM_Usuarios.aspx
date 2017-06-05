<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABM_Usuarios.aspx.cs" Inherits="formulario1"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <form id="form1" runat="server">
     <div class="row center" >
        <h1>Usuarios</h1>
     </div>
     <hr />
          <div class="box">
            <div class="box-header">
              <h3 class="box-title">Data Table With Full Features</h3>
            </div>
            <div class="box-body">  
                <asp:GridView ID="GridUsuarios" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" HeaderStyle-CssClass="table table-bordered table-striped"
                    DataSourceID="SqlDataUsuario"
                    CssClass="table table-bordered table-striped"
                    onselectedindexchanged="GridUsuarios_SelectedIndexChanged" 
                    DataKeyNames="IdUsuario" PageSize="5">
                    <Columns>
                        <asp:BoundField DataField="IdUsuario" HeaderText="Id" SortExpression="IdUsuario"></asp:BoundField>
                        <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario"></asp:BoundField>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre"></asp:BoundField>
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido"></asp:BoundField>
                        <asp:BoundField DataField="Departamento" HeaderText="Departamento" SortExpression="Departamento"></asp:BoundField>
                        <asp:BoundField DataField="Activo" HeaderText="Activo" SortExpression="Activo"></asp:BoundField>
                        <asp:BoundField DataField="ActiveDirectory" HeaderText="Valida por AD" SortExpression="ActiveDirectory"></asp:BoundField>
                        <asp:CommandField ShowSelectButton="True" ButtonType="Link" 
                            HeaderText="Modificar" SelectText="<i class='fa fa-fw fa-check'></i>" />
                    </Columns>
                </asp:GridView>
            </div>
          </div>
                <asp:SqlDataSource ID="SqlDataUsuario" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConSql %>" 
                    SelectCommand="SELECT Idusuario,Usuario,Nombre,Apellido,Departamento,Activo,ActiveDirectory FROM Usuarios" >
                </asp:SqlDataSource>

     <hr />
     <div class="row"> 
                <asp:Button ID="BtInsertar" runat="server" onclick="BtInsertar_Click" Text="Insertar" 
                 Width="136px" CssClass="btn btn-primary" />
     </div>

 </form>
</asp:Content>



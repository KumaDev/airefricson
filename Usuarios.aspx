<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Usuarios.aspx.cs" Inherits="formulario1"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
    <input id="inpHide" type="hidden" runat="server" />  
        <tr>
            <td colspan="4" style="height: 23px; font-size: x-large; text-align: center;">
                <strong>
                <asp:Label ID="LTitulo" runat="server"></asp:Label>
                </strong></td>
        </tr>
        <tr>
            <td colspan="4" 
                
                
                style="border-bottom: 2px ridge #808080; height: 23px; font-size: large; text-align: center;">
                <strong>
                <asp:Label ID="Errores" runat="server" style="color: #FF0000"></asp:Label>
                </strong>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; height: 23px; width: 244px;">
                <strong>
                <asp:Label ID="LUsuario" runat="server" Text="Usuario:" CssClass="style6"></asp:Label>
                </strong></td>
            <td style="height: 23px; text-align: left; ">
                <asp:TextBox ID="TUsuario" runat="server" MaxLength="100" width="128px" 
                    CssClass="style6"></asp:TextBox>
            </td>
            <td style="height: 23px; text-align: right; width: 149px;">
                <strong>
                <asp:Label ID="LClave" runat="server" Text="Clave:" CssClass="style6"></asp:Label>
                </strong></td>
            <td style="height: 23px; text-align: left">
                <asp:TextBox ID="TClave" runat="server" MaxLength="100" width="128px" 
                    CssClass="style6"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="border-top: 2px ridge #808080; border-bottom: 2px ridge #808080; padding: 1px 4px; text-align: left; height: 23px; font-size: medium; " 
                colspan="4">
                <strong>Datos Personales</strong></td>
        </tr>
        <tr>
            <td style="text-align: right; width: 244px; height: 26px;" class="style6">
                <strong>Nombre:</strong></td>
            <td style="text-align: left; height: 26px;">
                <asp:TextBox ID="TNombre" runat="server" MaxLength="50" width="128px" 
                    CssClass="style6"></asp:TextBox>
            </td>
            <td style="text-align: right; height: 26px; width: 149px;" class="style6">
                <strong>Apellido:</strong></td>
            <td style="text-align: left; height: 26px;">
                <asp:TextBox ID="TApe" runat="server" MaxLength="50" width="128px" 
                    CssClass="style6"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 244px; height: 26px;" class="style6">
                <strong>Mail:</strong></td>
            <td style="text-align: left; height: 26px;">
                <asp:TextBox ID="TMail" runat="server" Width="287px" MaxLength="500" 
                    CssClass="style6"></asp:TextBox>
            </td>
            <td style="text-align: right; height: 26px; width: 149px;" class="style6">
                <strong>Teléfono:</strong></td>
            <td style="text-align: left; height: 26px;">
                <asp:TextBox ID="TTel" runat="server" MaxLength="100" width="128px" 
                    CssClass="style6"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 244px; height: 26px;" class="style6">
                <strong>Descripción de tarea:</strong></td>
            <td style="text-align: left; height: 26px;" colspan="3">
                <asp:TextBox ID="Tdt" runat="server" Width="697px" MaxLength="250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 244px; height: 26px;" class="style6">
                <strong>Grupo:</strong></td>
            <td style="text-align: left; height: 26px;" colspan="3">
                <asp:DropDownList ID="DropGrupo" runat="server" AppendDataBoundItems="True" 
                    DataSourceID="SqlDataGrupo" DataTextField="descripcion" 
                    DataValueField="idgrupo" Height="20px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 244px; height: 26px;" class="style6">
                <strong>Sector:</strong></td>
            <td style="text-align: left; height: 26px;" colspan="3">
                <asp:DropDownList ID="DropSector" runat="server" Height="20px">
                    <asp:ListItem Value="Administracion">Administración</asp:ListItem>
                    <asp:ListItem Value="Tesoreria">Tesorería</asp:ListItem>
                    <asp:ListItem Value="Deposito">Depósito</asp:ListItem>
                    <asp:ListItem>Compras</asp:ListItem>
                    <asp:ListItem>Ventas</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 244px; height: 26px;" class="style6">
                <strong>Empresa:</strong></td>
            <td style="text-align: left; height: 26px;" colspan="3">
                <asp:DropDownList ID="DropEmp" runat="server" DataSourceID="SqlDataEmpresa" 
                    DataTextField="RazonSocial" DataValueField="Cliente" Height="20px" 
                    Width="284px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: left">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <strong>
                <asp:Button ID="BnInsertar" runat="server" 
                    style="font-weight: bold; font-size: small; " 
                    onclick="BnInsertar_Click" CssClass="btn btn-primary" Height="48px" />
                </strong></td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <asp:SqlDataSource ID="SqlDataGrupo" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cnPagina %>" SelectCommand="SELECT [idgrupo], [descripcion] FROM [Grupos_web]
where (idgrupo=2 or idgrupo=3)"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataEmpresa" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cnPagina %>" 
                    SelectCommand="SELECT [Cliente], [RazonSocial] FROM [Clientes]">
                </asp:SqlDataSource>
            </td>
        </tr>
        </table>
<script type="text/javascript">
    function DisableEnterSubmit(key) {
        if (key == 13) {
            return false;
        }
    }
</script>

<script type="text/javascript">
    function MensajeOK() {
        alert('SE HA GRABADO EXITOSAMENTE!!');
        window.location.href = "";
    };
</script>
<script type="text/javascript">
    function MensajeOK2() {
        alert('SE HA ACTUALIZADO EXITOSAMENTE!!');
        window.location.href = "";
    };
</script>
</asp:Content>


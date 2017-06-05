<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Ingreso_Usuarios.aspx.cs" Inherits="formulario1"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <form id="form1" runat="server">
    <table style="width: 100%">
    <input id="inpHide" type="hidden" runat="server" />  
        <tr>
            <td colspan="8" style="height: 23px; font-size: x-large; text-align: center;">
                <strong>
                <asp:Label ID="LTitulo" runat="server"></asp:Label>
                </strong></td>
        </tr>
        <tr>
            <td colspan="8" 
                
                
                
                style="border-bottom: 2px ridge #808080; height: 23px; font-size: large; text-align: center;">
                <strong>
                <asp:Label ID="Errores" runat="server" style="color: #FF0000"></asp:Label>
                </strong>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right; height: 23px;">
                <strong>
                <asp:Label ID="LID" runat="server" Text="Id Usuario:" Enabled="false"></asp:Label>
                </strong></td>
            <td colspan="2" style="text-align: left; height: 23px;">
                <asp:TextBox ID="TID" runat="server" MaxLength="3" Width="65px" style="text-transform :uppercase"></asp:TextBox>
            </td>
            <td colspan="2" style="text-align: right; height: 23px;">
                <strong>Usuario:</strong></td>
            <td colspan="2" style="text-align: left; height: 23px;">
                <asp:TextBox ID="TUsuario" runat="server" MaxLength="100" Width="273px" style="text-transform :uppercase"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <strong>Nombre</strong></td>
            <td colspan="2" style="text-align: left">
                <asp:TextBox ID="TNombre" runat="server" MaxLength="50" Width="211px" style="text-transform :uppercase"></asp:TextBox>
            </td>
            <td style="text-align: right">
                <strong>Apellido:</strong>
            </td>
            <td colspan="2" style="text-align: left">
                <asp:TextBox ID="TApellido" runat="server" MaxLength="50" Width="211px" style="text-transform :uppercase"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <strong>Email:</strong></td>
            <td colspan="2" style="text-align: left">
                <asp:TextBox ID="TEmail" runat="server" MaxLength="50" Width="211px" style="text-transform :uppercase"></asp:TextBox>
            </td>
            <td style="text-align: right">
                <strong>Telefono:</strong>
            </td>
            <td colspan="2" style="text-align: left">
                <asp:TextBox ID="TTelefono" runat="server" MaxLength="50" Width="211px" style="text-transform :uppercase"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <strong>Departamento:</strong></td>
            <td colspan="2" style="text-align: left">
                <asp:TextBox ID="TDepartamento" runat="server" MaxLength="50" Width="211px" style="text-transform :uppercase"></asp:TextBox>
            </td>
            <td style="text-align: right">
                <strong>Active Directory:</strong>
            </td>
            <td colspan="2" style="text-align: left">
                <asp:TextBox ID="TADirectory" runat="server" MaxLength="50" Width="211px" style="text-transform :uppercase"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="8" style="text-align: center">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="8" style="text-align: center">
                <strong>
                <asp:Button ID="BnInsertar" runat="server" 
                    style="font-weight: bold; font-size: small; " 
                    onclick="BnInsertar_Click" CssClass="btn btn-primary" Height="45px" />
                </strong></td>
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
 </form>
</asp:Content>


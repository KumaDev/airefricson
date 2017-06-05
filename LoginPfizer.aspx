<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    <table style="left: 200px; position: relative; top: 100px; background-color: #1e60aa;" >
      <tr>
        <td style="width: 65px; height: 211px;">
              <asp:Image ID="ImgLog" runat="server"  ImageUrl="~/Image/ImageLogin.jpg" />
        </td>
        <td style="width: 263px; height: 211px;">
         <table >
          <tr>
             <td style="width: 265px">
             </td>
          </tr>
          <tr>
             <td style="width: 265px">
               <asp:Label ID="Lbluser" runat="server" Text="User: " Font-Names="Verdana" Width="72px" ForeColor="White"></asp:Label>
               <asp:TextBox ID="txtLogin" runat="server" Font-Names="Verdana" ></asp:TextBox>
             </td>
          </tr>
          <tr>
             <td style="width: 265px">
             <asp:Label ID="Lblpass" runat="server" Text="Pass:            " Font-Names="Verdana" Width="72px" ForeColor="White"></asp:Label>
               <asp:TextBox ID="txtPassword" runat="server" Font-Names="Verdana" TextMode="Password" ></asp:TextBox>
             </td>
          </tr>
           <tr>
             <td style="width: 265px">
             <asp:Label ID="Label1" runat="server" Text="Domain:            " Font-Names="Verdana" Width="72px" ForeColor="White"></asp:Label>
                 <asp:DropDownList ID="cbodom" runat="server" Width="157px">
                     <asp:ListItem Selected=True Text="AMER" Value="AMER.PFIZER.COM"></asp:ListItem>
                     <asp:ListItem Text="WYETH/FD" Value="AMERICAS.AD.WYETH.COM"></asp:ListItem>
                 </asp:DropDownList></td>
          </tr>
          <tr>
             <td style="width: 265px; background-color: steelblue;">
             
             </td>
          </tr>
          <tr>
             <td style="width: 265px; height: 46px;" align="center">
                 &nbsp;<asp:Button ID="BtnLogin" runat="server" Text="Login" BackColor="SteelBlue" Font-Names="Verdana" ForeColor="White" OnClick="BtnLogin_Click" /></td>
          </tr>
         </table>
        </td>
          
      </tr>
     
    </table>
        <br />
        <br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    
    </div>
    </form>
</body>
</html>

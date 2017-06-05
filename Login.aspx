<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" CodePage="65001"%>
<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>--%>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <div class="row">
        <!-- left column -->
        <div class="col-md-6">
          <!-- general form elements -->
          <div class="box box-primary">
            <div class="box-header with-border">
              <h3 class="box-title">Ingreso al sistema AIR Web</h3>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
            <form role="form" id="form1" runat="server">
              <div class="box-body">
                <div class="form-group">
                  <label for="exampleInputUser">Usuario :</label>
                  <!--<input type="email" class="form-control" id="exampleInputEmail1" placeholder="Enter email">-->
                  <asp:TextBox ID="txtUsuario" runat="server" class="form-control" placeholder="Ingrese Usuario"></asp:TextBox>
                </div>
                <div class="form-group">
                  <label for="exampleInputPassword1">Contraseña :</label>
                  <!--<input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">-->
                  <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" class="form-control" placeholder="Contraseña"></asp:TextBox>
                </div>
                <div class="checkbox">
                  <label>
                    <asp:Label ID="LabelAviso" runat="server" CssClass="text-red" ></asp:Label>
                  </label>
                </div>
              </div>
              <!-- /.box-body -->

              <div class="box-footer">
                <asp:Button ID="btIngreso" runat="server" CssClass="btn btn-primary" onclick="btIngreso_Click" Text="Aceptar" />
              </div>
            </form>
          </div>
          <!-- /.box -->
        </div>
      </div>

</asp:Content>
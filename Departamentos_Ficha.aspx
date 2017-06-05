<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Departamentos_Ficha.aspx.cs" Inherits="formulario1"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <form id="form1" runat="server" class="form-horizontal">
    <input id="inpHide" type="hidden" runat="server" />  
     <div class="row center" >
        <h1>Departamentos</h1>
     </div>
     <hr />
          <div class="box box-info">
            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label ID="LTitulo" runat="server"></asp:Label></h3>
            </div>
            <div class="box-body">  
                <div class="form-group">
                    <label class="col-sm-2 control-label">Id:</label>
                    <div class="col-sm-10">
                     <asp:TextBox ID="TID" runat="server" Width="65px" cssclass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Departamento:</label> 
                    <div class="col-sm-10">
                     <asp:TextBox ID="TDepartamento" runat="server" cssclass="form-control"></asp:TextBox>
                    </div>
                </div>
                 <div class="form-group">
                  <div class="col-sm-offset-2 col-sm-10">
                    <div class="checkbox">
                      <label>
                         <asp:CheckBox ID="TActivo" Checked="false" Text="Activo" runat="server"  />
                      </label>
                    </div>
                   </div>
                </div>
                <div class="form-group">
                  <div class="col-sm-offset-2 col-sm-10">
                    <div class="checkbox">
                      <label>
                         <asp:CheckBox ID="TPorDefecto" Checked="false" Text="Departamento por defecto" runat="server" />
                      </label>
                    </div>
                  </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Errores" runat="server" style="color: #FF0000" ></asp:Label>
                </div>
             </div>
             <div class="box-footer">
                    <asp:Button ID="BnInsertar" runat="server" onclick="BnInsertar_Click" CssClass="btn btn-primary" Height="45px" />
                    <button type="button" style="display: none;" id="btnShowPopup" class="btn btn-primary btn-lg"
                    data-toggle="modal" data-target="#myModal">
                    Launch demo modal
                    </button> 
             </div>
          </div>       

<!-- Modal -->
<div id="myModal" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h5 class="modal-title">Grabación Exitosa!</h5>
      </div>
      <div class="modal-body">
        <p><asp:Label ID="ModalMensaje" runat="server"></asp:Label></p>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
      </div>
    </div>
  </div>
</div>

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
        window.location.href = "Departamentos.aspx";
    };
  </script>
  <script type="text/javascript">
    function MensajeOK2() {
        alert('SE HA ACTUALIZADO EXITOSAMENTE!!');
        window.location.href = "Departamentos.aspx";
    };
  </script>
  <script type="text/javascript">
        function ShowPopup() {
            $("#btnShowPopup").click();
        }
  </script>  
  <script>
    $(document).ready(function(){
            $("#myModal").on('hidden.bs.modal', function () {
                window.location.href = "Departamentos.aspx";
        });
    });
  </script>
 </form>
</asp:Content>


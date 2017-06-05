<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="formulario1"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row center" >
                    <h2 class="heading-primary text-uppercase mb-md">Sistema de Archivo Digital</h2>
     </div>
     <hr class="tall" />
					<div class="container">
						<div class="row center">
							<div class="col-lg-2">
                                <h4>Bienvenido , </h4>
	                   		</div>
    						<div class="col-lg-2">
                                <p><asp:Label ID="LNombre" runat="server"></asp:Label></p>
	                   		</div>
    						<div class="col-lg-2">
                                <p><asp:Label ID="LApellido" runat="server"></asp:Label></p>
	                   		</div>
                        </div>
						<div class="row center">
							<div class="col-lg-2">
                                <h4>Departamento :</h4>
	                   		</div>
    						<div class="col-lg-2">
                                <p><asp:Label ID="LDepto" runat="server"></asp:Label></p>
	                   		</div>
							<div class="col-lg-2">
                                <h4>Active Directory :</h4>
	                   		</div>
    						<div class="col-lg-2">
                                <p><asp:Label ID="LActive" runat="server"></asp:Label></p>
	                   		</div>
                        </div>
                    </div>
     <hr class="tall" />
</asp:Content>


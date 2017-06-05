<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="loginprueba.aspx.cs" Inherits="loginprueba"%>
<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>--%>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <form id="form1" runat="server">

							<div class="featured-boxes">
								<div class="row">
									<div class="col-sm-6">
										<div class="featured-box featured-box-primary align-left mt-xlg">
											<div class="box-content">
												<h4 class="heading-primary text-uppercase mb-md">ACCESO CLIENTES</h4>
<%--												<form action="/" id="frmSignIn" method="post">--%>
													<div class="row">
														<div class="form-group">
															<div class="col-md-12">
																<label>Nombre de Usuario</label>
                                                                <asp:TextBox ID="txtUsuario" runat="server" class="form-control input-lg"></asp:TextBox>
				                                            </div>
														</div>
													</div>
													<div class="row">
														<div class="form-group">
															<div class="col-md-12">
<%--																<a class="pull-right" href="#">(Olvidó la Clave?)</a>--%>
																<label>Clave</label>
                                                                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" class="form-control input-lg"></asp:TextBox>
															</div>
														</div>
													</div>
													<div class="row">
														<div class="col-md-6">
															<span class="remember-box checkbox">
<%--																<label for="rememberme">
																	<input type="checkbox" id="rememberme" name="rememberme">Recordar clave
																</label>--%>
															</span>
														</div>
														<div class="col-md-6">
                                                            <asp:Button ID="btIngreso" runat="server" CssClass="btn btn-primary pull-right mb-xl" onclick="btIngreso_Click" Text="Aceptar" />
														</div>
                              <asp:Label ID="LabelAviso" runat="server" Height="21px" Width="255px" style="color: #000000; font-family: Arial, Helvetica, sans-serif; font-size: small; text-align: center;"></asp:Label>

													</div>
<%--												</form>--%>
											</div>
										</div>
									</div>
								</div>
							  </div>
 </form>
</asp:Content>
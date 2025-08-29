<%@ Page Title="Nuevo Usuario" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="NuevoUsuario.aspx.cs"
    Inherits="AdminUsuariosApp.UI.NuevoUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-center">
        <div class="col-md-10 col-lg-8">
            <div class="card shadow-sm border-0 rounded-3">
                <div class="card-body p-4">

                    <!-- Título -->
                    <h2 class="mb-2">Alta de Usuario</h2>
                    <p class="text-muted mb-4">Complete los siguientes datos para registrar un nuevo usuario.</p>
                    <div class="row">
                        <!-- NickName -->
                        <asp:UpdatePanel ID="upNickName" runat="server" UpdateMode="Always" RenderMode="Block">
                            <ContentTemplate>
                                <div class="col-md-6 mb-6">
                                    <label for="txtNickName" class="form-label fw-semibold">NickName</label>
                                    <asp:TextBox ID="txtNickName" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtNickName_TextChanged" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                        ControlToValidate="txtNickName"
                                        ErrorMessage="El NickName es obligatorio"
                                        CssClass="invalid-feedback" Display="Dynamic" />
                                   <div style="min-height: 2.5rem;">
                                    <asp:CustomValidator ID="cvNickName" runat="server"
                                        ControlToValidate="txtNickName"
                                        ErrorMessage="NickName inválido o duplicado"
                                        OnServerValidate="cvNickName_ServerValidate"
                                        CssClass="invalid-feedback" Display="Dynamic"
                                        ValidationGroup="NickNameGroup" />

                                    <asp:Label ID="lblNickNameEstado" runat="server" CssClass="form-text fw-semibold"></asp:Label>
                                    </div>
                                </div>

                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="txtNickName" EventName="TextChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                        
                    </div>

                    <div class="row">
                        <!-- Nombre -->
                        <div class="col-md-6 mb-3">
                            <label for="txtNombreCompleto" class="form-label fw-semibold">Nombre Completo</label>
                            <asp:TextBox ID="txtNombreCompleto" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="rfvNombreCompleto" runat="server"
                                ControlToValidate="txtNombreCompleto"
                                ErrorMessage="El nombre es obligatorio"
                                CssClass="invalid-feedback" Display="Dynamic" />
                        </div>

                        <!-- Email -->
                        <div class="col-md-6 mb-3">
                            <label for="txtEmail" class="form-label fw-semibold">Email</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" aria-describedby="emailHelp" />
                            <div class="form-text">Ejemplo: usuario@dominio.com</div>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                                ControlToValidate="txtEmail" ErrorMessage="El email es obligatorio"
                                CssClass="invalid-feedback" Display="Dynamic" />
                            <asp:RegularExpressionValidator ID="revEmail" runat="server"
                                ControlToValidate="txtEmail"
                                ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
                                ErrorMessage="Formato de email inválido"
                                CssClass="invalid-feedback" Display="Dynamic" />
                        </div>
                    </div>

                    <div class="row">
                        <!-- Fecha de Nacimiento -->
                        <div class="col-md-6 mb-3">
                            <label for="txtFechaNacimiento" class="form-label fw-semibold">Fecha de Nacimiento</label>
                            <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date" />
                            <asp:RequiredFieldValidator ID="rfvFecha" runat="server"
                                ControlToValidate="txtFechaNacimiento"
                                ErrorMessage="La fecha es obligatoria"
                                CssClass="invalid-feedback" Display="Dynamic" />
                            <asp:RangeValidator ID="rvFecha" runat="server"
                                ControlToValidate="txtFechaNacimiento"
                                Type="Date"
                                MinimumValue="01/01/1900"
                                MaximumValue="01/01/2025"
                                ErrorMessage="Debe estar entre 1900 y 2025"
                                CssClass="invalid-feedback" Display="Dynamic" />
                        </div>

                        <!-- Rol del Usuario -->
                        <div class="col-md-6 mb-3">
                            <label for="ddlTipoUsuario" class="form-label fw-semibold">Rol</label>
                            <asp:DropDownList ID="ddlTipoUsuario" runat="server" CssClass="form-select">
                                <asp:ListItem Text="Seleccione..." Value="" />
                                <asp:ListItem Text="Administrador" Value="Administrador" />
                                <asp:ListItem Text="Jefe de Área" Value="JefeArea" />
                                <asp:ListItem Text="Supervisor" Value="Supervisor" />
                                <asp:ListItem Text="Agente" Value="Agente" />
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvTipoUsuario" runat="server"
                                ControlToValidate="ddlTipoUsuario"
                                InitialValue=""
                                ErrorMessage="Debe seleccionar un tipo de usuario"
                                CssClass="invalid-feedback" Display="Dynamic" />
                        </div>
                    </div>

                    <div class="row">
                        <!-- Tipo de Documento -->
                        <div class="col-md-6 mb-3">
                            <label for="ddlTipoDocumento" class="form-label fw-semibold">Tipo de Documento</label>
                            <asp:DropDownList ID="ddlTipoDocumento" runat="server" CssClass="form-select">
                                <asp:ListItem Text="Seleccione..." Value="" />
                                <asp:ListItem Text="DNI" Value="DNI" />
                                <asp:ListItem Text="Pasaporte" Value="Pasaporte" />
                                <asp:ListItem Text="CUIT" Value="CUIT" />
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvTipoDoc" runat="server"
                                ControlToValidate="ddlTipoDocumento"
                                InitialValue=""
                                ErrorMessage="Debe seleccionar un tipo de documento"
                                CssClass="invalid-feedback" Display="Dynamic" />
                        </div>

                        <!-- Número de Documento -->
                        <div class="col-md-6 mb-3">
                            <label for="txtNumeroDocumento" class="form-label fw-semibold">Número de Documento</label>
                            <asp:TextBox ID="txtNumeroDocumento" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="rfvNumeroDoc" runat="server"
                                ControlToValidate="txtNumeroDocumento"
                                ErrorMessage="El número de documento es obligatorio"
                                CssClass="invalid-feedback" Display="Dynamic" />
                            <asp:RegularExpressionValidator ID="revNumeroDoc" runat="server"
                                ControlToValidate="txtNumeroDocumento"
                                ValidationExpression="^\d{7,10}$"
                                ErrorMessage="Debe contener entre 7 y 10 dígitos"
                                CssClass="invalid-feedback" Display="Dynamic" />
                        </div>
                    </div>

                    <!-- Botones -->
                    <div class="d-flex justify-content-end gap-2 mt-3">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary"
                            OnClick="btnGuardar_Click" OnClientClick="return validarConBootstrap();" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-outline-secondary"
                            OnClick="btnCancelar_Click" CausesValidation="false" />
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>

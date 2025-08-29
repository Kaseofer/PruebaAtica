<%@ Page Title="Lista de Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarUsuarios.aspx.cs" Inherits="AdminUsuariosApp.UI.ListarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2>Listado de Usuarios</h2>
     <div class="table-responsive">
        <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="NickName" HeaderText="Usuario" />
                <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre Completo" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="FechaNacimiento" HeaderText="Nacimiento" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="TipoDocumento" HeaderText="Tipo Doc." />
                <asp:BoundField DataField="NumeroDocumento" HeaderText="N° Documento" />
                <asp:BoundField DataField="TipoUsuario" HeaderText="Rol" />
                <asp:BoundField DataField="FechaAlta" HeaderText="Alta" DataFormatString="{0:dd/MM/yyyy HH:mm}" />

                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar"
                            CommandName="Eliminar" 
                            CommandArgument='<%# Eval("Id") %>' 
                            CssClass="btn btn-danger btn-sm"
                           OnClientClick  ='<%# "confirmarBorrado(\"" + Eval("NickName") + "\", \"" + Eval("Id") + "\"); return false" %>' />                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
        
        <asp:Button ID="btnNuevoUsuario" runat="server" Text="Nuevo Usuario" CssClass="btn btn-primary mt-3" OnClick="btnNuevoUsuario_Click" />

    </div>
    <!-- aca guardo el Id del Usuario a borrar, esperando la confirmacion -->
    <asp:HiddenField ID="hfIdUsuarioEliminar" runat="server" />

    <!-- Modal de Bootstrap -->
    <div class="modal fade" id="confirmModal" tabindex="-1" aria-labelledby="confirmModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="confirmModalLabel">Confirmar eliminación</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Cerrar"></button>
                </div>
                <div class="modal-body" id="modalBody">
                    
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnConfirmarEliminar" runat="server" Text="Eliminar usuario" CssClass="btn btn-danger" OnClick="btnConfirmarEliminar_Click" />
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Rutina Llamadora del Modal -->
    <script>
        function confirmarBorrado(nombre, id) {
            document.getElementById('<%= hfIdUsuarioEliminar.ClientID %>').value = id; //aca seteo el Id que voy a borrar en un hidden => (btnConfirmarEliminar_Click)
            document.getElementById('modalBody').innerText = "¿Estás seguro que querés borrar a " + nombre + "?";
            var modal = new bootstrap.Modal(document.getElementById('confirmModal'));
            modal.show();
        }
    </script>
</asp:Content>

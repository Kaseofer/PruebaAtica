using AdminUsuarioApp.BLL.Services;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminUsuariosApp.UI
{
    public partial class ListarUsuarios : Page
    {
        private readonly UsuarioService _usuarioService = new UsuarioService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuarios();
            }
        }

        protected void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoUsuario.aspx");
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int idUsuario = Convert.ToInt32(e.CommandArgument);
                // se guarda el ID en una variable de sesión  para usarlo en el modal
                Session["IdUsuarioAEliminar"] = idUsuario;
                
            }
        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(hfIdUsuarioEliminar.Value);
            _usuarioService.Eliminar(id);
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            gvUsuarios.DataSource = _usuarioService.ObtenerTodos();
            gvUsuarios.DataBind();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
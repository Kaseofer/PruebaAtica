using AdminUsuarioApp.BLL.Dtos;
using AdminUsuarioApp.BLL.Services;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminUsuariosApp.UI
{
    public partial class NuevoUsuario : System.Web.UI.Page
    {
        private readonly UsuarioService _usuarioService = new UsuarioService(); // O vía DI si tenés configurado

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }


        protected void ActualizarValidaciones()
        {
            foreach (BaseValidator validator in Page.Validators)
            {
                var ctrl = validator.NamingContainer.FindControl(validator.ControlToValidate);
                if (ctrl is WebControl wc)
                {
                    wc.CssClass = wc.CssClass.Replace("is-invalid", "").Trim();
                }
            }

            foreach (BaseValidator validator in Page.Validators)
            {
                if (!validator.IsValid)
                {
                    var ctrl = validator.NamingContainer.FindControl(validator.ControlToValidate);
                    if (ctrl is WebControl wc && !wc.CssClass.Contains("is-invalid"))
                    {
                        wc.CssClass += " is-invalid";
                    }
                }
            }
        }



        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //si no es valida marcomos los controles con error
            if (!Page.IsValid)
            {
                ActualizarValidaciones();
                return;
            }

            var usuario = new UsuarioDTO
            {
                Nombre = txtNombre.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text),
                TipoDocumento = ddlTipoDocumento.SelectedValue,
                NumeroDocumento = txtNumeroDocumento.Text.Trim(),
                TipoUsuario = ddlTipoUsuario.SelectedValue,
                FechaAlta = DateTime.Now
            };

            bool resultado = _usuarioService.Agregar(usuario);

            if (resultado)
                Response.Redirect("ListarUsuarios.aspx");
            else
                // Podés mostrar un mensaje de error con un Label o Toast
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Error al guardar el usuario');", true);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListarUsuarios.aspx");
        }
    }
}

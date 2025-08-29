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
            Page.Validate();

            if (!Page.IsValid)
            {
                ActualizarValidaciones();
                return;
            }

            var usuario = new UsuarioDto
            {
                NickName = txtNickName.Text.Trim(),
                NombreCompleto = txtNombreCompleto.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text),
                TipoDocumento = ddlTipoDocumento.SelectedValue,
                NumeroDocumento = txtNumeroDocumento.Text.Trim(),
                TipoUsuario = ddlTipoUsuario.SelectedValue,
                FechaAlta = DateTime.Now
            };

            bool resultado = _usuarioService.Agregar(usuario);



            if (resultado)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "toastExito", "new bootstrap.Toast(document.getElementById('toastExito')).show();", true);
                Response.Redirect("ListarUsuarios.aspx");
            }
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "toastError", "new bootstrap.Toast(document.getElementById('toastError')).show();", true);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListarUsuarios.aspx");
        }

        protected void txtNickName_TextChanged(object sender, EventArgs e)
        {
            Page.Validate("NickNameGroup");
        }
        protected void cvNickName_ServerValidate(object source, ServerValidateEventArgs args)
        {

            string nick = args.Value.Trim();
            bool existe = _usuarioService.ExisteNickName(nick);

            if (string.IsNullOrEmpty(nick))
            {
                args.IsValid = false;
                lblNickNameEstado.Text = "El NickName es obligatorio.";
                lblNickNameEstado.CssClass = "form-text text-danger fw-semibold";
                txtNickName.CssClass = "form-control is-invalid";
            }
            else if (existe)
            {
                args.IsValid = false;
                lblNickNameEstado.Text = "El NickName ya existe.";
                lblNickNameEstado.CssClass = "form-text text-danger fw-semibold";
                txtNickName.CssClass = "form-control is-invalid";
            }
            else
            {
                args.IsValid = true;
                lblNickNameEstado.Text = "NickName válido.";
                lblNickNameEstado.CssClass = "form-text text-success fw-semibold";
                txtNickName.CssClass = "form-control is-valid";
            }
        }

    }
}

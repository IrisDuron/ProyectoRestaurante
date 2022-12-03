using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoRestaurante.Interfaces;

namespace ProyectoRestaurante.Pages.MisUsuarios
{
    public partial class EditarUsuario
    {
        [Inject] private IUsuarioServicio usuarioServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        private Usuario user = new Usuario();

        [Inject] SweetAlertService Swal { get; set; }

        [Parameter] public string CodigoUsuario { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (string.IsNullOrEmpty(CodigoUsuario))
            {
                user = await usuarioServicio.GetPorCodigo(CodigoUsuario);
            }
        }

        protected async void Guardar()
        {
            if (string.IsNullOrEmpty(user.CodigoUsuario) || string.IsNullOrEmpty(user.Nombre) || string.IsNullOrEmpty(user.Clave)
                || string.IsNullOrEmpty(user.Rol) || user.Rol == "Seleccionar")
            {
                return;
            }

            bool edito = await usuarioServicio.Actualizar(user);
            if (edito)
            {
                await Swal.FireAsync("Felicidades", "Usuario Actualizado con exito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "Usuario No Actualizado", SweetAlertIcon.Error);
            }

            navigationManager.NavigateTo("/Usuario");
        }

        protected void Cancelar()
        {
            navigationManager.NavigateTo("/Usuario");
        }

        protected async void Eliminar()
        {
            bool elimino = false;

            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "¿Esta seguro que desea elminar el registro?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Aceptar",
                CancelButtonText = "Cancelar"
            });

            if (string.IsNullOrEmpty(result.Value))
            {
                elimino = await usuarioServicio.Eliminar(CodigoUsuario);

                if (elimino)
                {
                    await Swal.FireAsync("Listo", "Usuario Eliminado con exito", SweetAlertIcon.Success);
                    navigationManager.NavigateTo("/Usuario");
                }
                else
                {
                    await Swal.FireAsync("Error", "Usuario No Eliminado", SweetAlertIcon.Error);
                }
            }
        }

    }
}

using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoRestaurante.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;

namespace ProyectoRestaurante.Pages.MisUsuarios
{
    public partial class NuevoUsuario
    {
        [Inject] private IUsuarioServicio usuarioServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        private Usuario user = new Usuario();

        [Inject] SweetAlertService Swal { get; set; }


        protected async void Guardar()
        {
            if (string.IsNullOrEmpty(user.CodigoUsuario) || string.IsNullOrEmpty(user.Nombre) || string.IsNullOrEmpty(user.Clave)
                || string.IsNullOrEmpty(user.Rol) || user.Rol == "Seleccionar")
            {
                return;
            }

            bool inserto = await usuarioServicio.Nuevo(user);
            if (inserto)
            {
                await Swal.FireAsync("Felicidades", "Usuario Guardado con exito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "Usuaurio No Guardado", SweetAlertIcon.Error);
            }

            navigationManager.NavigateTo("/Usuario");
        }

        protected void Cancelar()
        {
            navigationManager.NavigateTo("/Usuario");
        }

    }
}

enum Roles
{
    Seleccionar,
    Administrador,
    Usuario
}

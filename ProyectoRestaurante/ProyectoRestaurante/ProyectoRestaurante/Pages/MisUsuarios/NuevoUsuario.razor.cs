using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoRestaurante.Interfaces;

namespace ProyectoRestaurante.Pages.MisUsuarios
{
    public partial class NuevoUsuario
    {
        [Inject] private IUsuarioServicio usuarioServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        private Usuario user = new Usuario();

        protected async void Guardar()
        {
            if (string.IsNullOrEmpty(user.CodigoUsuario) || string.IsNullOrEmpty(user.Nombre) || string.IsNullOrEmpty(user.Clave)
                || string.IsNullOrEmpty(user.Rol) || user.Rol == "Seleccionar")
            {
                return;
            }

            bool inserto = await usuarioServicio.Nuevo(user);

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

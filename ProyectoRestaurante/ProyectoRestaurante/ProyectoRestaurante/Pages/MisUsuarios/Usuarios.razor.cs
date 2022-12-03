using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoRestaurante.Interfaces;

namespace ProyectoRestaurante.Pages.MisUsuarios
{
    public partial class Usuarios
    {
        [Inject] private IUsuarioServicio usuarioServicio { get; set; }

        private IEnumerable<Usuario> lista { get; set; }

        protected override async Task OnInitializedAsync()
        {
            lista = await usuarioServicio.GetLista();
        }
    }
}

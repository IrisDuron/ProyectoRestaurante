using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoRestaurante.Interfaces;

namespace ProyectoRestaurante.Pages.MiMenu
{
    public partial class Menus
    {
        [Inject] private IMenuServicio MenuServicio { get; set; }

        private IEnumerable<Menu> listaMenus { get; set; }

        protected override async Task OnInitializedAsync()
        {
            listaMenus = await MenuServicio.GetLista();
        }
    }
}

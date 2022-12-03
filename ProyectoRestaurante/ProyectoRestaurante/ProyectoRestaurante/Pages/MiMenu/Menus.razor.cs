using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoRestaurante.Interfaces;



namespace ProyectoRestaurante.Pages.MisMenus
{
    public partial class Menus
    {
        [Inject]  IMenuServicio MenuServicio { get; set; }

         IEnumerable<Menu> listaMenus { get; set; }

        protected override async Task OnInitializedAsync()
        {
            listaMenus = await MenuServicio.GetLista();
        }
    }
}


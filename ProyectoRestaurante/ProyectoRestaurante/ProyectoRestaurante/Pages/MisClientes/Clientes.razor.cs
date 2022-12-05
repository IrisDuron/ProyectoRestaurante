using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoRestaurante.Interfaces;

namespace ProyectoRestaurante.Pages.MisClientes
{
    public partial class Clientes
    {
        [Inject] private IClienteServicio ClienteServicio { get; set; }

        private IEnumerable<Cliente> listaClientes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            listaClientes = await ClienteServicio.GetLista();
        }
    }
}

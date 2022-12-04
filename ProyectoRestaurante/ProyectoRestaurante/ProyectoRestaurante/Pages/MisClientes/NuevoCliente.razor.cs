using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoRestaurante.Interfaces;

namespace ProyectoRestaurante.Pages.MisClientes
{
    public partial class NuevoCliente
    {
        [Inject] private IClienteServicio clienteServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        private Cliente clien = new Cliente();

        [Inject] SweetAlertService Swal { get; set; }


        protected async void Guardar()
        {
            if (string.IsNullOrEmpty(clien.identidadCliente) || string.IsNullOrEmpty(clien.Nombre))
            {
                return;
            }

            bool inserto = await clienteServicio.Nuevo(clien);
            if (inserto)
            {
                await Swal.FireAsync("Felicidades", "Cliente Guardado con exito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "Cliente No Guardado", SweetAlertIcon.Error);
            }

            navigationManager.NavigateTo("/Cliente");
        }

        protected void Cancelar()
        {
            navigationManager.NavigateTo("/Cliente");
        }
    }
}

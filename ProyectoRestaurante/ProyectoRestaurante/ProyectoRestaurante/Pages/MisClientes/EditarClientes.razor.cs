using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoRestaurante.Interfaces;

namespace ProyectoRestaurante.Pages.MisClientes
{
    public partial  class EditarClientes
    {
        [Inject] private IClienteServicio clienteServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        private Cliente clien = new Cliente();

        [Inject] SweetAlertService Swal { get; set; }

        [Parameter] public string identidadCliente { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (string.IsNullOrEmpty(identidadCliente))
            {
                clien = await clienteServicio.GetPorCodigo(identidadCliente);
            }
        }

        protected async void Guardar()
        {
            if (string.IsNullOrEmpty(clien.identidadCliente) || string.IsNullOrEmpty(clien.Nombre))
            {
                return;
            }

            bool edito = await clienteServicio.Actualizar(clien);
            if (edito)
            {
                await Swal.FireAsync("Felicidades", "Cliente Actualizado con exito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "Cliente No Actualizado", SweetAlertIcon.Error);
            }

            navigationManager.NavigateTo("/Cliente");
        }

        protected void Cancelar()
        {
            navigationManager.NavigateTo("/Cliente");
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
                elimino = await clienteServicio.Eliminar(identidadCliente);

                if (elimino)
                {
                    await Swal.FireAsync("Listo", "Cliente Eliminado con exito", SweetAlertIcon.Success);
                    navigationManager.NavigateTo("/Cliente");
                }
                else
                {
                    await Swal.FireAsync("Error", "Cliente No Eliminado", SweetAlertIcon.Error);
                }
            }
        }
    }
}

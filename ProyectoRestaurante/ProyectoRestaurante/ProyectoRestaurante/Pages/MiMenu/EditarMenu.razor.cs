using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Modelos;
using ProyectoRestaurante.Interfaces;

namespace ProyectoRestaurante.Pages.MiMenu
{
    public partial class EditarMenu
    {
        [Inject] private IMenuServicio MenuServicio { get; set; }

        private Menu prod = new Menu();
        [Inject] private SweetAlertService Swal { get; set; }

        [Inject] NavigationManager _navigationManager { get; set; }
        [Parameter] public string CodigoMenu { get; set; }

        string imgUrl = string.Empty;
      


        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(CodigoMenu))
            {
                prod = await MenuServicio.GetPorCodigo(Convert.ToInt32(CodigoMenu));
            }
        }
        

        protected async Task Guardar()
        {
            if (string.IsNullOrEmpty(prod.Descripcion))
            {
                return;
            }

            bool edito = await MenuServicio.Actualizar(prod);

            if (edito)
            {
                await Swal.FireAsync("Advertencia", "Producto guardado con exito", SweetAlertIcon.Success);
                _navigationManager.NavigateTo("/Productos");
            }
            else
            {
                await Swal.FireAsync("Advertencia", "No se pudo guardar el producto", SweetAlertIcon.Error);
            }
        }
        protected async Task Cancelar()
        {
            _navigationManager.NavigateTo("/Productos");
        }

        protected async Task Eliminar()
        {
            bool elimino = false;

            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "¿Seguro que desea eliminar el registro?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Aceptar",
                CancelButtonText = "Cancelar"
            });

            if (!string.IsNullOrEmpty(result.Value))
            {
                elimino = await MenuServicio.Eliminar(Convert.ToInt32(CodigoMenu));

                if (elimino)
                {
                    await Swal.FireAsync("Felifidades", "Producto Eliminado", SweetAlertIcon.Success);
                    _navigationManager.NavigateTo("/Productos");
                }
                else
                {
                    await Swal.FireAsync("Error", "No se pudo Eliminar el producto", SweetAlertIcon.Error);
                }
            }
        }


    }
}

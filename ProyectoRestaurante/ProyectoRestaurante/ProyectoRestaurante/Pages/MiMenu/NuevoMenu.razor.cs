using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using ProyectoRestaurante.Interfaces;
using Modelos;
using ProyectoRestaurante.Servicios;

namespace ProyectoRestaurante.Pages.MiMenu
{
    public partial class NuevoMenu
    {
        [Inject] private IMenuServicio productoServicio { get; set; }

        private Menu prod = new Menu();
        [Inject] private SweetAlertService Swal { get; set; }

        [Inject] NavigationManager _navigationManager { get; set; }

        string imgUrl = string.Empty;

       

        protected async Task Guardar(MenuServicio menuServicio)
        {
            if (string.IsNullOrEmpty(prod.CodigoMenu.ToString()) || string.IsNullOrEmpty(prod.Descripcion))
            {
                return;
            }
            
            Menu MenuExistente = new Menu();

            MenuExistente = await menuServicio.GetPorCodigo(prod.CodigoMenu);

            if (MenuExistente != null)
            {
                if (!string.IsNullOrEmpty(MenuExistente.CodigoMenu.ToString()))
                {
                    await Swal.FireAsync("Advertencia", "Ya existe un producto con este código", SweetAlertIcon.Warning);
                    return;
                }
            }

            bool inserto = await MenuServicio.Nuevo(prod);

            if (inserto)
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
            _navigationManager.NavigateTo("/Menus");
        }
    }
}

using ProyectoRestaurante.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;
using Microsoft.AspNetCore.Http;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;

namespace ProyectoRestaurante.Pages.Facturacion

{
    public partial class NuevaFactura
    {
        [Inject] private IFacturaServicio facturaServicio { get; set; }
        [Inject] private IDetalleFacturaServicio detallefacturaServicio { get; set; }
        [Inject] private IMenuServicio menuservicio { get; set; }
        [Inject] private IClienteServicio clienteServicio { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] private IHttpContextAccessor httpContextAccessor { get; set; }

        private Factura factura = new Factura();
        private List<DetalleFactura> listaDetalleFactura = new List<DetalleFactura>();
        private Menu Menu = new Menu();

        private int cantidad { get; set; }
        private string codigomenu { get; set; }

        protected override async Task OnInitializedAsync()
        {
            codigomenu = httpContextAccessor.HttpContext.User.Identity.Name;
        }

        protected async Task AgregarProducto(MouseEventArgs args)
        {
            if (args.Detail != 0)
            {
                if (Menu != null)
                {
                    DetalleFactura detalle = new DetalleFactura();
                    detalle.CodigoMenu = Menu.Descripcion;
                    detalle.CodigoMenu = Menu.CodigoMenu;
                    detalle.Cantidad = Convert.ToInt32(cantidad);
                    detalle.Precio = Menu.Precio;
                    detalle.Total = Menu.Precio * Convert.ToInt32(cantidad);
                    listaDetalleFactura.Add(detalle);

                    Menu.CodigoMenu = Convert.ToString(0);
                    Menu.Descripcion = string.Empty;
                    Menu.Precio = 0;
                    cantidad = 0;
                    codigomenu = "0";

                    factura.SubTotal = factura.SubTotal + detalle.Total;
                    factura.ISV = factura.SubTotal * 0.15M;
                    factura.SubTotal = factura.SubTotal + factura.ISV - factura.Descuento;
                }
            }
        }
        protected async Task Guardad()
        {
            factura.CodigoUsuario = httpContextAccessor.HttpContext.User.Identity.Name;
            int idFactura = await facturaServicio.Nueva(factura);
            if (idFactura != 0)
            {
                foreach (var item in listaDetalleFactura)
                {
                    item.IdFactura = idFactura;
                    await detallefacturaServicio.Nuevo(item);
                }
                await Swal.FireAsync("Factura guardada con exito");
            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo guardar la factura", SweetAlertIcon.Error);
            }
        }
    }
}
    

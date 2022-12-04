using Modelos;

namespace ProyectoRestaurante.Interfaces
{
    public interface IDetalleFacturaServicio
    {
        Task<bool> Nuevo(DetalleFactura detalleFactura);
    }
}

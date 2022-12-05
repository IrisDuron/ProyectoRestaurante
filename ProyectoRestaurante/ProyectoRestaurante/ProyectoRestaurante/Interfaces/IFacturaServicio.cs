using Modelos;

namespace ProyectoRestaurante.Interfaces
{
    public interface IFacturaServicio
    {
        Task<int> Nueva(Factura factura);
    }
}

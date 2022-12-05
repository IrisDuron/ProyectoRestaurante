using Modelos;

namespace ProyectoRestaurante.Interfaces
{
    public interface IClienteServicio
    {
        Task<bool> Nuevo(Cliente Cliente);
        Task<bool> Actualizar(Cliente Cliente);
        Task<bool> Eliminar(string identidadCliente);
        Task<IEnumerable<Cliente>> GetLista();
        Task<Cliente> GetPorCodigo(string identidadCliente);
    }
}

using Modelos;

namespace ProyectoRestaurante.Interfaces
{
    public interface IMenuServicio
    {
        Task<bool> Nuevo(Menu Menu);
        Task<bool> Actualizar(Menu Menu);
        Task<bool> Eliminar(string CodigoMenu);
        Task<IEnumerable<Menu>> GetLista();
        Task<Menu> GetPorCodigo(string CodigoMenu);
        Task<bool> Eliminar(int v);
        Task<Menu> GetPorCodigo(int v);
    }
}

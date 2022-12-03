using Modelos;

namespace ProyectoRestaurante.Interfaces
{
    public interface IMenuServicio
    {
        Task<bool> Nuevo(Menu Menu);
        Task<bool> Actualizar(Menu Menu);
        Task<bool> Eliminar(int CodigoMenu);
        Task<IEnumerable<Menu>> GetLista();
        Task<Menu> GetPorCodigo(int CodigoMenu);
    }
}

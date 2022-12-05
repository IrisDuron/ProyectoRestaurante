using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IMenuRepositorio
    {
        Task<bool> Nuevo(Menu Menu);
        Task<bool> Actualizar(Menu Menu);
        Task<bool> Eliminar(string CodigoMenu);
        Task<IEnumerable<Menu>> GetLista();
        Task<Menu> GetPorCodigo(string CodigoMenu);
    }
}

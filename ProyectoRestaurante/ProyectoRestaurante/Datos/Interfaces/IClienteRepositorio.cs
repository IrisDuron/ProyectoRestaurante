using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IClienteRepositorio
    {
        Task<bool> Nuevo(Cliente Cliente);
        Task<bool> Actualizar(Cliente Cliente);
        Task<bool> Eliminar(string identidadCliente);
        Task<IEnumerable<Cliente>> GetLista();
        Task<Cliente> GetPorCodigo(string identidadCliente);
    }
}


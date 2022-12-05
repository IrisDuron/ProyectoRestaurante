using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;
using ProyectoRestaurante.Interfaces;

namespace ProyectoRestaurante.Servicios
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly Config _configuracion;
        private IClienteRepositorio ClienteRepositorio;

        public ClienteServicio(Config config)
        {
            _configuracion = config;
            ClienteRepositorio = new ClienteRepositorio(config.CadenaConexion);

        }
        public async Task<bool> Actualizar(Cliente Cliente)
        {
            return await ClienteRepositorio.Actualizar(Cliente);
        }

        public async Task<bool> Eliminar(string identidadCliente)
        {
            return await ClienteRepositorio.Eliminar(identidadCliente);
        }

        public async Task<IEnumerable<Cliente>> GetLista()
        {
            return await ClienteRepositorio.GetLista();
        }

        public async Task<Cliente> GetPorCodigo(string identidadCliente)
        {
            return await ClienteRepositorio.GetPorCodigo(identidadCliente);
        }

        public async Task<bool> Nuevo(Cliente Cliente)
        {
            return await ClienteRepositorio.Nuevo(Cliente);
        }
    }
}
    
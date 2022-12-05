using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;
using ProyectoRestaurante.Interfaces;

namespace ProyectoRestaurante.Servicios
{
    public class MenuServicio : IMenuServicio
    {
        private readonly Config _configuracion;
        private IMenuRepositorio MenuRepositorio;

        public MenuServicio(Config config)
        {
            _configuracion = config;
            MenuRepositorio = new MenuRepositorio(config.CadenaConexion);

        }

        public async Task<bool> Actualizar(Menu Menu)
        {
            return await MenuRepositorio.Actualizar(Menu);  
        }

        public async Task<bool> Eliminar(string CodigoMenu)
        {
            return await MenuRepositorio.Eliminar(CodigoMenu);
        }

        public Task<bool> Eliminar(int v)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Menu>> GetLista()
        {
            return await MenuRepositorio.GetLista();
        }

        public async Task<Menu> GetPorCodigo(string CodigoMenu)
        {
            return await MenuRepositorio.GetPorCodigo(CodigoMenu);
        }

        public Task<Menu> GetPorCodigo(int v)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Nuevo(Menu Menu)
        {
            return await MenuRepositorio.Nuevo(Menu);
        }
    }
}

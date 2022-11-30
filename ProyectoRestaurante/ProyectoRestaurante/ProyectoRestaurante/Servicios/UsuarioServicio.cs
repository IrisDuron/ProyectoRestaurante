using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;
using ProyectoRestaurante.Interfaces;

namespace ProyectoRestaurante.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly Config _configuracion;
        private IUsuarioRepositorio usuarioRepositorio;

        public UsuarioServicio(Config config)
        {
            _configuracion = config;
            usuarioRepositorio = new UsuarioRepositorio(config.CadenaConexion);

        }

        public async Task<bool> Actualizar(Usuario usuario)
        {
            return await usuarioRepositorio.Actualizar(usuario);
        }

        public async Task<bool> Eliminar(string codigoUsuario)
        {
            return await usuarioRepositorio.Eliminar(codigoUsuario);
        }

        public async Task<IEnumerable<Usuario>> GetLista()
        {
            return await usuarioRepositorio.GetLista();
        }

        public async Task<Usuario> GetPorCodigo(string codigoUsuario)
        {
            return await usuarioRepositorio.GetPorCodigo(codigoUsuario);
        }

        public async Task<bool> Nuevo(Usuario usuario)
        {
            return await usuarioRepositorio.Nuevo(usuario);
        }
    }
}

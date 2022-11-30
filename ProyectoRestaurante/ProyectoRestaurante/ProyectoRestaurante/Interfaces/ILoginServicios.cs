using Modelos;

namespace ProyectoRestaurante.Interfaces
{
    public interface ILoginServicios
    {
        Task<bool> ValidarUsuario(Login login);
    }
}

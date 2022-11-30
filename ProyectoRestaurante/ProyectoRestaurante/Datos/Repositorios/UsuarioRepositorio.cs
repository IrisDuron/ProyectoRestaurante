using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private string CadenaConexion;

        public UsuarioRepositorio(string _cadenaConexion)
        {
            CadenaConexion = _cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }

        public async Task<bool> Actualizar(Usuario usuario)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();

                string sql = "UP DATE usuario SET Nombre=@Nombre, Rol=@Rol, Clave=@Clave, EstaActivo=@EstaActivo WHERE CodigoUsuario=@CodigoUsuario;";
                resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, usuario));
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }

        public async Task<bool> Eliminar(string codigoUsuario)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();

                string sql = "DELETE FROM usuario WHERE CodigoUsuario=@CodigoUsuario;";
                resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, new { codigoUsuario }));
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }

        public async Task<IEnumerable<Usuario>> GetLista()
        {
            IEnumerable<Usuario> lista = new List<Usuario>();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();

                string sql = "SELECT * FROM usuario;";
                lista = await conexion.QueryAsync<Usuario>(sql);
            }
            catch (Exception ex)
            {
            }
            return lista;
        }

        public async Task<Usuario> GetPorCodigo(string codigoUsuario)
        {
            Usuario user = new Usuario();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();

                string sql = "SELECT * FROM usuario WHERE CodigoUsuario =@CodigoUsuario";
                user = await conexion.QueryFirstAsync<Usuario>(sql, new { codigoUsuario });
            }
            catch (Exception ex)
            {
            }
            return user;
        }

        public async Task<bool> Nuevo(Usuario usuario)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();

                string sql = "INSERT INTO usuario (CodigoUsuario, Nombre, Clave, Rol, EstaActivo) VALUES(@CodigoUsuario, @Nombre, @Clave, @Rol, @EstaActivo)";
                resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, usuario));
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }
    }
}

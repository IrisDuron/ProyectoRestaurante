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
    public class MenuRepositorio : IMenuRepositorio
    {
        private string CadenaConexion;

        public MenuRepositorio(string _cadenaConexion)
        {
            CadenaConexion = _cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }




        public async Task<bool> Actualizar(Menu Menu)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();

                string sql = @"UPDATE Menu SET Nombre=@Nombre, Descripcion=@Descripcion, Precio=@Precio, Categoria=@Categoria, Cantidad=@Cantidad WHERE CodigoMenu=@CodigoMenu;";
                resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, Menu));
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }

        public async Task<bool> Eliminar(string CodigoMenu)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();

                string sql = "DELETE FROM Menu WHERE CodigoMenu=@CodigoMenu;";
                resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, new { CodigoMenu }));
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }

        public async Task<IEnumerable<Menu>> GetLista()
        {
            IEnumerable<Menu> lista = new List<Menu>();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();

                string sql = "SELECT * FROM Menu;";
                lista = await conexion.QueryAsync<Menu>(sql);
            }
            catch (Exception ex)
            {
            }
            return lista;
        }

        public async Task<Menu> GetPorCodigo(string CodigoMenu)
        {
            Menu Menu = new Menu();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();

                string sql = "SELECT * FROM Menu WHERE CodigoMenu =@CodigoMenu";
                Menu = await conexion.QueryFirstAsync<Menu>(sql, new { CodigoMenu });
            }
            catch (Exception ex)
            {
            }
            return Menu;
        }

        public async Task<bool> Nuevo(Menu Menu)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();

                string sql = "INSERT INTO Menu (CodigoMenu,  Nombre,  Descripcion,  Precio, Categoria, Cantidad) VALUES(@CodigoMenu, @Nombre, @Descripcion, @Precio, @Categoria, @Cantidad)";
                resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, Menu));
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }

       
    }
}

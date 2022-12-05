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
    public class ClienteRepositorio : IClienteRepositorio
    {

        private string CadenaConexion;

        public ClienteRepositorio(string _cadenaConexion)
        {
            CadenaConexion = _cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }


        public async Task<bool> Actualizar(Cliente Cliente)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();

                string sql = @"UPDATE cliente SET Nombre=@Nombre WHERE identidadCliente=@identidadCliente;";
                resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, Cliente));
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }

        public async  Task<bool> Eliminar(string identidadCliente)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();

                string sql = "DELETE FROM cliente WHERE identidadCliente=@identidadCliente;";
                resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, new { identidadCliente }));
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }

        public async Task<IEnumerable<Cliente>> GetLista()
        {
            IEnumerable<Cliente> lista = new List<Cliente>();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT * FROM Cliente;";
                lista = await conexion.QueryAsync<Cliente>(sql);
            }
            catch (Exception ex)
            {
            }
            return lista;
        }

        public async Task<Cliente> GetPorCodigo(string identidadCliente)
        {
            Cliente Cliente = new Cliente();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT * FROM Cliente WHERE identidadCliente = @identidadCliente;";
                Cliente = await conexion.QueryFirstOrDefaultAsync<Cliente>(sql, new { identidadCliente });
            }
            catch (Exception ex)
            {
            }
            return Cliente;
        }

        public async Task<bool> Nuevo(Cliente Cliente)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"INSERT INTO Cliente (identidadCliente, Nombre) 
                               VALUES (@identidadCliente, @Nombre);";
                resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, Cliente ));
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }
    }
}

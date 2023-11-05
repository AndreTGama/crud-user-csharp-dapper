

using Dapper;
using FiapStore.Entity;
using FiapStore.Interface;
using MySqlConnector;
using System.Data.SqlClient;

namespace FiapStore.Repository
{
    public class UsuarioRepository : DapperRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override void Alterar(Usuario entidade)
        {
            //Na video aula faz a conecçao com SQL Server, eu estou usando MysqlServer então mudei a conecção
            //using var dbConnection = new SqlConnection(ConnectionString);
            using var dbConnection = new MySqlConnection(ConnectionString);
            var query = "UPDATE Usuario SET Nome = @Nome WHERE Id = @Id";
            //Usado mais para consultar e atualizar informações
            dbConnection.Query(query, entidade);
        }

        public override void Cadastrar(Usuario entidade)
        {
            using var dbConnection = new MySqlConnection(ConnectionString);
            var query = "INSERT INTO Usuario (Nome) value(@Nome)";
            // Execute usado mais para cadastrar informações
            dbConnection.Execute(query, entidade);
        }

        public override void Deletar(int id)
        {
            using var dbConnection = new MySqlConnection(ConnectionString);
            var query = "DELETE FROM Usuario WHERE Id = @Id";
            // Execute usado mais para cadastrar informações
            dbConnection.Execute(query, new { Id = id});
        }

        public override Usuario ObterPorId(int id)
        {
            using var dbConnection = new MySqlConnection(ConnectionString);
            var query = "SELECT * FROM Usuario WHERE Id = @Id";
            // Execute usado mais para cadastrar informações
            return dbConnection.Query<Usuario>(query, new { Id = id }).FirstOrDefault();
        }

        public override IList<Usuario> ObterTodos()
        {
            using var dbConnection = new MySqlConnection(ConnectionString);
            var query = "SELECT * FROM Usuario";
            // Execute usado mais para cadastrar informações
            return dbConnection.Query<Usuario>(query).ToList();
        }

        public Usuario ObterComPedidos(int id)
        {
            using var dbConnection = new MySqlConnection(ConnectionString);
            var query = "SELECT Usuario.Id, Usuario.Nome, Pedido.Id, Pedido.NomeProduto " +
                "FROM Usuario " +
                "LEFT JOIN pedido ON pedido.UsuarioId = Usuario.Id " +
                "WHERE Usuario.Id = 2";
            var resultado = new Dictionary<int, Usuario>();
            var parametros = new { Id = id };
            dbConnection.Query<Usuario, Pedido, Usuario>(query, (usuario, pedido) =>
            {
                if(!resultado.TryGetValue(usuario.Id, out var usuarioExistente))
                {
                    usuarioExistente = usuario;
                    usuarioExistente.Pedidos = new List<Pedido>();
                    resultado.Add(usuario.Id, usuarioExistente);
                }

                if(pedido != null)
                {
                    usuarioExistente.Pedidos.Add(pedido);
                }
                return usuarioExistente;
            }, parametros, splitOn:"Id");
            var usuario = resultado.Values.FirstOrDefault();
            return usuario;
        }
    }
}

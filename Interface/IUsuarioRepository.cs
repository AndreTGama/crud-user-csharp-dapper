using FiapStore.Entity;

namespace FiapStore.Interface
{
    // Interfaces cria contratos, esses contratos deverão ser chamados no repository
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario  ObterComPedidos(int Id);

    }
}

using FiapStore.DTO;
using FiapStore.Entity;
using FiapStore.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
    // Decorator ele irá falar para o sistema que a classe é para ser chamada como API
    [ApiController]
    // Decorator Route, para explicar que são rotas,ou seja, ele define o endereço que irei acessar as funcions 
    [Route("Usuario")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRespository;

        public UsuarioController(IUsuarioRepository usuarioRespository)
        {
            _usuarioRespository = usuarioRespository;
        }

        [HttpGet("obter-todos-com-pedidos/{id}")]
        public IActionResult ObtertTodosComPedidos(int id)
        {
            return Ok(_usuarioRespository.ObterComPedidos(id));
        }
        
        [HttpGet("obter-todos-usuarios")]
        // IActionResult é uma interface que trás os retornos de código do HTTP, seja eles 100 ate o 500
        public IActionResult ObterTodosUsuario()
        {
            return Ok(_usuarioRespository.ObterTodos());
        }

        [HttpGet("obter-usuario-por-id/{id}")]
        // IActionResult é uma interface que trás os retornos de código do HTTP, seja eles 100 ate o 500
        public IActionResult ObterUsuarioPorId(int id)
        {
            return Ok(_usuarioRespository.ObterPorId(id));
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(CadastrarUsuarioDTO usuarioDTO)
        {
            _usuarioRespository.Cadastrar(new Usuario(usuarioDTO));
            return Ok("Usuário Criado com sucesso");
        }

        [HttpPut]
        public IActionResult AtualizarUsuario(AlterarUsuarioDTO usuarioDTO)
        {
            _usuarioRespository.Alterar(new Usuario(usuarioDTO));
            return Ok("Usuário atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            _usuarioRespository.Deletar(id);
            return Ok("Usuário deletado com sucesso");
        }

    }
}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;

namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        //* extraindo a dependência
        private readonly IContatoRepositorio _contatoRepositorio;

        //* injeção de dependência
        public ContatoController(IContatoRepositorio contatoRepositoro) 
        {
            _contatoRepositorio = contatoRepositoro;
        }
        public IActionResult Index()
        {
            //* contatos vai armazenar uma lista de ContatoModel
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult ApagarConfirmacao()
        {
            return View();
        }

        //* Criando método POST(para envio de informações)
        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            _contatoRepositorio.Adicionar(contato);
            return RedirectToAction("Index");
        }
    }
}
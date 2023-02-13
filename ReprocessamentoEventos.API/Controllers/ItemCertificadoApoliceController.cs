using Microsoft.AspNetCore.Mvc;
using ReprocessamentoEventos.API.Models;
using ReprocessamentoEventos.Core.Services;
using System.Text.Json;

namespace ReprocessamentoEventos.API.Controllers
{
    [Route("api/itemcertificadoapolice")]
    [ApiController]
    public class ItemCertificadoApoliceController : Controller
    {
        private readonly IReprocessamentoService _reprocessamento;
        private readonly IMontagemListasService _montagemLista;
        private readonly ISeparadorDeIdentificadorEventoService _separadorIdentificador;
        public ItemCertificadoApoliceController(IReprocessamentoService reprocessamento, 
            IMontagemListasService montagemLista, 
            ISeparadorDeIdentificadorEventoService separadorIdentificador)
        {
            _reprocessamento = reprocessamento;
            _montagemLista = montagemLista;
            _separadorIdentificador = separadorIdentificador;
        }
        [HttpGet("json")]
        public IActionResult GetJson([FromQuery]string itemCertificado, [FromQuery]string inscricao)
        {
            var identificadores = _separadorIdentificador.SeparadorEvento(itemCertificado, inscricao);
            var lista = _montagemLista.MontarListaEventoItemCertificadoApolice(identificadores.ItemCertificado, identificadores.Inscricao);

            var listaViewModel = new List<ItemCertificadoApoliceViewModel>();
            foreach (var item in lista)
            {
                listaViewModel.Add((ItemCertificadoApoliceViewModel)_reprocessamento.Reprocessar(item));
            }
            
            return Ok(JsonSerializer.Serialize(listaViewModel, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}

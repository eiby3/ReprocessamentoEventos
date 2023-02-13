using Microsoft.AspNetCore.Mvc;
using ReprocessamentoEventos.API.Models;
using ReprocessamentoEventos.Core.Services;
using System.Text.Json;

namespace ReprocessamentoEventos.API.Controllers
{
    [Route("api/cobrancapaga")]
    [ApiController]
    public class CobrancaPagaController : Controller
    {
        private readonly IReprocessamentoService _reprocessamento;
        private readonly IMontagemListasService _montagemLista;
        private readonly ISeparadorDeIdentificadorEventoService _separadorIdentificador;

        public CobrancaPagaController(IReprocessamentoService reprocessamento, IMontagemListasService montagemLista, ISeparadorDeIdentificadorEventoService separadorIdentificador)
        {
            _reprocessamento = reprocessamento;
            _montagemLista = montagemLista;
            _separadorIdentificador = separadorIdentificador;
        }
        [HttpGet]
        public IActionResult GetJson([FromQuery] string cobranca)
        {
            var identificadores = _separadorIdentificador.SeparadorEvento(cobranca);
            var lista = _montagemLista.MontarListaEventoCobranca(identificadores.Id);

            var listaViewModel = new List<CobrancaPagaViewModel>();
            foreach (var item in lista)
            {
                listaViewModel.Add((CobrancaPagaViewModel)_reprocessamento.Reprocessar(item));
            }
            return Ok(JsonSerializer.Serialize(listaViewModel, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}

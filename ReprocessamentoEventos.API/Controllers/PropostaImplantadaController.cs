using Microsoft.AspNetCore.Mvc;
using ReprocessamentoEventos.API.Models;
using ReprocessamentoEventos.Core.Services;
using System.Text.Json;

namespace ReprocessamentoEventos.API.Controllers
{
    [Route("api/propostaimplantada")]
    [ApiController]
    public class PropostaImplantadaController : Controller
    {
        private readonly IReprocessamentoService _reprocessamento;
        private readonly IMontagemListasService _montagemLista;
        private readonly ISeparadorDeIdentificadorEventoService _separadorIdentificador;

        public PropostaImplantadaController(IReprocessamentoService reprocessamento, 
            IMontagemListasService montagemLista, 
            ISeparadorDeIdentificadorEventoService separadorIdentificador)
        {
            _reprocessamento = reprocessamento;
            _montagemLista = montagemLista;
            _separadorIdentificador = separadorIdentificador;
        }
        [HttpGet("json")]
        public IActionResult GetJson([FromQuery] string proposta)
        {
            var identificadores = _separadorIdentificador.SeparadorEvento(proposta);
            var lista = _montagemLista.MontarListaEventoProposta(identificadores.Id);

            var listaViewModel = new List<PropostaImplantadaViewModel>();
            foreach (var item in lista)
            {
                listaViewModel.Add((PropostaImplantadaViewModel)_reprocessamento.Reprocessar(item));
            }
            return Ok(JsonSerializer.Serialize(listaViewModel, new JsonSerializerOptions { WriteIndented = true }));
        }

    }
}

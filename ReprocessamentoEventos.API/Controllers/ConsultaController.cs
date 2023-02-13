using Microsoft.AspNetCore.Mvc;
using ReprocessamentoEventos.Core.Enums;
using ReprocessamentoEventos.Core.Services;

namespace ReprocessamentoEventos.API.Controllers
{
    [Route("api/consulta")]
    [ApiController]
    public class ConsultaController : Controller
    {
        private readonly IQueriesService _queries;

        public ConsultaController(IQueriesService queries)
        {
            _queries = queries;
        }
        [HttpGet("query")]
        public IActionResult GetQuery([FromQuery] string ids,
            [FromQuery] int tipoEvento,
            [FromQuery] bool count,
            [FromQuery] bool delete)
        {
            if (delete)
                return RedirectToAction(nameof(GetDelete), new
                {
                    ids = ids,
                    tipoEvento = tipoEvento,
                    count = count
                });
            if (count)
                return Ok(_queries.GetQuery(ids, tipoEvento, count));
            else
                return Ok(_queries.GetQuery(ids, tipoEvento));
        }
        [HttpGet("delete")]
        public IActionResult GetDelete([FromQuery] string ids,
            [FromQuery] int tipoEvento)
        {
            return Ok(_queries.GetDelete(ids, tipoEvento));
        }
    }
}

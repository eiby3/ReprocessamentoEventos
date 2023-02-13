using System.Text.Json.Serialization;

namespace ReprocessamentoEventos.API.Models
{
    public class PropostaImplantadaViewModel
    {
        [JsonPropertyName("NUMERO_PROPOSTA")]
        public int NumeroProposta { get; set; }
        [JsonPropertyName("STATUS_ATUAL")]
        public string StatusAtual { get; set; }
    }
}

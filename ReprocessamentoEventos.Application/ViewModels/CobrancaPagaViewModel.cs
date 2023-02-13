using ReprocessamentoEventos.API.Models.Message;
using System.Text.Json.Serialization;

namespace ReprocessamentoEventos.API.Models
{
    public class CobrancaPagaMessage
    {
        [JsonPropertyName("COBRANCAINDIVIDUALID")]
        public int Id { get; set; }

    }
    public class CobrancaPagaViewModel : MessageViewModel<CobrancaPagaMessage>
    {
    }
}
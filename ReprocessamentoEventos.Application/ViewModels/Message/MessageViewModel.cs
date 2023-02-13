using System.Text.Json.Serialization;

namespace ReprocessamentoEventos.API.Models.Message
{
    public class MessageViewModel<T>
        where T : class, new()
    {
        [JsonPropertyName("HEADERS")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public HeadersViewModel Headers { get; set; }
        [JsonPropertyName("DATA")]
        public T Data { get; set; }
    }
}

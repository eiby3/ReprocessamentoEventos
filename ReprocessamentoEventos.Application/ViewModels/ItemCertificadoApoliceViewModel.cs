using ReprocessamentoEventos.API.Models.Message;

namespace ReprocessamentoEventos.API.Models
{
    public class ItemCertificadoApoliceMessage
    {
        public long InscricaoId { get; set; }
        public long ItemCertificadoApoliceId { get; set; }
        public int StatusItemCertificadoApoliceID { get; set; }
    }
    public class ItemCertificadoApoliceViewModel : MessageViewModel<ItemCertificadoApoliceMessage>
    {
    }
}

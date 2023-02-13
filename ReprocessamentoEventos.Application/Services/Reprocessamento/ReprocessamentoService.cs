using ReprocessamentoEventos.API.Models;
using ReprocessamentoEventos.API.Models.Message;
using ReprocessamentoEventos.Core.Services;

namespace ReprocessamentoEventos.Application.Services.Reprocessamento
{
    public class ReprocessamentoService : IReprocessamentoService
    {
        public object Reprocessar(object evento)
        {
            if (evento.GetType().Name.Equals(typeof(ItemCertificadoApoliceDto).Name))
            {
                var inscricao = (ItemCertificadoApoliceDto)evento;
                var message = new ItemCertificadoApoliceViewModel();

                message.Data = new ItemCertificadoApoliceMessage
                {
                    ItemCertificadoApoliceId = inscricao.ItemCertificadoApoliceId,
                    InscricaoId = inscricao.InscricaoId,
                    StatusItemCertificadoApoliceID = inscricao.StatusItemCertificadoApoliceID
                };
                message.Headers = new HeadersViewModel
                {
                    Operation = "UPDATE"
                };
                return message;
            }
            else if (evento.GetType().Name.Equals(typeof(PropostaImplantadaDto).Name))
            {
                var proposta = (PropostaImplantadaDto)evento;
                var message = new PropostaImplantadaViewModel{
                    NumeroProposta = proposta.NumeroProposta,
                    StatusAtual = proposta.StatusAtual
                };
                return message;
            }
            else if (evento.GetType().Name.Equals(typeof(CobrancaPagaDto).Name))
            {
                var cobranca = (CobrancaPagaDto)evento;
                var message = new CobrancaPagaViewModel();

                message.Data = new CobrancaPagaMessage
                {
                    Id = cobranca.Id
                };
                return message;
            }

            return null;
        }
    }
}

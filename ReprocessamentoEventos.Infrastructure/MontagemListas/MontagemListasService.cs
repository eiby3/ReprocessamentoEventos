using ReprocessamentoEventos.API.Models;
using ReprocessamentoEventos.Core.Services;
using System.Collections;

namespace ReprocessamentoEventos.Infrastructure.MontagemListas
{
    public class MontagemListasService : IMontagemListasService
    {
        public IList<CobrancaPagaDto> MontarListaEventoCobranca(List<int> id)
        {
            var lista = new List<CobrancaPagaDto>();
            for (int i = 0; i < id.Count; i++)
            {
                lista.Add(new CobrancaPagaDto
                {
                    Id = id[i]
                });
            }
            return lista;
        }

        public IList<ItemCertificadoApoliceDto> MontarListaEventoItemCertificadoApolice(List<long> itemCertificado, List<long> inscricao)
        {
            var lista = new List<ItemCertificadoApoliceDto>();
            int cancelada = 32;
            for (int i = 0; i < itemCertificado.Count; i++)
            {
                lista.Add(new ItemCertificadoApoliceDto
                {
                    InscricaoId = inscricao[i],
                    ItemCertificadoApoliceId = itemCertificado[i],
                    StatusItemCertificadoApoliceID = cancelada
                });
            }
            return lista;
        }

        public IList<PropostaImplantadaDto> MontarListaEventoProposta(List<int> id)
        {
            var lista = new List<PropostaImplantadaDto>();
            string statusImplantada = "8";
            for (int i = 0; i < id.Count; i++)
            {
                lista.Add(new PropostaImplantadaDto
                {
                    NumeroProposta = id[i],
                    StatusAtual = statusImplantada
                });
            }
            return lista;
        }
    }
}

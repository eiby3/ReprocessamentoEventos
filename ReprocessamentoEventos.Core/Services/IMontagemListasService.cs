using ReprocessamentoEventos.API.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReprocessamentoEventos.Core.Services
{
    public interface IMontagemListasService
    {
        IList<CobrancaPagaDto> MontarListaEventoCobranca(List<int> id);
        IList<PropostaImplantadaDto> MontarListaEventoProposta(List<int> id);
        IList<ItemCertificadoApoliceDto> MontarListaEventoItemCertificadoApolice(List<long> itemCertificado, List<long> inscricao);
    }
}

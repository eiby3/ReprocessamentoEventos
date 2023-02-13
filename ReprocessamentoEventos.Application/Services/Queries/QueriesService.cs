using ReprocessamentoEventos.Core.Enums;
using ReprocessamentoEventos.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReprocessamentoEventos.Application.Services.Queries
{
    public class QueriesService : IQueriesService
    {
        private string ConsultaPropostaImplantada = @"
            SELECT * FROM ControleEvento
            WHERE NomeEvento LIKE 'PropostaImplantada_%'
            AND IdentificadorNegocio IN";
        private string ConsultaPropostaImplantadaCount = @"
            SELECT COUNT(*) FROM ControleEvento
            WHERE NomeEvento LIKE 'PropostaImplantada_%'
            AND IdentificadorNegocio IN";
        private string ConsultaCobrancaPaga = @"
            SELECT * FROM ControleEvento
            WHERE NomeEvento LIKE '%CobrancaIndividual_%_v2_paga%'
            AND IdentificadorNegocio IN";
        private string ConsultaCobrancaPagaCount = @"
            SELECT COUNT(*) FROM ControleEvento
            WHERE NomeEvento LIKE '%CobrancaIndividual_%_v2_paga%'
            AND IdentificadorNegocio IN";
        private string ConsultaInscricaoCancelada = @"
            SELECT * FROM ControleEvento
            WHERE NomeEvento LIKE 'Cancelada'
            AND IdentificadorNegocio IN";
        private string ConsultaInscricaoCanceladaCount = @"
            SELECT COUNT(*) FROM ControleEvento
            WHERE NomeEvento LIKE 'Cancelada'
            AND IdentificadorNegocio IN";

        private string ConsultaPropostaImplantadaDelete = @"
            DELETE FROM ControleEvento
            WHERE NomeEvento LIKE 'PropostaImplantada_%'
            AND IdentificadorNegocio IN";
        private string ConsultaCobrancaPagaDelete = @"
            DELETE FROM ControleEvento
            WHERE NomeEvento LIKE '%CobrancaIndividual_%_v2_paga%'
            AND IdentificadorNegocio IN";
        private string ConsultaInscricaoCanceladaDelete = @"
            DELETE FROM ControleEvento
            WHERE NomeEvento LIKE 'Cancelada'
            AND IdentificadorNegocio IN";

        public string GetQuery(string ids, int numeroEnumTipoEvento)
        {
            var tipoEvento = (EnumTipoEvento)numeroEnumTipoEvento;
            string idsComVirgula = ids.Replace('\n', ',');
            string query = tipoEvento switch
            {
                EnumTipoEvento.PropostaImplantada => ConsultaPropostaImplantada += $"({idsComVirgula})",
                EnumTipoEvento.Cobranca => ConsultaCobrancaPaga += $"({idsComVirgula})",
                EnumTipoEvento.InscricaoCancelada => ConsultaInscricaoCancelada += $"({idsComVirgula})",
                _ => string.Empty,
            };
            return query;
        }
        public string GetQuery(string ids, int numeroEnumTipoEvento, bool count)
        {
            var tipoEvento = (EnumTipoEvento)numeroEnumTipoEvento;
            string idsComVirgula = ids.Replace('\n', ',');
            string query = tipoEvento switch
            {
                EnumTipoEvento.PropostaImplantada => ConsultaPropostaImplantadaCount += $"({idsComVirgula})",
                EnumTipoEvento.Cobranca => ConsultaCobrancaPagaCount += $"({idsComVirgula})",
                EnumTipoEvento.InscricaoCancelada => ConsultaInscricaoCanceladaCount += $"({idsComVirgula})",
                _ => string.Empty,
            };
            return query;
        }
        public string GetDelete(string ids, int numeroEnumTipoEvento)
        {
            var tipoEvento = (EnumTipoEvento)numeroEnumTipoEvento;
            string idsComVirgula = ids.Replace('\n', ',');
            string query = tipoEvento switch
            {
                EnumTipoEvento.PropostaImplantada => ConsultaPropostaImplantadaDelete += $"({idsComVirgula})",
                EnumTipoEvento.Cobranca => ConsultaCobrancaPagaDelete += $"({idsComVirgula})",
                EnumTipoEvento.InscricaoCancelada => ConsultaInscricaoCanceladaDelete += $"({idsComVirgula})",
                _ => string.Empty,
            };
            return query;
        }
    }
}

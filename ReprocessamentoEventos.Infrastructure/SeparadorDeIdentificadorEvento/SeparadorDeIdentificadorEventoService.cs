using ReprocessamentoEventos.Core.DTOs;
using ReprocessamentoEventos.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReprocessamentoEventos.Infrastructure.SeparadorDeIdentificadorEvento
{
    public class SeparadorDeIdentificadorEventoService : ISeparadorDeIdentificadorEventoService
    {
        public IdentificadorItemCertificadoApoliceDto SeparadorEvento(string itemCertificado, string inscricao)
        {
            var identificadorSeparado = new IdentificadorItemCertificadoApoliceDto();
            var itemCertificadoSeparado = itemCertificado.Split();
            var inscricaoSeparado = inscricao.Split();

            identificadorSeparado.ItemCertificado = new List<long>();
            identificadorSeparado.Inscricao = new List<long>();

            for (int i = 0; i < itemCertificadoSeparado.Length; i++)
            {
                identificadorSeparado.ItemCertificado.Add(long.Parse(itemCertificadoSeparado[i]));
                identificadorSeparado.Inscricao.Add(long.Parse(inscricaoSeparado[i]));
            }
            return identificadorSeparado;
        }

        public IdentificadorDto SeparadorEvento(string id)
        {
            var identificadorSeparado = new IdentificadorDto();
            var idSeparado = id.Split();

            identificadorSeparado.Id = new List<int>();

            for (int i = 0; i < idSeparado.Length; i++)
            {
                identificadorSeparado.Id.Add(int.Parse(idSeparado[i]));
            }
            return identificadorSeparado;
        }
    }
}

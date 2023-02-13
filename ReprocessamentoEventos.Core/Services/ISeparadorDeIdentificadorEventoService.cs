using ReprocessamentoEventos.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReprocessamentoEventos.Core.Services
{
    public interface ISeparadorDeIdentificadorEventoService
    {
        IdentificadorItemCertificadoApoliceDto SeparadorEvento(string itemCertificado, string inscricao);
        IdentificadorDto SeparadorEvento(string id);
    }
}

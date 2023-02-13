using ReprocessamentoEventos.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReprocessamentoEventos.Core.Services
{
    public interface IQueriesService
    {
        string GetQuery(string ids, int numeroEnumTipoEvento);
        string GetQuery(string ids, int numeroEnumTipoEvento, bool count);
        string GetDelete(string ids, int numeroEnumTipoEvento);
    }
}

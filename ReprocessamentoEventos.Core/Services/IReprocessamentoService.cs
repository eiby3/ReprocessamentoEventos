using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReprocessamentoEventos.Core.Services
{
    public interface IReprocessamentoService
    {
        object Reprocessar(object evento);
    }
}

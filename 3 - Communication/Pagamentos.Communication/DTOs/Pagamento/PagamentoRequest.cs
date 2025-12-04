using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Communication.DTOs.Pagamento
{
    public class PagamentoRequest
    {
        public string Titulo { get; set; } = string.Empty;

        public double Valor { get; set; }
    }
}

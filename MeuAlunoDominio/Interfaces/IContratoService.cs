using MeuAlunoDominio.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces
{
    public interface IContratoService
    {
        Task<ContratoModelo> CadastrarContratoModelo(int empresaId);
        Task<ContratoModelo> BuscarContratoPorEmpresaId(int empresaId);
        Task<ContratoModelo> BuscarContratoModelo();
    }
}

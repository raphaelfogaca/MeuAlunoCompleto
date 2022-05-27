using MeuAlunoDominio.DTO;
using MeuAlunoDominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Services
{
    public interface IContratoService
    {
        Task<ContratoModelo> CadastrarContratoModelo(int empresaid);
        Task<ContratoModelo> BuscarContratoPorEmpresaId(int empresaId);
        Task<ContratoModelo> BuscarContratoModelo();
        Task<ContratoModelo> AlterarContrato(ContratoModelo contrato);
    }
}

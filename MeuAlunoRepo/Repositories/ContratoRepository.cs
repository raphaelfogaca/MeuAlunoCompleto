using MeuAlunoDominio;
using MeuAlunoDominio.Contrato;
using MeuAlunoDominio.Interfaces;
using MeuAlunoRepo.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Repositories
{
    public class ContratoRepository : MeuAlunoBaseRepository<Contrato>
    {
        private readonly MeuAlunoContext _context;
        public ContratoRepository(MeuAlunoContext context) : base(context)
        {
            _context = context;
        }
        //public async Task<ContratoModelo> CadastrarContratoModelo(ContratoModelo contrato)
        //{           
        //        _context.Add(contrato.Contrato);
        //        await _context.SaveChangesAsync();

        //        var contratoEmpresa = BuscarContratoPorEmpresaId(contrato.Contrato.EmpresaId.GetValueOrDefault());

        //        foreach (var item in contrato.Clausulas)
        //        {
        //            item.ContratoId = contratoEmpresa.Contrato.Id;
        //            _context.Add(item);

        //        }
        //        await _context.SaveChangesAsync();
        //        return contrato;            
        //}

        public async Task<Contrato> BuscarContratoPorEmpresaId(int empresaId)
        {
            var contrato = await _context.Contratos.Where(x => x.EmpresaId == empresaId).ToListAsync();

            return contrato.FirstOrDefault();
        }

        public async Task<Contrato> BuscarContratoModelo()
        {            
            var contrato = await _context.Contratos.Where(x => x.EmpresaId == 1).ToListAsync();           
            
            return contrato.FirstOrDefault();
        }
    }
}

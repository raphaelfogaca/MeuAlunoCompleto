using MeuAlunoDominio.Contrato;
using MeuAlunoDominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Services
{
    public class ContratoService : IContratoService
    {
        private readonly MeuAlunoContext _context;
        public ContratoService(MeuAlunoContext context)
        {            
            _context = context;
        }
        public async Task<ContratoModelo> CadastrarContratoModelo(int empresaId)
        {

            if (empresaId == 0)
                return null;
            else
            {                
                ContratoModelo contrato = new ContratoModelo();
                contrato = BuscarContratoModelo();
                contrato.Contrato.EmpresaId = empresaId;
                _context.Add(contrato.Contrato);
                await _context.SaveChangesAsync();

                var contratoEmpresa = BuscarContratoPorEmpresaId(empresaId) ;

                foreach (var item in contrato.Clausulas)
                {
                    item.ContratoId = contratoEmpresa.Contrato.Id;
                    _context.Add(item);
                    
                }
                await _context.SaveChangesAsync();
                return contrato;
            }
        }

        public ContratoModelo BuscarContratoPorEmpresaId(int id)
        {
            IQueryable<Contrato> contrato = _context.Contratos.Where(x => x.EmpresaId == id);
            if (!contrato.Any())
            {
                return null;
            }
            IQueryable<Clausula> clausulas = _context.Clausulas.Where(x => x.ContratoId == contrato.FirstOrDefault().Id);

            ContratoModelo contratoModelo = new ContratoModelo()
            {
                Contrato = contrato.FirstOrDefault(),
                Clausulas = clausulas
            };
            return contratoModelo;
        }

        public ContratoModelo BuscarContratoModelo()
        {
            IQueryable<Contrato> contrato = _context.Contratos.Where(x => x.EmpresaId == 1)
                .Select(x => new Contrato
                {
                    Id = 0,
                    EmpresaId = 0,
                });
            IQueryable<Clausula> clausulas = _context.Clausulas.Where(x => x.ContratoId == 9)
                .Select(x => new Clausula
                {
                    Id = 0,
                    ContratoId = 0,
                    Descricao = x.Descricao,
                    Nome = x.Nome,
                    Ativa = false
                }); ;

            ContratoModelo contratoModelo = new ContratoModelo()
            {
                Contrato = contrato.FirstOrDefault(),
                Clausulas = clausulas
            };
            return contratoModelo;
        }
    }
}

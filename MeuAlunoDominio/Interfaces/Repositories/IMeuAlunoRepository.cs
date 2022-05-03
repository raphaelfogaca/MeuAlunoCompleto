using MeuAlunoDominio;
using MeuAlunoDominio.DTO;
using MeuAlunoDominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Repositories
{
    public interface IMeuAlunoRepository
    {
        void Add<T>(T Entity) where T : class;
        void Update<T>(T Entity) where T : class;
        void Delete<T>(T Entity) where T : class;
        Task<bool> SaveChangesAsync();    
        List<Servico> BuscarServicoPorEmpresaId(int id);
        Task<Servico[]> BuscarTodosServicos();
        Servico BuscarServicoPorId(int id);
        List<ServicoAula> BuscarServicoAula(int id);

        
       
       
        
        
        
        
    }
}


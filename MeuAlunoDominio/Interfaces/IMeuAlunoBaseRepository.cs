using System;

namespace MeuAlunoDominio.Interfaces
{
    public interface IMeuAlunoBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);

    }
}

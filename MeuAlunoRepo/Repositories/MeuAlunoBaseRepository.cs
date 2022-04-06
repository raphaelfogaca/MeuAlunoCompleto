﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeuAlunoDominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeuAlunoRepo.Repositories
{
    public class MeuAlunoBaseRepository<TEntity> : IMeuAlunoBaseRepository<TEntity> where TEntity : class
    {
        protected readonly MeuAlunoContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public MeuAlunoBaseRepository(MeuAlunoContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }
        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual void Remove(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }
        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
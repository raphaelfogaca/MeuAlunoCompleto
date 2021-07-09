using Microsoft.EntityFrameworkCore;
using MeuAlunoDominio;
using System;
using System.Collections.Generic;

namespace MeuAlunoRepo
{
    public class MeuAlunoContext : DbContext 
    {
       public MeuAlunoContext(DbContextOptions<MeuAlunoContext> options) : base(options) { }
       public DbSet<Aluno> Alunos { get; set; }
       public DbSet<Aula> Aulas { get; set; }
       public DbSet<Empresa> Empresas { get; set; }
       public DbSet<Endereco> Enderecos { get; set; }
       public DbSet<Materia> Materias { get; set; }
       public DbSet<Pessoa> Pessoas { get; set; }
       public DbSet<Servico> Servicos { get; set; }
       public DbSet<Usuario> Usuarios { get; set; }
       public DbSet<MateriaAluno> MateriaAluno { get; set; }
       

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MeuAlunoApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //}


    }
}

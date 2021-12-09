﻿// <auto-generated />
using System;
using MeuAlunoRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MeuAlunoRepo.Migrations
{
    [DbContext(typeof(MeuAlunoContext))]
    partial class MeuAlunoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("MeuAlunoDominio.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CPFResponsavel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("EmailResponsavel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Escola")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeResponsavel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Serie")
                        .HasColumnType("int");

                    b.Property<int>("ServicoId")
                        .HasColumnType("int");

                    b.Property<string>("TelefoneResponsavel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("ServicoId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("MeuAlunoDominio.Aula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Dia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("HoraFim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoraInicio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Vagas")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Aulas");
                });

            modelBuilder.Entity("MeuAlunoDominio.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CNPJ_CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("MeuAlunoDominio.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("MeuAlunoDominio.Financeiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("date");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("FormaPagamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PessoaNome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Financeiros");
                });

            modelBuilder.Entity("MeuAlunoDominio.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("MeuAlunoDominio.MateriaAluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("MateriaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("MateriaId");

                    b.ToTable("MateriaAluno");
                });

            modelBuilder.Entity("MeuAlunoDominio.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("MeuAlunoDominio.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<bool>("Fidelidade")
                        .HasColumnType("bit");

                    b.Property<int>("QtdAulas")
                        .HasColumnType("int");

                    b.Property<int>("TipoMulta")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("ValorMulta")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("MeuAlunoDominio.ServicoAula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AulaId")
                        .HasColumnType("int");

                    b.Property<int>("ServicoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AulaId");

                    b.HasIndex("ServicoId");

                    b.ToTable("ServicoAula");
                });

            modelBuilder.Entity("MeuAlunoDominio.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("MeuAlunoDominio.Aluno", b =>
                {
                    b.HasOne("MeuAlunoDominio.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeuAlunoDominio.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeuAlunoDominio.Servico", "Servico")
                        .WithMany()
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Endereco");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("MeuAlunoDominio.Aula", b =>
                {
                    b.HasOne("MeuAlunoDominio.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("MeuAlunoDominio.Empresa", b =>
                {
                    b.HasOne("MeuAlunoDominio.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("MeuAlunoDominio.Materia", b =>
                {
                    b.HasOne("MeuAlunoDominio.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("MeuAlunoDominio.MateriaAluno", b =>
                {
                    b.HasOne("MeuAlunoDominio.Aluno", "Aluno")
                        .WithMany("MateriaAlunos")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeuAlunoDominio.Materia", "Materia")
                        .WithMany("MateriaAlunos")
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("MeuAlunoDominio.Pessoa", b =>
                {
                    b.HasOne("MeuAlunoDominio.Empresa", "Empresa")
                        .WithMany("Pessoas")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("MeuAlunoDominio.Servico", b =>
                {
                    b.HasOne("MeuAlunoDominio.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("MeuAlunoDominio.ServicoAula", b =>
                {
                    b.HasOne("MeuAlunoDominio.Aula", "Aula")
                        .WithMany()
                        .HasForeignKey("AulaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeuAlunoDominio.Servico", "Servico")
                        .WithMany("ServicosAulas")
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aula");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("MeuAlunoDominio.Usuario", b =>
                {
                    b.HasOne("MeuAlunoDominio.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeuAlunoDominio.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("MeuAlunoDominio.Aluno", b =>
                {
                    b.Navigation("MateriaAlunos");
                });

            modelBuilder.Entity("MeuAlunoDominio.Empresa", b =>
                {
                    b.Navigation("Pessoas");
                });

            modelBuilder.Entity("MeuAlunoDominio.Materia", b =>
                {
                    b.Navigation("MateriaAlunos");
                });

            modelBuilder.Entity("MeuAlunoDominio.Servico", b =>
                {
                    b.Navigation("ServicosAulas");
                });
#pragma warning restore 612, 618
        }
    }
}

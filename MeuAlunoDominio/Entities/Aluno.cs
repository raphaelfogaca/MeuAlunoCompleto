using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MeuAlunoDominio
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        
        [Column(TypeName="date")]
        public DateTime DataNascimento { get; set; }
        public int Serie { get; set; }
        public string NomeResponsavel { get; set; }
        public string CPFResponsavel { get; set; }
        public string EmailResponsavel { get; set; }
        public string TelefoneResponsavel { get; set; }
        public string Escola { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
        public List<MateriaAluno> MateriaAlunos { get; set; }
        public int ServicoId { get; set; }
        public Servico Servico { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }


    }
}

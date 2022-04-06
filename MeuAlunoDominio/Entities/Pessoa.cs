using System;
using System.Collections.Generic;
using System.Text;

namespace MeuAlunoDominio
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

    }
}

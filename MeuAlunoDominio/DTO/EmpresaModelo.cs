using MeuAlunoDominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeuAlunoDominio
{
    public class EmpresaModelo
    {
        public int Id { get; set; }
        public string CNPJ_CPF { get; set; }
        public string RazaoSocial { get; set; }
        public string Telefone { get; set; }
        public int? EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
        public Pessoa? Pessoa { get; set; }

    }
}

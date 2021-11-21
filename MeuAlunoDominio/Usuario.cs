using System;
using System.Collections.Generic;
using System.Text;

namespace MeuAlunoDominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int TipoUsuario { get; set; }
    }
}

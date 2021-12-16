using System;
using System.Collections.Generic;
using System.Text;

namespace MeuAlunoDominio
{
    public class UsuarioTokenModelo
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public int PessoaId { get; set; }
        public string PessoaNome { get; set; }
        public string Email { get; set; }
        public int EmpresaId { get; set; }
        public string EmpresaNome { get; set; }
        public List<Empresa> Empresa { get; set; }
        public int TipoUsuario { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}

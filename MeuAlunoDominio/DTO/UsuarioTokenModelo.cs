using MeuAlunoDominio.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MeuAlunoDominio
{
    public class UsuarioTokenModelo : IdentityUser
    {
        public string Login { get; set; }
        public int PessoaId { get; set; }
        public string PessoaNome { get; set; }
        public int EmpresaId { get; set; }
        public string EmpresaNome { get; set; }
        public List<Empresa> Empresa { get; set; }
        public int TipoUsuario { get; set; }        
        public int ExpirationTime { get; set; }
        public string Emissor { get; set; }
        public string Secret { get; set; }
        public string ValidoEm { get; set; }

    }
}



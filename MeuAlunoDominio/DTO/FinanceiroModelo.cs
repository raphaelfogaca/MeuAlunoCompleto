using System;
using System.Collections.Generic;
using System.Text;

namespace MeuAlunoDominio
{
    public class FinanceiroModelo : Financeiro
    {
        public bool todosAlunos { get; set; }
        public int qtdProvisionar { get; set; }
        public string NomeAluno { get; set; }

    }
}

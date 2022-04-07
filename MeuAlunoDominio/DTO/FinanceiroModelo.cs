using MeuAlunoDominio.Entities;

namespace MeuAlunoDominio
{
    public class FinanceiroModelo : Financeiro
    {
        public bool todosAlunos { get; set; }
        public int qtdProvisionar { get; set; }
        public string NomeAluno { get; set; }

    }
}

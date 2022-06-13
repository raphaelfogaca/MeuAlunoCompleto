using iTextSharp.text;
using iTextSharp.text.pdf;
using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Services
{
    public class ContratoAlunoService : IContratoAlunoService
    {
        private readonly IContratoService _contratoService;
        private readonly IClausulaService _clausulaService;
        private readonly IAlunoService _alunoService;
        private readonly IEmpresaService _empresaService;
        private readonly IServicoService _
        public ContratoAlunoService(IContratoService contratoService,
            IClausulaService clausulaService,
            IEmpresaService empresaService,
            IAlunoService alunoService)
        {
            _contratoService = contratoService;
            _clausulaService = clausulaService;
            _empresaService = empresaService;
            _alunoService = alunoService;
        }
        public async Task<Contrato> GerarContratoPDF(int empresaId, int alunoId)
        {
            if (empresaId > 0)
            {
                var contrato = await _contratoService.BuscarContratoPorEmpresaId(empresaId);
                var empresa = await _empresaService.BuscarEmpresaPorId(empresaId);
                var aluno = await _alunoService.BuscarAlunoPorId(alunoId);

                var pxPorMm = 72 / 25.2F;
                var pdf = new Document(PageSize.A4, 40 * pxPorMm, 15 * pxPorMm,
                    15 * pxPorMm, 20 * pxPorMm);

                var nomeArquivo = $"{empresa.Id}&{aluno.Id}.pdf";
                var arquivo = new FileStream(nomeArquivo, FileMode.Create);
                var writer = PdfWriter.GetInstance(pdf, arquivo);
                pdf.Open();

                var fontebase = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                var fonteParagrafo = new iTextSharp.text.Font(fontebase, 12,
                    iTextSharp.text.Font.BOLD, BaseColor.Black);
                var titulo = new Paragraph("CONTRATO DE PRESTAÇÃO DE SERVIÇOS EDUCACIONAIS\n\n", fonteParagrafo);
                titulo.Alignment = Element.ALIGN_CENTER;
                pdf.Add(titulo);

                var fontePadraoNegrito = new iTextSharp.text.Font(fontebase, 6,
                    iTextSharp.text.Font.BOLD, BaseColor.Black);
                var fontePadraoNormal = new iTextSharp.text.Font(fontebase, 6,
                    iTextSharp.text.Font.NORMAL, BaseColor.Black);

                // cabeçalho
                var contratante = new Paragraph();
                contratante.Add(new Chunk("CONTRATANTE: ", fontePadraoNegrito));
                contratante.Add(new Chunk($"{aluno.NomeResponsavel }, CPF Nº {aluno.CPFResponsavel}, residente e domiciliado no endereço {aluno.Endereco.Logradouro} {aluno.Endereco.Numero} { aluno.Endereco.Complemento}, { aluno.Endereco.Bairro} {aluno.Endereco.Cidade}, {aluno.Endereco.Estado} - CEP {aluno.Endereco.CEP}", fontePadraoNormal));
                contratante.Alignment = Element.ALIGN_JUSTIFIED;
                pdf.Add(contratante);                

                string tipoDocumento = empresa.CNPJ_CPF.Length > 11 ? "CNPJ Nº" : "CPF N";
                var contratado = new Paragraph();
                contratado.Add(new Chunk($"CONTRATADO: ", fontePadraoNegrito));
                contratado.Add(new Chunk($"{empresa.RazaoSocial}, {tipoDocumento} {empresa.CNPJ_CPF}, com sede no endereço {empresa.Endereco.Logradouro} {empresa.Endereco.Numero} {empresa.Endereco.Complemento}, {empresa.Endereco.Bairro} {empresa.Endereco.Cidade}, {empresa.Endereco.Estado} - CEP {empresa.Endereco.CEP}\n\n", fontePadraoNormal));
                pdf.Add(contratado);

                var cabecalhoTexto = new Paragraph("As partes acima identificadas têm, entre si, justo e acertado o presente contrato de prestação de serviços, que se regerá pelas seguintes cláusulas descritas neste instrumento:\n\n", fontePadraoNormal);
                cabecalhoTexto.Alignment = Element.ALIGN_JUSTIFIED;
                pdf.Add(cabecalhoTexto);

                //clausulas
                foreach (var clausula in contrato.Clausulas.Where(x => x.Ativa == true).ToList())
                {
                    var nome = new Paragraph(clausula.Nome, fontePadraoNegrito);
                    nome.Alignment = Element.ALIGN_LEFT;
                    pdf.Add(nome);
                    var descricao = new Paragraph(clausula.Descricao, fontePadraoNormal);
                    descricao.Alignment = Element.ALIGN_JUSTIFIED;
                    pdf.Add(descricao);
                    var linha = new Paragraph("\n");
                    pdf.Add(linha);
                }

                //add imagem
                var caminhoImagem = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    @"img\seulogo.png");
                if (File.Exists(caminhoImagem))
                {
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(caminhoImagem);
                    float razaoAlturaLargura = logo.Width / logo.Height;
                    float alturaLogo = 40;
                    float larguraLogo = alturaLogo * razaoAlturaLargura;
                    logo.ScaleToFit(larguraLogo, alturaLogo);
                    var margemEsquerda = 15 * pxPorMm;
                    var margemTopo = pdf.PageSize.Height - pdf.TopMargin - 54;
                    logo.SetAbsolutePosition(margemEsquerda, margemTopo);
                    writer.DirectContent.AddImage(logo, false);
                }

                pdf.Close();

                return new Contrato();
            }
            return new Contrato();
        }
    }
}

using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MeuAlunoDominio.Interfaces.Services;
using MeuAlunoDominio.Interfaces.Repositories;
using MeuAlunoDominio.Entities;
using System.Collections.Generic;
using MeuAlunoDominio;
using System;

namespace MeuAlunoRepo.Services
{
    public class EmpresaService : IEmpresaService
    {
        IEmpresaRepository _repository;
        IEnderecoService _enderecoService;
        IContratoService _contratoService;
        IPessoaService _pessoaService;

        public EmpresaService(IEmpresaRepository repository, 
            IEnderecoService enderecoService,
            IContratoService contratoService,
            IPessoaService pessoaService)
        {            
            _repository = repository;
            _enderecoService = enderecoService;
            _contratoService = contratoService;
            _pessoaService = pessoaService;
        }
        public async Task<Empresa> BuscarEmpresaPorId(int empresaId)
        {
            var empresa = await _repository.BuscarEmpresaPorId(empresaId);
            empresa.Endereco = await _enderecoService.BuscarPorId(empresa.EnderecoId.GetValueOrDefault());
            empresa.Pessoas = await _pessoaService.BuscarPessoaPorEmpresaId(empresaId);
            return empresa;
        }

        public async Task<List<Empresa>> BuscarTodasEmpresas()
        {
            List<Empresa> empresas = await _repository.BuscarTodasEmpresas();
            return empresas;
        }

        public async Task<Empresa> Inserir(EmpresaModelo model)
        {
            try
            {
                List<Pessoa> pessoas = new List<Pessoa>();
                pessoas.Add(model.Pessoa);
                Empresa empresa = new Empresa();
                empresa.Id = model.Id;
                empresa.CNPJ_CPF = model.CNPJ_CPF;
                empresa.RazaoSocial = model.RazaoSocial;
                empresa.Telefone = model.Telefone;
                empresa.Endereco = model.Endereco;
                empresa.Pessoas = pessoas;

                if (empresa.Id > 0)
                {
                    empresa.Pessoas = null;
                    var retorno = await _repository.Alterar(empresa);
                    return retorno;
                }
                else
                {
                    var retorno = await _repository.Inserir(empresa);
                    if (retorno != null)
                    {
                        await _contratoService.CadastrarContratoModelo(empresa.Id);
                        return retorno;
                    }
                    else
                    {
                        return retorno;
                    }
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Empresa não cadastrada:" + ex);
            }

        }
    }
}

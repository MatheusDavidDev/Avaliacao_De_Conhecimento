using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Projeto.Tests.Commands
{
    public class CadastrarPessoaFisicaCommandTeste
    {
        [Fact]
        public void DeveRetornarSucessoSeDadosForemValidos()
        {
            Guid idEmpresaTeste = Guid.NewGuid();

            var commad = new CadastrarPessoaFisicaCommand();

            commad.Nome = "Matheus David";
            commad.IdEmpresa = idEmpresaTeste;
            commad.RG = "123456789";
            commad.CPF = "12345678910";
            commad.DataNascimento = DateTime.Parse("09-08-2002");


            commad.Validar();

            Assert.True(commad.IsValid, "Os dados foram preenchidos corretamente");
        }
    }
}

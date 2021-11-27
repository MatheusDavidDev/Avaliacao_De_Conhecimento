using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Projeto.Tests.Entities
{
    public class PessoaFisicaTestes
    {
        [Fact]
        public void DeveRetornarSePessoFisicaForValida()
        {
            Guid idEmpresa = Guid.NewGuid();
            
            PessoaFisica PessoaFisicaCadastroTeste = new PessoaFisica(
                "Matheus David",
                idEmpresa,
                DateTime.Now,
                "123456789",
                "12345678910",
                 DateTime.Parse("09-08-2010")

                


            );

            Assert.True(PessoaFisicaCadastroTeste.IsValid, "Usuário valido");
        }

    }
}

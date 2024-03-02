using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoFiltrarLeiloes
    {
        private IWebDriver _driver;

        public AoFiltrarLeiloes(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginInteressadaDeveMostraPainelResultado()
        {
            //Arrange
            var loginPO = new LoginPO(_driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("marcos.poo@gmail.com", "123");
            loginPO.SubmeteFormulario();

            var dashboardInteressadaPO = new DashboardInteressadaPO(_driver);

            //Act
            dashboardInteressadaPO.PesquisarLeiloes(new List<string> { "Arte", "Coleções" });

            //Assert

        }
    }
}

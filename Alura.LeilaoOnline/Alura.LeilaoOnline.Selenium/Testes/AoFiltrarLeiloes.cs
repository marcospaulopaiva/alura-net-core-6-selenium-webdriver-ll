using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
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
            new LoginPO(_driver)
                .EfetuarLoginComCredenciais("marcos.poo@gmail.com", "123");

            var dashboardInteressadaPO = new DashboardInteressadaPO(_driver);

            //Act
            dashboardInteressadaPO.Filtro.PesquisarLeiloes(
                new List<string> { "Arte", "Coleções" },
                "",
                true);

            //Assert
            Assert.Contains("Resultado da pesquisa", _driver.PageSource);

        }
    }
}

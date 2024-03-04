using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoFiltrarLeiloes
    {
        private IWebDriver driver;

        public AoFiltrarLeiloes(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginInteressadaDeveMostraPainelResultado()
        {
            //Arrange
            new LoginPO(driver)
                .EfetuarLoginComCredenciais("marcos.poo@gmail.com", "123");

            var dashboardInteressadaPO = new DashboardInteressadaPO(driver);

            //Act
            dashboardInteressadaPO.Filtro.PesquisarLeiloes(
                new List<string> { "Arte", "Coleções" },
                "",
                true);

            //Assert
            Assert.Contains("Resultado da pesquisa", driver.PageSource);

        }
    }
}

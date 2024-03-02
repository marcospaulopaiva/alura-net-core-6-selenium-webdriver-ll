using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogout
    {
        private IWebDriver _driver;

        public AoEfetuarLogout(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginValidoDeveIrParaHomeNaoLogada()
        {
            //Arrange
            new LoginPO(_driver)
                .Visitar()
                .InformarLogin("marcos.poo@gmail.com")
                .InformarSenha("123")
                .EfetuarLogin();

            var dashboardPO = new DashboardInteressadaPO(_driver);

            //Act - efetuar logout
            dashboardPO.Menu.EfetuarLogout();

            //Assert
            Assert.Contains("Próximos Leilões", _driver.PageSource);
        }
    }
}

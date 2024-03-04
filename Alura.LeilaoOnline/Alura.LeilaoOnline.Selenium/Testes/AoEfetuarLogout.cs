using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogout
    {
        private IWebDriver driver;

        public AoEfetuarLogout(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginValidoDeveIrParaHomeNaoLogada()
        {
            //Arrange
            driver.Manage().Window.Maximize();

            new LoginPO(driver)
                .Visitar()
                .InformarLogin("marcos.poo@gmail.com")
                .InformarSenha("123")
                .EfetuarLogin();

            var dashboardPO = new DashboardInteressadaPO(driver);

            //Act - efetuar logout
            dashboardPO.Menu.EfetuarLogout();

            //Assert
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }
    }
}

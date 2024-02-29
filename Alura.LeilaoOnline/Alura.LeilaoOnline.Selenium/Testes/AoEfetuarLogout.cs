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
            var loginPO = new LoginPO(_driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("marcos.poo@gmail.com", "123");
            loginPO.SubmeteFormulario();

            var dashboardPO = new DashboardInteressadaPO(_driver);

            //Act - efetuar logout
            dashboardPO.EfetuarLogout();

            //Assert
            Assert.Contains("Próximos Leilões", _driver.PageSource);
        }
    }
}

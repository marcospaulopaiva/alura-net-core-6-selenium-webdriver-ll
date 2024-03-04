using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoCriarLeilao
    {
        private IWebDriver driver;

        public AoCriarLeilao(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginAdminEInfoValidasDeveCadastrarLeilao()
        {
            //Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("admin@example.org", "123");
            loginPO.EfetuarLogin();

            var novoLeilaoPO = new NovoLeilaoPO(driver);
            novoLeilaoPO.Visitar();
            novoLeilaoPO.PreencheFormulario(
                "Leilão de Coleção 1",
                "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium",
                "Item de Colecionador",
                4000,
                "C:\\Users\\marco\\OneDrive\\Imagens\\20230327.jpg",
                DateTime.Now.AddDays(20),
                DateTime.Now.AddDays(40)
                );

            //Act
            novoLeilaoPO.SubmeteFormulario();

            //Assert
            Assert.Contains("Leilões cadastrados no sistema", driver.PageSource);
        }
    }
}

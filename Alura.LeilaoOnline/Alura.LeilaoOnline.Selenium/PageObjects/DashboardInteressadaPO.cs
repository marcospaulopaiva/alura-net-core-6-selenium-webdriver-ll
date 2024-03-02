using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        private IWebDriver driver;
        private By byLogoutLink;
        private By byMeuPerfilLink;
        private By bySelectCategorias;
        private By byInputTermo;
        private By byInputAndamento;
        private By byBotaoPesquisar;

        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;
            byLogoutLink = By.Id("logout");
            byMeuPerfilLink = By.Id("meu-perfil");

            bySelectCategorias = By.ClassName("select-wrapper");
            byInputTermo = By.Id("");
            byInputAndamento = By.Id("");
            byBotaoPesquisar = By.Id("");
        }

        public void PesquisarLeiloes(List<string> categorias) 
        {
            //Seleciona e abre o dropdownlist de categorias.
            var selectWrapper = driver.FindElement(bySelectCategorias);
            selectWrapper.Click();

            //Pausa de 2 segundos para ver a execução da ação de seleção.
            Thread.Sleep(2000);

            //Pega a lista de opções.
            var opcoes = selectWrapper.FindElements(By.CssSelector("li>span")).ToList();

            //Desmarcando as opções.
            opcoes.ForEach(o =>
            {
                o.Click();
            });

            //Pausa de 2 segundos para ver a execução da ação de seleção.
            Thread.Sleep(2000);

            //Seleciona as opções baseado na lista passsada. 
            categorias.ForEach(categ =>
            {
                opcoes
                    .Where(o => o.Text.Contains(categ))
                    .ToList()
                    .ForEach(o =>
                    {
                        o.Click();
                    });
            });

            //Tira o foco do dropdownlist com um Tab.
            selectWrapper
                .FindElement(By.TagName("li"))
                .SendKeys(Keys.Tab);

            //Pausa de 2 segundos para ver a execução da ação de seleção.
            Thread.Sleep(2000);

        }

        internal void EfetuarLogout()
        {
            var linkMeuPerfil = driver.FindElement(byMeuPerfilLink);
            var linkLogout = driver.FindElement(byLogoutLink);

            IAction acaoLogout = new Actions(driver)
                //mover para o elemento meu-perfil
                .MoveToElement(linkMeuPerfil)
                //mover para o link de logout
                .MoveToElement(linkLogout)
                //clicar no link de logout
                .Click()
                .Build();

            acaoLogout.Perform();

        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleSelenium.Script
{
    public class PrimeiroScript
    {
        public static void Automatizar_Envio_Texto_ComSucesso()
        {
            using IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

            var titulo = driver.Title;
            if (titulo != "Web form")
            {
                throw new InvalidOperationException($"Título inesperado: {titulo}");
            }

            var campoTexto = driver.FindElement(By.Name("my-text"));
            campoTexto.SendKeys("Daniel, o melhor programador do mundo!");

            var botaoEnviar = driver.FindElement(By.CssSelector("button[type='submit']"));
            botaoEnviar.Click();

            var mensagem = driver.FindElement(By.Id("message"));
            if (mensagem.Text != "Received!")
            {
                throw new InvalidOperationException($"Mensagem inesperada: {mensagem.Text}");
            }
        }
    }
}
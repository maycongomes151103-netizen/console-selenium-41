using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ConsoleSelenium.Tests
{
    [TestClass]
    public class WebFormularioDesafioTest
    {
        private IWebDriver _driver;
        private const string TargetUrl = "https://www.selenium.dev/selenium/web/web-form.html";

        [TestInitialize]
        public void Setup()
        {
            // Configura o WebDriver do Chrome
            var options = new ChromeOptions();
            // options.AddArgument("--headless"); // Descomente se quiser rodar em segundo plano
            _driver = new ChromeDriver(options);
            _driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void TearDown()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }

        [TestMethod]
        public void Exercicio1_CenarioCadastroCompleto()
        {
            // 1. Navegar até a URL
            _driver.Navigate().GoToUrl(TargetUrl);

            // 2. Preencher o campo Text input (my-text) com o nome completo
            var textInput = _driver.FindElement(By.Name("my-text"));
            textInput.SendKeys("Maycon Gomes");

            // 3. Preencher o campo Password (my-password) com uma senha segura
            var passwordInput = _driver.FindElement(By.Name("my-password"));
            passwordInput.SendKeys("SenhaSegura123!");

            // 4. Preencher o campo Textarea (my-textarea) com breve descrição
            var textArea = _driver.FindElement(By.Name("my-textarea"));
            textArea.SendKeys("Experiência sólida com automação de testes utilizando C#, Selenium WebDriver e xUnit/MSTest.");

            // 5. Validar através de asserção que o input de leitura contém exatamente "Readonly input"
            var readonlyInput = _driver.FindElement(By.Name("my-readonly"));
            string readonlyValue = readonlyInput.GetAttribute("value");
            Assert.AreEqual("Readonly input", readonlyValue);

            // 6. Submeter o formulário e validar que a página de sucesso exibe "Received!"
            var submitButton = _driver.FindElement(By.CssSelector("button[type='submit']"));
            submitButton.Click();

            var messageElement = _driver.FindElement(By.Id("message"));
            Assert.AreEqual("Received!", messageElement.Text);
        }

        [TestMethod]
        public void Exercicio2_InteragindoComSeletoresEDropdowns()
        {
            // 1. Navegar até a URL
            _driver.Navigate().GoToUrl(TargetUrl);

            // 2. Utilizar a classe SelectElement para selecionar a opção "Two" no Dropdown (my-select)
            var selectElement = new SelectElement(_driver.FindElement(By.Name("my-select")));
            selectElement.SelectByValue("2");

            // 3. Validar se a opção selecionada de fato possui o valor 2
            Assert.AreEqual("Two", selectElement.SelectedOption.Text);

            // 4. No campo de Dropdown (datalist) (my-datalist), enviar o texto correspondente (ex: "Seattle")
            var dataListInput = _driver.FindElement(By.Name("my-datalist"));
            dataListInput.SendKeys("Seattle");

            // 5. Acionar o envio do formulário e verificar se o fluxo ocorreu sem exceções
            var submitButton = _driver.FindElement(By.CssSelector("button[type='submit']"));
            submitButton.Click();

            var messageElement = _driver.FindElement(By.Id("message"));
            Assert.IsTrue(messageElement.Displayed);
        }

        [TestMethod]
        public void Exercicio3_ManipulacaoDeEstadosCheckboxesRadiosEColors()
        {
            // 1. Navegar até a URL
            _driver.Navigate().GoToUrl(TargetUrl);

            // 2. Validar que o primeiro checkbox (my-check-1) já se encontra marcado (true) por padrão
            var checkbox1 = _driver.FindElement(By.Id("my-check-1"));
            Assert.IsTrue(checkbox1.Selected);

            // 3. Clicar no segundo checkbox (my-check-2) para marcá-lo
            var checkbox2 = _driver.FindElement(By.Id("my-check-2"));
            checkbox2.Click();
            Assert.IsTrue(checkbox2.Selected);

            // 4. Alternar a seleção para o rádio padrão (my-radio-2), garantindo que ele seja selecionado
            var radio2 = _driver.FindElement(By.Id("my-radio-2"));
            radio2.Click();
            Assert.IsTrue(radio2.Selected);

            // 5. Interagir com o Color picker alterando o valor de cor do elemento
            var colorPicker = _driver.FindElement(By.Name("my-colors"));
            colorPicker.SendKeys("#ff0000"); // Define para vermelho

            // 6. Realizar o envio do formulário e validar o sucesso da operação
            var submitButton = _driver.FindElement(By.CssSelector("button[type='submit']"));
            submitButton.Click();

            var messageElement = _driver.FindElement(By.Id("message"));
            Assert.AreEqual("Received!", messageElement.Text);
        }
    }
}
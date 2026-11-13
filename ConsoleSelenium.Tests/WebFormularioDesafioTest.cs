using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ConsoleSelenium.Tests
{
    [TestClass]
    public class WebFormularioDesafioTest
    {
        private IWebDriver? _driver;
        private const string TargetUrl = "https://www.selenium.dev/selenium/web/web-form.html";
        private IWebDriver Driver => _driver ?? throw new InvalidOperationException("Driver não foi inicializado.");

        [TestInitialize]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            _driver = new ChromeDriver(options);
        }

        [TestCleanup]
        public void TearDown()
        {
            var driver = _driver;
            _driver = null;

            if (driver is null)
            {
                return;
            }

            try
            {
                driver.Quit();
            }
            finally
            {
                driver.Dispose();
            }
        }

        private IWebElement WaitForSuccessMessage()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            return wait.Until(driver =>
            {
                var message = driver.FindElement(By.Id("message"));
                return message.Text == "Received!" ? message : null;
            });
        }

        [TestMethod]
        public void Exercicio1_CenarioCadastroCompleto()
        {
            Driver.Navigate().GoToUrl(TargetUrl);

            Driver.FindElement(By.Name("my-text")).SendKeys("Maycon Gomes");
            Driver.FindElement(By.Name("my-password")).SendKeys("SenhaSegura123!");
            Driver.FindElement(By.Name("my-textarea")).SendKeys("Experiência com automação de testes usando C# e Selenium.");

            var readonlyInput = Driver.FindElement(By.Name("my-readonly"));
            Assert.AreEqual("Readonly input", readonlyInput.GetAttribute("value"));

            Driver.FindElement(By.CssSelector("button[type='submit']")).Click();
            var messageElement = WaitForSuccessMessage();
            Assert.AreEqual("Received!", messageElement.Text);
        }

        [TestMethod]
        public void Exercicio2_InteragindoComSeletoresEDropdowns()
        {
            Driver.Navigate().GoToUrl(TargetUrl);

            var selectElement = new SelectElement(Driver.FindElement(By.Name("my-select")));
            selectElement.SelectByValue("2");
            Assert.AreEqual("Two", selectElement.SelectedOption.Text);

            Driver.FindElement(By.Name("my-datalist")).SendKeys("Seattle");

            Driver.FindElement(By.CssSelector("button[type='submit']")).Click();
            var messageElement = WaitForSuccessMessage();
            Assert.AreEqual("Received!", messageElement.Text);
        }

        [TestMethod]
        public void Exercicio3_ManipulacaoDeEstadosCheckboxesRadiosEColors()
        {
            Driver.Navigate().GoToUrl(TargetUrl);

            var checkbox1 = Driver.FindElement(By.Id("my-check-1"));
            Assert.IsTrue(checkbox1.Selected);

            var checkbox2 = Driver.FindElement(By.Id("my-check-2"));
            checkbox2.Click();
            Assert.IsTrue(checkbox2.Selected);

            var radio2 = Driver.FindElement(By.Id("my-radio-2"));
            radio2.Click();
            Assert.IsTrue(radio2.Selected);

            var colorPicker = Driver.FindElement(By.Name("my-colors"));
            colorPicker.SendKeys("#ff0000");

            Driver.FindElement(By.CssSelector("button[type='submit']")).Click();
            var messageElement = WaitForSuccessMessage();
            Assert.AreEqual("Received!", messageElement.Text);
        }
    }
}
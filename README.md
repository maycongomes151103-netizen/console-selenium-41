# ConsoleSelenium41 - Automação de Testes Web

Projeto de automação de testes funcionais desenvolvido como atividade prática para as disciplinas de **Garantia da Qualidade de Software** e **Gestão e Qualidade de Software** (Centro Universitário UNA), ministradas pelo Prof. Daniel Henrique Matos de Paiva.

---

## 📋 Sobre o Projeto

O objetivo desta solução é automatizar o preenchimento e a validação de elementos complexos de um formulário web real utilizando **C#**, **.NET 10**, **MSTest** e **Selenium WebDriver**.

- **URL Alvo:** [Selenium Web Form](https://www.selenium.dev/selenium/web/web-form.html)
- **Estrutura da Solution:**
  - `ConsoleSelenium`: Projeto principal (Console Application em .NET 10).
  - `ConsoleSelenium.Tests`: Projeto de testes automatizados (MSTest) contendo a suíte `WebFormularioDesafioTest.cs`.

---

## 🛠️ Tecnologias Utilizadas

- **Linguagem:** C# (.NET 10)
- **Framework de Testes:** MSTest
- **Automação Web:** Selenium.WebDriver & Selenium.Support
- **Navegador:** Google Chrome (ChromeDriver)

---

## 🧪 Cenários de Teste Implementados (`WebFormularioDesafioTest.cs`)

1. **`Exercicio1_CenarioCadastroCompleto` (Preenchimento Misto)**
   - Preenche campos de texto (`my-text`), senha (`my-password`) e área de texto (`my-textarea`).
   - Valida via asserção (`Assert.AreEqual`) que o campo somente leitura (`my-readonly`) mantém o valor padrão `"Readonly input"`.
   - Submete o formulário e verifica a mensagem de confirmação `"Received!"`.

2. **`Exercicio2_InteragindoComSeletoresEDropdowns` (Dropdowns e Datalist)**
   - Manipula o elemento `<select>` (`my-select`) utilizando a classe `SelectElement` para escolher a opção `"Two"` (valor `2`).
   - Valida a opção selecionada e preenche o campo de autocompletar (`my-datalist`) com `"Seattle"`.
   - Envia o formulário e confirma a exibição da tela de resposta sem exceções.

3. **`Exercicio3_ManipulacaoDeEstadosCheckboxesRadiosEColors` (Estados e Seletores Visuais)**
   - Verifica se o primeiro checkbox (`my-check-1`) inicia marcado por padrão.
   - Marca o segundo checkbox (`my-check-2`) e alterna a seleção para o segundo radio button (`my-radio-2`).
   - Altera a cor no seletor visual (`my-colors`) e valida o envio bem-sucedido do formulário.

---

## 🚀 Como Executar os Testes

### Pré-requisitos
- [.NET 10 SDK](https://dotnet.microsoft.com/download) instalado.
- Navegador **Google Chrome** atualizado.

### Passo a passo
1. Clone este repositório:
   ```bash
   git clone [https://github.com/maycongomes151103-netizen/console-selenium-41.git](https://github.com/maycongomes151103-netizen/console-selenium-41.git)

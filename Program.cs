using System;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace BotWhatsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://web.whatsapp.com/";
            string menssagem = "Teste 1";

            List<string> contatos = new List<string>()
            {
                "Area de transferência"
            };

            ChromeDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();

            Thread.Sleep(8000);

            foreach (var contato in contatos)
            {
                var pesquisaEl = driver.FindElementByClassName("selectable-text");
                pesquisaEl.SendKeys(contato);

                Thread.Sleep(2000);

                var contatoEl = driver.FindElementByXPath($"//span[@title='{contato}']");
                contatoEl.Click();

                var chatEl = driver.FindElementByClassName("DuUXI");
                chatEl.SendKeys(menssagem);

                Thread.Sleep(3000);

                var buttonSendEl = driver.FindElementByXPath("//span[@data-icon='send']");
                buttonSendEl.Click();
            }
        }
    }
}

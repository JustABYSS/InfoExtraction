using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace InfoExtractionApp
{
    class InfoExtraction
    {
        private static IWebDriver Driver;
        private static WebDriverWait wait;

        static void Main()
        {

            EnterGoogle();
            var Peppa = SearchAndEnter();
            Peppa.Click();
            IWebElement firstPara = Driver.FindElement(By.CssSelector(".mw-parser-output > p:nth-child(6)"));
            IWebElement Image = Driver.FindElement(By.CssSelector(".infobox > tbody:nth-child(1) > tr:nth-child(2) > td:nth-child(1) > a:nth-child(1) > img:nth-child(1)"));
            Console.WriteLine(firstPara.Text);
            Console.WriteLine(Image.GetAttribute("src"));
            
        }

        private static void EnterGoogle()
        {
            Driver = new FirefoxDriver();
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(17));
            Driver.Navigate().GoToUrl("http://www.google.com");
        }

        private static IWebElement SearchAndEnter()
        {
            var fokof = "div.g:nth-child(10) > div:nth-child(2) > div:nth-child(1) > a:nth-child(1) > h3:nth-child(2) > span:nth-child(1)";
            Driver.FindElement(By.Name("q")).SendKeys("Spider-Man" + Keys.Enter);
            wait.Until(Driver => Driver.FindElement(By.CssSelector(fokof)).Displayed);
            IWebElement firstResult = Driver.FindElement(By.CssSelector(fokof));
            return firstResult;
        }
    }
}

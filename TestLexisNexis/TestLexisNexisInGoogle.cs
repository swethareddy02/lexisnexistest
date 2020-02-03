using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

/*1.       Open Google search engine
2.       Search from “LexisNexis”
3.       Open the third link in the search result  
4.       Return the page title
5.       Upload your solution to a GIT repository and send the link back to us.
*/

namespace TestLexisNexis
{
    [TestClass]
    public class TestLexisNexisInGoogle
    {
        IWebDriver driver;

        [TestInitialize]
        public void TestInit()
        {
            var siteUrl = "https:\\www.google.com";

            //create chrome driver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(siteUrl);            
        }

        [TestMethod]
        public void GetThirdLinkTitleForLexisNexisInGoogle()
        {
            
            var searchString = "LexisNexis";

            driver.FindElement(By.Name("q")).SendKeys(searchString);

            //wait for the autocomplete list
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.XPath("//ul[@class='erkvQe']/li[1]//span[text()='lexisnexis']")));

            driver.FindElement(By.XPath("//ul[@class='erkvQe']/li[1]//span[text()='lexisnexis']")).Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.XPath("//a/h3")));

            var link = driver.FindElements(By.XPath("//a/h3"));

            link[2].Click(); //clicking third link as per the test
                        
            Console.WriteLine(driver.Title);
            
        }

        [TestCleanup]
        public void TestClean()
        {
            driver.Close();
            driver.Quit();
        }
    }
}

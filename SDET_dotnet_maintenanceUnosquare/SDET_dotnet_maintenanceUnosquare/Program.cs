using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnoSquare_Maintenance
{
    class Program
    {
        IWebDriver driver;
        public IWebDriver SetUpDriver()
        {
            
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            return driver;
        }

        public void Click(IWebElement element)
        {
            element.Click();
        }

        public void SendText(IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        #region Google Locators
        By GoogleSearchBar = By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input");  
        By GoogleSearIcon = By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[2]/div[2]/ul/li[1]/div/div[2]/div[1]");
        By UnoSquareGoogleResult = By.PartialLinkText("Transformation");
        #endregion

        #region UnoSquare Locators
        By UnoSquareServicesMenu = By.XPath("/html/body/header/div/nav/div/ul/li[2]/a");
        By PracticeAreas = By.XPath("/html/body/header/div/nav/div/ul/li[3]/a");
        By ContactUs = By.XPath("/html/body/header/div/nav/div/ul/li[9]/a");
        #endregion 
        static void Main(string[] args) 
        {
            IWebDriver Browser;
            IWebElement element;
            Program program = new Program();
            Browser = program.SetUpDriver();
            Browser.Url = "https://www.google.com";

            element = Browser.FindElement(program.GoogleSearchBar);

            program.SendText(element, "Unosquare");

            element = Browser.FindElement(program.GoogleSearIcon);

            program.Click(element);

            element = Browser.FindElement(program.UnoSquareGoogleResult);

            program.Click(element);

            element = Browser.FindElement(program.UnoSquareServicesMenu);

            program.Click(element);

            element = Browser.FindElement(program.PracticeAreas);

            program.Click(element);

            element = Browser.FindElement(program.ContactUs);

            program.Click(element);

        }
        [Test]
        public void ListofTest()
        {
           Assert.IsTrue(driver.FindElement(By.Id("logo")).Displayed); ;
        }
    }
}


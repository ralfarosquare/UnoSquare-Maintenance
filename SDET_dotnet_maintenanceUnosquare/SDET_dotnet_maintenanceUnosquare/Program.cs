using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnoSquare_Maintenance_
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
        By GoogleSearIcon = By.Name("btnK");
        By UnoSquareGoogleResult = By.PartialLinkText("Transformation");
        
        #endregion

        #region UnoSquare Locators
        By UnoSquareServicesMenu = By.XPath("//*[@id='navbarSupportedContent']/ul/li[2]/a");
        By PracticeAreas = By.XPath("//*[@id='navbarSupportedContent']/ul/li[3]/a");
        By ContactUs = By.XPath("//*[@id='navbarSupportedContent']/ul/li[9]/a");
        
        #endregion
        static void Main(string[] args) 
        {
            IWebDriver Browser;
            IWebElement element;
            Program program = new Program();
            Browser = program.SetUpDriver();
            Browser.Url = "https://www.google.com";

            program.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            element = Browser.FindElement(program.GoogleSearchBar);

            program.SendText(element, "Unosquare");
           
            Assert.IsTrue(element.Displayed);
            Console.WriteLine("google search is displayed)");

            element = Browser.FindElement(program.GoogleSearIcon);


            program.Click(element);
           

            element = Browser.FindElement(program.UnoSquareGoogleResult);

            program.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            var driver0 = program.driver.FindElement(By.XPath("//*[@id='rso']/div[1]/div/div/div[1]/div/div/div/div[1]/a/h3"));
            Assert.IsTrue(driver0.Displayed);
            
            program.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            program.Click(element);
            

            
            
            

            var driver1 = program.driver.FindElement(By.XPath("/html/body/header/div/nav/div/ul/li[5]/a"));
            Assert.IsTrue(driver1.Displayed);
            Console.WriteLine("OUR DNA is displayed correctly. It's in the menu bar");

            element = Browser.FindElement(program.UnoSquareServicesMenu);

            program.Click(element);
            var driver2 = program.driver.FindElement(By.XPath("/html/body/header/div/nav/div/ul/li[6]/a"));
            Assert.IsTrue(driver2.Displayed);
            Console.WriteLine("Articles and Events is displayed.");

            element = Browser.FindElement(program.PracticeAreas);

            program.Click(element);

            element = Browser.FindElement(program.ContactUs);

            program.Click(element);

        }
       
              

    }
}

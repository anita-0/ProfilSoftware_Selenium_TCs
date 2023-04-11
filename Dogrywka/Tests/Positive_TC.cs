using Dogrywka.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dogrywka.Tests
{
    [TestClass]
    public class Positive_TC
    {
        WebDriver driver;

        [TestInitialize]
        public void SetupDriver()
        {
            string chromeDriverPath = @"C:\Users\akasz\.nuget\packages\selenium.webdriver.chromedriver\112.0.5615.4900\driver";
            driver = new ChromeDriver(chromeDriverPath);
        }

        [TestCleanup]
        public void QuitDriver()
        {
            driver.Quit();
        }

        [TestMethod]
        public void TestPositive()
        {
            driver.Navigate().GoToUrl("https://dev.profil-software.com/estimate-project/");

            FormPage form = new FormPage(driver);

            //form.ClickCookiesButton(driver);

            form.WriteFirstName(driver, "Anita");
            form.WriteLastName(driver, "Kaszuba");
            form.WriteEmail(driver, "anita-kaszuba@wp.pl");
            form.WritePhone(driver, "784639268");
            form.WriteDescription(driver, "some description");
            form.CheckPolicyCheckbox(driver);
            form.ClickEstimateButton(driver);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement elem = wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[text()='SUCCESS!']")));
            
            Assert.IsTrue(elem.Displayed);
        }
    }
}

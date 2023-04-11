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
    public class Negative_TC_wrong_email
    {
        WebDriver driver;

        [TestInitialize]
        public void SetupDriver()
        {
            driver = new ChromeDriver();
        }

        [TestCleanup]
        public void QuitDriver()
        {
            driver.Quit();
        }

        [TestMethod]
        public void TestNegative()
        {
            driver.Navigate().GoToUrl("https://dev.profil-software.com/estimate-project/");

            FormPage form = new FormPage(driver);

            //form.ClickCookiesButton(driver);

            form.WriteFirstName(driver, "Anita");
            form.WriteLastName(driver, "Kaszuba");
            form.WriteEmail(driver, "anita-kaszuba");
            form.WritePhone(driver, "784639268");
            form.WriteDescription(driver, "some description");
            form.CheckPolicyCheckbox(driver);
            form.ClickEstimateButton(driver);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement elem = wait.Until(ExpectedConditions.ElementExists(By.XPath("//p[text()='* Please, enter valid email']")));

            Assert.IsTrue(elem.Displayed);
        }

    }
}

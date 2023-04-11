using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dogrywka.Pages
{
    public class FormPage
    {
        WebDriver driver;

        public FormPage(WebDriver driver)
        {
            this.driver = driver;
        }

        #region Elements

        private By firstNameTextBox = By.Id("first_name");
        private By lastNameTextBox = By.Id("last_name");
        private By emailTextBox = By.Id("email");
        private By phoneTextBox = By.Id("phone");
        private By describeTextBox = By.Id("describe");
        private By policyCheckBox = By.CssSelector("#policy");
        private By estimateButton = By.CssSelector("#estimation > div.EstimateFormHeader-module--header--cb5a9 > div.EstimateFormHeader-module--buttonsRow--1b5ce > button.EstimateFormHeader-module--estimateButton--c858e");
        private By cookiesButton = By.CssSelector("#gatsby-focus-wrapper > div > div.CookiesPanel-module--cookiesWrapper--c196d > div > button");

        #endregion


        #region Methods

        public void WriteFirstName(WebDriver driver, String text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement textBox = wait.Until(ExpectedConditions.ElementIsVisible(firstNameTextBox));
            textBox.SendKeys(text);
        }

        public void WriteLastName(WebDriver driver, String text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement textBox = wait.Until(ExpectedConditions.ElementIsVisible(lastNameTextBox));
            textBox.SendKeys(text);
        }

        public void WriteEmail(WebDriver driver, String text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement textBox = wait.Until(ExpectedConditions.ElementIsVisible(emailTextBox));
            textBox.SendKeys(text);
        }

        public void WritePhone(WebDriver driver, String text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement textBox = wait.Until(ExpectedConditions.ElementIsVisible(phoneTextBox));
            textBox.SendKeys(text);
        }

        public void WriteDescription(WebDriver driver, String text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement textBox = wait.Until(ExpectedConditions.ElementIsVisible(describeTextBox));
            textBox.SendKeys(text);
        }

        public void CheckPolicyCheckbox(WebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement checkBox = wait.Until(ExpectedConditions.ElementExists(policyCheckBox));
            
            IWebElement element = driver.FindElement(By.XPath("//span[text()='Select all']"));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].click();", element);
        }

        public void ClickEstimateButton(WebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement button = wait.Until(ExpectedConditions.ElementIsVisible(estimateButton));
            button.Click();
        }

        //public void ClickCookiesButton(WebDriver driver)
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        //    IWebElement button = wait.Until(ExpectedConditions.ElementIsVisible(cookiesButton));
        //    button.Click();
        //}

        #endregion
    }
}

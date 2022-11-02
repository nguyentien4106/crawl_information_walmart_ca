using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using CrawlWalmart.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CrawlWalmart
{
    public class Crawler
    {
        private const string PATH = @"C:\";
        private readonly IWebDriver driver;

        private readonly string URL = "https://www.walmart.ca/en";
        public Crawler()
        {
            var options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            options.AddArgument("excludeSwitches");
            options.AddExcludedArgument("enable-logging");
            driver = new ChromeDriver(PATH, options);
        }

        private void Pause(int second)
        {
            Thread.Sleep(second * 1000);
        }
        public void Crawl(Account account, List<JsonInformation> jsonInformations)
        {
            // Go to HomePage
            driver.Navigate().GoToUrl(URL);
            Pause(3);

            // Go to sign in page
            driver.FindElement(By.ClassName("evkjyb00")).Click();
            Pause(3);

            // fill username password
            driver.FindElement(By.Id("username")).SendKeys(account.Username);
            Pause(1);
            driver.FindElement(By.Id("password")).SendKeys(account.Password);
            Pause(3);
            
            // Click Sign in 
            driver.FindElement(By.ClassName("edzik9p0")).Click();
            Pause(3);

            // Go to account setting
            driver.FindElement(By.ClassName("evkjyb00")).Click();
            Pause(3);

            // Go to order history
            driver.FindElement(By.ClassName("e1p2iyht1")).Click();
            Pause(3);

            // Count number item in order history
            var divs = driver.FindElements(By.CssSelector("div[class='e2k4s4l2']"));
            var h2s = driver.FindElements(By.CssSelector("h2[class='css-wx4pkf']"));
            var orderInformations = new List<OrderInformation>();
            for (int i = 0; i < h2s.Count; i++)
            {
                var orderNumber = divs[i].FindElement(By.CssSelector("h3[class='e10u0e3c1']")).Text;
                var status = divs[i].FindElement(By.CssSelector("h4[class='e123cnos2']")).Text;
                var purchaseDate = h2s[i].Text;
                var newOrderInformation = new OrderInformation
                {
                    OrderNumber = orderNumber,
                    Status = status,
                    PurchaseDate = purchaseDate
                };
                orderInformations.Add(newOrderInformation);
            }
            
            Pause(2);
            // Go to Edit Credit Card
            driver.FindElement(By.CssSelector("button[data-automation='edit-card-button']")).Click();
            Pause(3);
            var creditCard = driver.FindElement(By.ClassName("css-wlxdaf")).Text;
            var address = driver
                .FindElement(By.XPath("//*[@id='addCardForm']/section/div[5]/div[2]/div[1]/div/label/text()")).Text;
            // Convert To Model
            var jsonInformation = new JsonInformation
            {
                Account = account,
                Address = address,
                CreditCard = creditCard,
                OrderInformations = orderInformations
            };
            jsonInformations.Add(jsonInformation);
        }
    }
}
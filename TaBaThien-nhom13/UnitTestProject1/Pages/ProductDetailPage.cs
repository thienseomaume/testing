using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestProject1.Pages
{
    public static class ProductDetailPage
    {
        private static By sizeChooser = By.XPath("/html/body/div[2]/main/div/div[2]/div[1]/div[2]/div/div/div[1]/div[2]/div/form/table/tbody/tr/td/div[2]/div[1]");
        private static By addToCart = By.XPath("/html/body/div[2]/main/div/div[2]/div[1]/div[2]/div/div/div[1]/div[2]/div/form/div/div[2]/button");
        private static By checkOut = By.XPath("//div[@id='cart-popup']/div/div[2]/p[2]/a[2]");
        public static void addProduct(IWebDriver driver, WebDriverWait wait)
        {
            driver.Navigate().GoToUrl("https://yoyo1sneaker.com/nike-air-jordan-1-gym-red/");
            driver.FindElement(sizeChooser).Click();
            driver.FindElement(addToCart).Click();
            driver.FindElement(checkOut).Click();
            wait.Until(ExpectedConditions.UrlToBe("https://yoyo1sneaker.com/thanh-toan/"));
            Assert.AreEqual("https://yoyo1sneaker.com/thanh-toan/", driver.Url);
        }
    }
}

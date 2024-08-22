using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestProject1.Pages
{
    public static class CheckoutPage
    {
        public static IWebDriver driver;
        public static WebDriverWait wait;
        public static int timeSleep = 1000;
        private static By backToCart = By.XPath("/html/body/div[1]/main/div[1]/div/div/nav/a[1]");
        private static By inputName = By.Id("billing_last_name");
        private static By inputNumber = By.Id("billing_phone");
        private static By inputEmail = By.Id("billing_email");
        private static By chooseProvince = By.Id("select2-billing_state-container");
        private static By chooseDistrict = By.Id("select2-billing_city-container");
        private static By chooseWard = By.Id("select2-billing_address_2-container");
        private static By fillAddress = By.Id("billing_address_1");
        private static By Hanoi = By.XPath("/html/body/span/span/span[2]/ul/li[1]");
        private static By BaVi = By.XPath("/html/body/span/span/span[2]/ul/li[1]");
        private static By TayDang = By.XPath("/html/body/span/span/span[2]/ul/li[1]");
        private static By PickReceiver = By.Id("ship-to-different-address-checkbox");
        private static By inputReceiverName = By.Id("shipping_last_name");
        private static By inputReveiverNumber = By.Id("shipping_phone");
        private static By chooseReceiverProvince = By.Id("select2-shipping_state-container");
        private static By receiverHanoi = By.XPath("/html/body/span/span/span[2]/ul/li[1]");
        private static By chooseReceiverDistrict = By.Id("select2-shipping_city-container");
        private static By receiverBavi = By.XPath("/html/body/span/span/span[2]/ul/li[1]");
        private static By chooseReceiverWard= By.Id("select2-shipping_address_2-container");
        private static By receiverTayDang = By.XPath("/html/body/span/span/span[2]/ul/li[1]");
        private static By fillReceiverAddress = By.Id("shipping_address_1");
        private static By pickShipCod = By.Id("payment_method_cod");
        private static By orderButton = By.Id("place_order");
        public static By noticeCouponError = By.XPath("/html/body/div[1]/main/div[2]/div/ul");
        public static By noticeError = By.XPath("/html/body/div[1]/main/div[2]/div/form[3]/div[1]/ul");
        public static By activeInputCoupon = By.XPath("/html/body/div[1]/main/div[2]/div/div[3]/div/div/a");
        public static By inputCouponCode = By.Id("coupon_code");
        public static By acceptCoupon = By.Name("apply_coupon");
        public static void InputName(string name)
        {
            driver.FindElement(inputName).Clear();
            driver.FindElement(inputName).SendKeys(name);
        }
        public static void InputNumber(string number)
        {
            driver.FindElement(inputNumber).Clear();
            driver.FindElement(inputNumber).SendKeys(number);
        }
        public static void InputEmail(string email)
        {
            driver.FindElement(inputEmail).Clear();
            driver.FindElement(inputEmail).SendKeys(email);
        }
        public static void ChooseProvince()
        {
            driver.FindElement(chooseProvince).Click();
            Thread.Sleep(timeSleep);
            driver.FindElement(Hanoi).Click();
            Thread.Sleep(timeSleep);
        }
        public static void ChooseDistrict()
        {
            driver.FindElement(chooseDistrict).Click();
            Thread.Sleep(2000);
            driver.FindElement(BaVi).Click();
            Thread.Sleep(timeSleep);
        }
        public static void ChooseWard()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].click();", driver.FindElement(chooseWard));
            driver.FindElement(chooseWard).Click();
            Thread.Sleep(timeSleep);
            driver.FindElement(TayDang).Click();
            Thread.Sleep(timeSleep);
        }
        public static void FillAddress(string address)
        {
            driver.FindElement(fillAddress).SendKeys(address);
        }
        public static void TickReceiver()
        {
            driver.FindElement(PickReceiver).Click();
            Thread.Sleep(timeSleep);
        }
        public static void InputReceiverName(string name)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(inputReceiverName));
            driver.FindElement(inputReceiverName).Clear();
            driver.FindElement(inputReceiverName).SendKeys(name);
            Thread.Sleep(timeSleep);
        }
        public static void ChooseReceiverProvince()
        {
            driver.FindElement(chooseReceiverProvince).Click();
            Thread.Sleep(timeSleep);
            driver.FindElement(receiverHanoi).Click();
            Thread.Sleep(timeSleep);
        }
        public static void ChooseReceiverDistrict()
        {
            driver.FindElement(chooseReceiverDistrict).Click();
            Thread.Sleep(timeSleep);
            driver.FindElement(receiverBavi).Click();
            Thread.Sleep(timeSleep);
        }
        public static void ChooseReceiverWard()
        {
            driver.FindElement(chooseReceiverWard).Click();
            Thread.Sleep(timeSleep);
            driver.FindElement(receiverTayDang).Click();
            Thread.Sleep(timeSleep);
        }
        public static void FillReceiverAddress(string address)
        {
            driver.FindElement(fillReceiverAddress).Clear();
            driver.FindElement(fillReceiverAddress).SendKeys(address);
        }
        public static void PickShipCod()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].click();", driver.FindElement(pickShipCod));
        }
        public static void ClickOrder()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].click();", driver.FindElement(orderButton));
        }
        public static string GetNotiError()
        {
            string text = "";
            wait.Until(ExpectedConditions.ElementIsVisible(noticeError));
            text = driver.FindElement(noticeError).Text;
            return text;
        }
        public static string GetCouponError()
        {
            string text = "";
            wait.Until(ExpectedConditions.ElementIsVisible(noticeCouponError));
            text = driver.FindElement(noticeCouponError).Text;
            return text;
        }
        public static void InputCouponCode(string couponCode)
        {
            driver.FindElement(activeInputCoupon).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(inputCouponCode));
            driver.FindElement(inputCouponCode).SendKeys(couponCode);
            driver.FindElement(acceptCoupon).Click();
        }
        public static void BackToCart()
        {
            driver.FindElement(backToCart).Click();
            wait.Until(ExpectedConditions.UrlToBe("https://yoyo1sneaker.com/gio-hang/"));
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using UnitTestProject1.Data;
using UnitTestProject1.Pages;
using SeleniumExtras.WaitHelpers;

namespace TestProject1
{
    [TestClass]
    public class Test1
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private int timeSleep = 0;
        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver,TimeSpan.FromSeconds(10));
            driver.Manage().Window.Maximize();
            CheckoutPage.driver = driver;
            CheckoutPage.wait = wait;
        }
        public void verifyNotification(string allNoti, string noti)
        {
            Assert.IsTrue(allNoti.Contains(noti));
        }
        [TestMethod]
        public void TC_13_TestInvalidCoupon()
        {
            ProductDetailPage.addProduct(driver,wait);
            CheckoutPage.InputCouponCode(Data.couponCode);
            string allNotiError = CheckoutPage.GetCouponError();
            verifyNotification(allNotiError,Data.notiCouponCode);
            Thread.Sleep(timeSleep);
        }
        [TestMethod]
        public void TC_16_TestBlankAllInfor()
        {
            ProductDetailPage.addProduct(driver, wait);
            Thread.Sleep(2000);
            CheckoutPage.PickShipCod();
            CheckoutPage.TickReceiver();
            CheckoutPage.ClickOrder();
            string allNotiError = CheckoutPage.GetNotiError();
            Assert.IsTrue(allNotiError.Contains(Data.notiName));
            Assert.IsTrue(allNotiError.Contains(Data.notiNumber));
            Assert.IsTrue(allNotiError.Contains(Data.notiEmail));
            Assert.IsTrue(allNotiError.Contains(Data.notiProvince));
            Assert.IsTrue(allNotiError.Contains(Data.notiDistrict));
            Assert.IsTrue(allNotiError.Contains(Data.notiWard));
            Assert.IsTrue(allNotiError.Contains(Data.notiAddress));
            Assert.IsTrue(allNotiError.Contains(Data.notiReceiverName));
            Assert.IsTrue(allNotiError.Contains(Data.notiReceiverProvince));
            Assert.IsTrue(allNotiError.Contains(Data.notiReceiverDistrict));
            Assert.IsTrue(allNotiError.Contains(Data.notiReceiverWard));
            Assert.IsTrue(allNotiError.Contains(Data.notiReceiverAddress));
        }
        [TestMethod]
        public void TC_17_TestInputFullInfor()
        {
            ProductDetailPage.addProduct(driver, wait);
            Thread.Sleep(2000);
            CheckoutPage.InputName(Data.name);
            CheckoutPage.InputNumber(Data.phoneNumber);
            CheckoutPage.InputEmail(Data.email);
            CheckoutPage.ChooseProvince();
            CheckoutPage.ChooseDistrict();
            CheckoutPage.ChooseWard();
            CheckoutPage.FillAddress(Data.address);
            CheckoutPage.TickReceiver();
            CheckoutPage.InputReceiverName(Data.receiverName);
            CheckoutPage.ChooseReceiverProvince(); 
            CheckoutPage.ChooseReceiverDistrict(); 
            CheckoutPage.ChooseReceiverWard();
            CheckoutPage.FillReceiverAddress(Data.receiverAddress);
            CheckoutPage.PickShipCod();
            CheckoutPage.ClickOrder();
            Thread.Sleep(timeSleep);
        }

        [TestMethod]
        public void TC_14_TestInputInvalidEmail()
        {
            ProductDetailPage.addProduct(driver, wait);
            Thread.Sleep(2000);
            CheckoutPage.InputName(Data.name);
            CheckoutPage.InputNumber(Data.phoneNumber);
            CheckoutPage.InputEmail(Data.invalidEmail);
            CheckoutPage.ChooseProvince();
            CheckoutPage.ChooseDistrict();
            CheckoutPage.ChooseWard();
            CheckoutPage.FillAddress(Data.address);
            CheckoutPage.TickReceiver();
            CheckoutPage.InputReceiverName(Data.receiverName);
            CheckoutPage.ChooseReceiverProvince();
            CheckoutPage.ChooseReceiverDistrict();
            CheckoutPage.ChooseReceiverWard();
            CheckoutPage.FillReceiverAddress(Data.receiverAddress);
            CheckoutPage.PickShipCod();
            CheckoutPage.ClickOrder();
            string allNotiError = CheckoutPage.GetNotiError();
            Assert.IsTrue(allNotiError.Contains(Data.notiInvalidEmail));
        }

        [TestMethod]
        public void TC_15_TestInputInvalidPhone()
        {
            ProductDetailPage.addProduct(driver, wait);
            Thread.Sleep(2000);
            CheckoutPage.InputName(Data.name);
            CheckoutPage.InputNumber(Data.invalidPhone);
            CheckoutPage.InputEmail(Data.email);
            CheckoutPage.ChooseProvince();
            CheckoutPage.ChooseDistrict();
            CheckoutPage.ChooseWard();
            CheckoutPage.FillAddress(Data.address);
            CheckoutPage.TickReceiver();
            CheckoutPage.InputReceiverName(Data.receiverName);
            CheckoutPage.ChooseReceiverProvince();
            CheckoutPage.ChooseReceiverDistrict();
            CheckoutPage.ChooseReceiverWard();
            CheckoutPage.FillReceiverAddress(Data.receiverAddress);
            CheckoutPage.PickShipCod();
            CheckoutPage.ClickOrder();
            string allNotiError = CheckoutPage.GetNotiError();
            Assert.IsTrue(allNotiError.Contains(Data.notiInvalidNumber));
        }
        [TestMethod]
        public void TC_01_TestBlankName()
        {
            ProductDetailPage.addProduct(driver, wait);
            Thread.Sleep(2000);
            CheckoutPage.InputNumber(Data.phoneNumber);
            CheckoutPage.InputEmail(Data.email);
            CheckoutPage.ChooseProvince();
            CheckoutPage.ChooseDistrict();
            CheckoutPage.ChooseWard();
            CheckoutPage.FillAddress(Data.address);
            CheckoutPage.TickReceiver();
            CheckoutPage.InputReceiverName(Data.receiverName);
            CheckoutPage.ChooseReceiverProvince();
            CheckoutPage.ChooseReceiverDistrict();
            CheckoutPage.ChooseReceiverWard();
            CheckoutPage.FillReceiverAddress(Data.receiverAddress);
            CheckoutPage.PickShipCod();
            CheckoutPage.ClickOrder();
            string allNotiError = CheckoutPage.GetNotiError();
            Assert.IsTrue(allNotiError.Contains(Data.notiName));
            Thread.Sleep(timeSleep);
        }

        [TestMethod]
        public void TC_02_TestBlankNumber()
        {
            ProductDetailPage.addProduct(driver, wait);
            Thread.Sleep(2000);
            CheckoutPage.InputName(Data.name);
            CheckoutPage.InputEmail(Data.email);
            CheckoutPage.ChooseProvince();
            CheckoutPage.ChooseDistrict();
            CheckoutPage.ChooseWard();
            CheckoutPage.FillAddress(Data.address);
            CheckoutPage.TickReceiver();
            CheckoutPage.InputReceiverName(Data.receiverName);
            CheckoutPage.ChooseReceiverProvince();
            CheckoutPage.ChooseReceiverDistrict();
            CheckoutPage.ChooseReceiverWard();
            CheckoutPage.FillReceiverAddress(Data.receiverAddress);
            CheckoutPage.PickShipCod();
            CheckoutPage.ClickOrder();
            string allNotiError = CheckoutPage.GetNotiError();
            Assert.IsTrue(allNotiError.Contains(Data.notiNumber));
            Thread.Sleep(timeSleep);
        }

        [TestMethod]
        public void TC_03_TestBlankEmail()
        {
            ProductDetailPage.addProduct(driver, wait);
            Thread.Sleep(2000);
            CheckoutPage.InputName(Data.name);
            CheckoutPage.InputNumber(Data.phoneNumber);
            CheckoutPage.ChooseProvince();
            CheckoutPage.ChooseDistrict();
            CheckoutPage.ChooseWard();
            CheckoutPage.FillAddress(Data.address);
            CheckoutPage.TickReceiver();
            CheckoutPage.InputReceiverName(Data.receiverName);
            CheckoutPage.ChooseReceiverProvince();
            CheckoutPage.ChooseReceiverDistrict();
            CheckoutPage.ChooseReceiverWard();
            CheckoutPage.FillReceiverAddress(Data.receiverAddress);
            CheckoutPage.PickShipCod();
            CheckoutPage.ClickOrder();
            string allNotiError = CheckoutPage.GetNotiError();
            Assert.IsTrue(allNotiError.Contains(Data.notiEmail));
            Thread.Sleep(timeSleep);
        }
        [TestMethod]
        public void TC_04_TestBlankProvince()
        {
            ProductDetailPage.addProduct(driver, wait);
            Thread.Sleep(2000);
            CheckoutPage.InputName(Data.name);
            CheckoutPage.InputNumber(Data.phoneNumber);
            CheckoutPage.InputEmail(Data.email);
            CheckoutPage.FillAddress(Data.address);
            CheckoutPage.TickReceiver();
            CheckoutPage.InputReceiverName(Data.receiverName);
            CheckoutPage.ChooseReceiverProvince();
            CheckoutPage.ChooseReceiverDistrict();
            CheckoutPage.ChooseReceiverWard();
            CheckoutPage.FillReceiverAddress(Data.receiverAddress);
            CheckoutPage.PickShipCod();
            CheckoutPage.ClickOrder();
            string allNotiError = CheckoutPage.GetNotiError();
            Assert.IsTrue(allNotiError.Contains(Data.notiProvince));
            Assert.IsTrue(allNotiError.Contains(Data.notiDistrict));
            Assert.IsTrue(allNotiError.Contains(Data.notiWard));
            Thread.Sleep(timeSleep);
        }
        [TestMethod]
        public void TC_05_TestBlankDistrict()
        {
            ProductDetailPage.addProduct(driver, wait);
            Thread.Sleep(2000);
            CheckoutPage.InputName(Data.name);
            CheckoutPage.InputNumber(Data.phoneNumber);
            CheckoutPage.InputEmail(Data.email);
            CheckoutPage.ChooseProvince();
            CheckoutPage.FillAddress(Data.address);
            CheckoutPage.TickReceiver();
            CheckoutPage.InputReceiverName(Data.receiverName);
            CheckoutPage.ChooseReceiverProvince();
            CheckoutPage.ChooseReceiverDistrict();
            CheckoutPage.ChooseReceiverWard();
            CheckoutPage.FillReceiverAddress(Data.receiverAddress);
            CheckoutPage.PickShipCod();
            CheckoutPage.ClickOrder();
            string allNotiError = CheckoutPage.GetNotiError();
            Assert.IsTrue(allNotiError.Contains(Data.notiDistrict));
            Assert.IsTrue(allNotiError.Contains(Data.notiWard));
            Thread.Sleep(timeSleep);
        }
        [TestMethod]
        public void TC_06_TestBlankWard()
        {
            ProductDetailPage.addProduct(driver, wait);
            Thread.Sleep(2000);
            CheckoutPage.InputName(Data.name);
            CheckoutPage.InputNumber(Data.phoneNumber);
            CheckoutPage.InputEmail(Data.email);
            CheckoutPage.ChooseProvince();
            CheckoutPage.ChooseDistrict();
            CheckoutPage.FillAddress(Data.address);
            CheckoutPage.TickReceiver();
            CheckoutPage.InputReceiverName(Data.receiverName);
            CheckoutPage.ChooseReceiverProvince();
            CheckoutPage.ChooseReceiverDistrict();
            CheckoutPage.ChooseReceiverWard();
            CheckoutPage.FillReceiverAddress(Data.receiverAddress);
            CheckoutPage.PickShipCod();
            CheckoutPage.ClickOrder();
            string allNotiError = CheckoutPage.GetNotiError();
            Assert.IsTrue(allNotiError.Contains(Data.notiWard));
            Thread.Sleep(timeSleep);
        }
        [TestMethod]
        public void TC_07_TestBlanKAddress()
        {
            ProductDetailPage.addProduct(driver, wait);
            Thread.Sleep(2000);
            CheckoutPage.InputName(Data.name);
            CheckoutPage.InputNumber(Data.phoneNumber);
            CheckoutPage.InputEmail(Data.email);
            CheckoutPage.ChooseProvince();
            CheckoutPage.ChooseDistrict();
            CheckoutPage.ChooseWard();
            CheckoutPage.TickReceiver();
            CheckoutPage.InputReceiverName(Data.receiverName);
            CheckoutPage.ChooseReceiverProvince();
            CheckoutPage.ChooseReceiverDistrict();
            CheckoutPage.ChooseReceiverWard();
            CheckoutPage.FillReceiverAddress(Data.receiverAddress);
            CheckoutPage.PickShipCod();
            CheckoutPage.ClickOrder();
            string allNotiError = CheckoutPage.GetNotiError();
            Assert.IsTrue(allNotiError.Contains(Data.notiAddress));
            Thread.Sleep(timeSleep);
        }

        [TestMethod]
        public void TC_08_TestBlanKReceiverName()
        {
            ProductDetailPage.addProduct(driver, wait);
            Thread.Sleep(2000);
            CheckoutPage.InputName(Data.name);
            CheckoutPage.InputNumber(Data.phoneNumber);
            CheckoutPage.InputEmail(Data.email);
            CheckoutPage.ChooseProvince();
            CheckoutPage.ChooseDistrict();
            CheckoutPage.ChooseWard();
            CheckoutPage.FillAddress(Data.address);
            CheckoutPage.TickReceiver();
            CheckoutPage.ChooseReceiverProvince();
            CheckoutPage.ChooseReceiverDistrict();
            CheckoutPage.ChooseReceiverWard();
            CheckoutPage.FillReceiverAddress(Data.receiverAddress);
            CheckoutPage.PickShipCod();
            CheckoutPage.ClickOrder();
            string allNotiError = CheckoutPage.GetNotiError();
            Assert.IsTrue(allNotiError.Contains(Data.notiReceiverName));
            Thread.Sleep(timeSleep);
        }
        [TestMethod]
        public void TC_09_TestBlanKReceiverProvince()
        {
            ProductDetailPage.addProduct(driver, wait);
            Thread.Sleep(2000);
            CheckoutPage.InputName(Data.name);
            CheckoutPage.InputNumber(Data.phoneNumber);
            CheckoutPage.InputEmail(Data.email);
            CheckoutPage.ChooseProvince();
            CheckoutPage.ChooseDistrict();
            CheckoutPage.ChooseWard();
            CheckoutPage.FillAddress(Data.address);
            CheckoutPage.TickReceiver();
            CheckoutPage.InputReceiverName(Data.receiverName);
            CheckoutPage.FillReceiverAddress(Data.receiverAddress);
            CheckoutPage.PickShipCod();
            CheckoutPage.ClickOrder();
            string allNotiError = CheckoutPage.GetNotiError();
            Assert.IsTrue(allNotiError.Contains(Data.notiReceiverProvince));
            Assert.IsTrue(allNotiError.Contains(Data.notiReceiverDistrict));
            Assert.IsTrue(allNotiError.Contains(Data.notiReceiverWard));
            Thread.Sleep(timeSleep);
        }
        [TestMethod]
        public void TC_10_TestBlanKReceiverDistrict()
        {
            ProductDetailPage.addProduct(driver, wait);
            Thread.Sleep(2000);
            CheckoutPage.InputName(Data.name);
            CheckoutPage.InputNumber(Data.phoneNumber);
            CheckoutPage.InputEmail(Data.email);
            CheckoutPage.ChooseProvince();
            CheckoutPage.ChooseDistrict();
            CheckoutPage.ChooseWard();
            CheckoutPage.FillAddress(Data.address);
            CheckoutPage.TickReceiver();
            CheckoutPage.InputReceiverName(Data.receiverName);
            CheckoutPage.ChooseReceiverProvince();
            CheckoutPage.FillReceiverAddress(Data.receiverAddress);
            CheckoutPage.PickShipCod();
            CheckoutPage.ClickOrder();
            string allNotiError = CheckoutPage.GetNotiError();
            Assert.IsTrue(allNotiError.Contains(Data.notiReceiverDistrict));
            Assert.IsTrue(allNotiError.Contains(Data.notiReceiverWard));
            Thread.Sleep(timeSleep);
        }
        [TestMethod]
        public void TC_11_TestBlanKReceiverWard()
        {
            ProductDetailPage.addProduct(driver, wait);
            Thread.Sleep(2000);
            CheckoutPage.InputName(Data.name);
            CheckoutPage.InputNumber(Data.phoneNumber);
            CheckoutPage.InputEmail(Data.email);
            CheckoutPage.ChooseProvince();
            CheckoutPage.ChooseDistrict();
            CheckoutPage.ChooseWard();
            CheckoutPage.FillAddress(Data.address);
            CheckoutPage.TickReceiver();
            CheckoutPage.InputReceiverName(Data.receiverName);
            CheckoutPage.ChooseReceiverProvince();
            CheckoutPage.ChooseReceiverDistrict();
            CheckoutPage.FillReceiverAddress(Data.receiverAddress);
            CheckoutPage.PickShipCod();
            CheckoutPage.ClickOrder();
            string allNotiError = CheckoutPage.GetNotiError();
            Assert.IsTrue(allNotiError.Contains(Data.notiReceiverWard));
            Thread.Sleep(timeSleep);
        }
        [TestMethod]
        public void TC_12_TestBlanKReceiverAddress()
        {
            ProductDetailPage.addProduct(driver, wait);
            Thread.Sleep(2000);
            CheckoutPage.InputName(Data.name);
            CheckoutPage.InputNumber(Data.phoneNumber);
            CheckoutPage.InputEmail(Data.email);
            CheckoutPage.ChooseProvince();
            CheckoutPage.ChooseDistrict();
            CheckoutPage.ChooseWard();
            CheckoutPage.FillAddress(Data.address);
            CheckoutPage.TickReceiver();
            CheckoutPage.InputReceiverName(Data.receiverName);
            CheckoutPage.ChooseReceiverProvince();
            CheckoutPage.ChooseReceiverDistrict();
            CheckoutPage.ChooseReceiverWard();
            CheckoutPage.PickShipCod();
            CheckoutPage.ClickOrder();
            string allNotiError = CheckoutPage.GetNotiError();
            Assert.IsTrue(allNotiError.Contains(Data.notiReceiverAddress));
            Thread.Sleep(timeSleep);
        }
        [TestMethod]
        public void TC_18_TestBackToCart()
        {
            ProductDetailPage.addProduct(driver, wait);
            Thread.Sleep(5000);
            CheckoutPage.BackToCart();
            Assert.AreEqual("https://yoyo1sneaker.com/gio-hang/", driver.Url);
            Thread.Sleep(timeSleep);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}

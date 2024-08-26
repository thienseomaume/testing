using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;



class Program
{
    static void Main(string[] args)
    {
        // Khởi tạo ChromeDriver
        IWebDriver driver = new ChromeDriver();

        // URL của trang liên hệ
        string url = "https://yoyo1sneaker.com/lien-he-yoyo1-sneaker/";

        try
        {
            // Thực hiện Test Case ID1
            TestCaseID1(driver, url);

            // Thực hiện Test Case ID2
            TestCaseID2(driver, url);

            // Thực hiện Test Case ID3(driver, url);
        }
        finally
        {
            // Đóng trình duyệt
            driver.Quit();
        }
    }

    static void TestCaseID1(IWebDriver driver, string url)
    {
        driver.Navigate().GoToUrl(url);
        Thread.Sleep(2000);

        // Để trống tất cả các trường và nhấn nút "Gửi"
        IWebElement submitButton = driver.FindElement(By.XPath("//input[@type='submit']"));
        submitButton.Click();
        Thread.Sleep(3000);

        // Kiểm tra kết quả mong đợi
        try
        {
            IWebElement errorMessage = driver.FindElement(By.ClassName("wpcf7-not-valid-tip"));
            if (errorMessage.Text.Contains("The field is required.") || driver.PageSource.Contains("One or more fields have an error"))
            {
                Console.WriteLine("Test Case ID1 passed");
            }
            else
            {
                Console.WriteLine("Test Case ID1 failed");
            }
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Test Case ID1 failed - Error message not found");
        }
    }

    static void TestCaseID2(IWebDriver driver, string url)
    {
        driver.Navigate().GoToUrl(url);
        Thread.Sleep(2000);

        // Sử dụng WebDriverWait để chờ phần tử xuất hiện
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        // Điền tất cả các trường trừ trường "Nội dung"
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("your-name"))).SendKeys("Tên của bạn");
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("your-email"))).SendKeys("email@example.com");
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("your-subject"))).SendKeys("Tiêu đề");

        // Nhấn nút "Gửi"
        IWebElement submitButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//input[@type='submit']")));
        submitButton.Click();
        Thread.Sleep(3000);

        // Kiểm tra kết quả mong đợi
        try
        {
            IWebElement successMessage = driver.FindElement(By.ClassName("wpcf7-response-output"));
            if (successMessage.Text.Contains("Thank you for your message. It has been sent."))
            {
                Console.WriteLine("Test Case ID2 passed");
            }
            else
            {
                Console.WriteLine("Test Case ID2 failed");
            }
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Test Case ID2 failed - Success message not found");
        }
    }

    static void TestCaseID3(IWebDriver driver, string url)
    {
        driver.Navigate().GoToUrl(url);
        Thread.Sleep(2000);

        // Sử dụng WebDriverWait để chờ phần tử xuất hiện
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        // Điền đầy đủ thông tin
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("your-name"))).SendKeys("Tên của bạn");
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("your-email"))).SendKeys("email@example.com");
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("your-subject"))).SendKeys("Tiêu đề");
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("your-message"))).SendKeys("Nội dung của tin nhắn");

        // Nhấn nút "Gửi"
        IWebElement submitButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//input[@type='submit']")));
        submitButton.Click();
        Thread.Sleep(3000);

        // Kiểm tra kết quả mong đợi
        try
        {
            IWebElement successMessage = driver.FindElement(By.ClassName("wpcf7-response-output"));
            if (successMessage.Text.Contains("Thank you for your message. It has been sent."))
            {
                Console.WriteLine("Test Case ID3 passed");
            }
            else
            {
                Console.WriteLine("Test Case ID3 failed");
            }
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Test Case ID3 failed - Success message not found");
        }
    }
}
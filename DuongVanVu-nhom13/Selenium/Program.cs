using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace TheGioiDiDongSearchTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "search_results.txt"; // Đường dẫn file kết quả

            // Khởi tạo trình duyệt Chrome (đảm bảo bạn đã cài đặt ChromeDriver)
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("start-maximized"); // Mở trình duyệt ở chế độ toàn màn hình
            IWebDriver driver = new ChromeDriver(); // Thay thế bằng đường dẫn thực tế

            driver.Url = "https://yoyo1sneaker.com/";
            driver.Navigate();

            // Các từ khóa tìm kiếm
            string[] searchTerms = {"  ", "giày", "giày chạy bộ", "Adidas", "giày bay", "@Nike", "SKU12345", "giày thể thao", 
                "giay the thao", "NIKE", "nike", "giảm giá", "sale", "mới nhất", "size 42", "giày dưới 1 triệu", "giày màu đỏ", "Nike Air Max 90" };

            foreach (string searchTerm in searchTerms)
            {
                // Tìm phần tử ô tìm kiếm và nhập từ khóa
                var searchIcon = driver.FindElement(By.CssSelector(".is-small .icon-search"));
                searchIcon.Click();
                System.Threading.Thread.Sleep(1000);
                var searchBox = driver.FindElement(By.Id("woocommerce-product-search-field-0"));
                searchBox.SendKeys(searchTerm);
                searchBox.SendKeys(Keys.Enter);
                

                // Chờ kết quả tìm kiếm được tải (có thể cần điều chỉnh thời gian chờ)
                System.Threading.Thread.Sleep(7000);

                // Lấy danh sách sản phẩm tìm được
                var productList = driver.FindElements(By.ClassName("woocommerce-loop-product__title"));
                System.Threading.Thread.Sleep(5000);
                // Ghi kết quả vào file text
                using (StreamWriter writer = new StreamWriter(filePath, true)) // Ghi tiếp vào file
                {
                    writer.WriteLine($"--- Kết quả tìm kiếm cho " + searchTerm + ": ---");
                    foreach (var product in productList)
                    {
                        writer.WriteLine(product.Text); // Ghi tên sản phẩm
                    }
                }
                System.Threading.Thread.Sleep(5000);

                driver.Url = "https://yoyo1sneaker.com/";
                driver.Navigate();
                System.Threading.Thread.Sleep(2000);

            }

            
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestAPIWebMVC.Models;

namespace TestAPIWebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult BMI(double height = 0, double weight = 0)
        {
            if(height == 0 && weight == 0)
            {
                ViewData["result"] = "Bạn cần nhập dữ liệu đã";
            }else
            {
                // Các bước cần thực hiện để sử dụng (call) API cơ bản
                // Bước 1: Lấy được requestURL (Bao gồm cả các parametor và giá trị (argument))
                string requestURL = $@"https://localhost:7047/WeatherForecast/get-bmi?weight={weight}&height={height}";
                // Bước 2: Sử dụng HttpClient để lấy được Response
                HttpClient client = new HttpClient();
                string response = client.GetStringAsync(requestURL).Result; // đây chỉ là dữ liệu thô 
                                                                            // Bước 3: Ép kiểu hoặc lấy ra phần dữ liệu cần dùng (nếu cần thiết)
                                                                            // Bước 4: Sử dụng dữ liệu đó
                ViewData["result"] = response;
            }
            return View();
        }
    }
}
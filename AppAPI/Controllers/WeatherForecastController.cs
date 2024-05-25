using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]// đường dẫn chung cho tất cả các phương thức trong controller này
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("get-weather")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("get-string")]
        public string GetString()
        {
            return "ABC";
        }
        // Viết 1 API truyền vào 1 tham số là double weight và double height trả về chỉ số BMI và
        // trạng thái cân nặng BMI = weight/(height*height) đơn vị (kg/m^2)
        [HttpGet]
        [Route("get-bmi")]
        public string GetBMI(double weight, double height)
        {
            double bmi = Math.Round(weight / (height * height), 2);
            if (bmi < 18.5)
            {
                return $"Nặng {weight} và cao {height}, chỉ số BMI là: {bmi}, bạn hơi gầy";
            }
            else if (bmi >= 18.5 && bmi <= 25)
            {
                return $"Nặng {weight} và cao {height}, chỉ số BMI là: {bmi}, bạn cân đối";
            }
            else return $"Nặng {weight} và cao {height}, chỉ số BMI là: {bmi}, bạn hơi mũm mĩm";
        }
    }
}
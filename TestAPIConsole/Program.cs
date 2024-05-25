namespace TestAPIConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; 
            Console.WriteLine("Please enter your height");
            double height = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter your weight");
            double weight = Convert.ToDouble(Console.ReadLine());
            // Các bước cần thực hiện để sử dụng (call) API cơ bản
            // Bước 1: Lấy được requestURL (Bao gồm cả các parametor và giá trị (argument))
            string requestURL = $@"https://localhost:7047/WeatherForecast/get-bmi?weight={weight}&height={height}";
            // Bước 2: Sử dụng HttpClient để lấy được Response
            HttpClient client = new HttpClient();
            string response = client.GetStringAsync(requestURL).Result; // đây chỉ là dữ liệu thô 
            // Bước 3: Ép kiểu hoặc lấy ra phần dữ liệu cần dùng (nếu cần thiết)
            // Bước 4: Sử dụng dữ liệu đó
            Console.WriteLine(response);
            // Lưu ý do API trả về string mà bài này chỉ cần dùng string cho nên có thể bỏ qua bước số 3
        }
    }
}
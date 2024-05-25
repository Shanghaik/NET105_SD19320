namespace TestAPIWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_calculate_Click(object sender, EventArgs e)
        {
            double height = Convert.ToDouble(tbt_height.Text);
            double weight = Convert.ToDouble(tbt_weight.Text);
            // Các bước cần thực hiện để sử dụng (call) API cơ bản
            // Bước 1: Lấy được requestURL (Bao gồm cả các parametor và giá trị (argument))
            string requestURL = $@"https://localhost:7047/WeatherForecast/get-bmi?weight={weight}&height={height}";
            // Bước 2: Sử dụng HttpClient để lấy được Response
            HttpClient client = new HttpClient();
            string response = client.GetStringAsync(requestURL).Result; // đây chỉ là dữ liệu thô 
            // Bước 3: Ép kiểu hoặc lấy ra phần dữ liệu cần dùng (nếu cần thiết)
            // Bước 4: Sử dụng dữ liệu đó
            lb_result.Text = response;
            // Lưu ý do API trả về string mà bài này chỉ cần dùng string cho nên có thể bỏ qua bước số 3
        }
    }
}
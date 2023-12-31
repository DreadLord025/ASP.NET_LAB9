namespace LAB9.Models
{
    public class HomeViewModel
    {
        public WeatherModel Weather { get; set; }
        public IEnumerable<ProductModel> Products { get; set; }
    }
}

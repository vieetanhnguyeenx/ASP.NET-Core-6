namespace MyWebAppApi.Models
{
    public class BaseProduct
    {

        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
    }

    public class Product : BaseProduct
    {
        public Guid Id { get; set; }
    }
}

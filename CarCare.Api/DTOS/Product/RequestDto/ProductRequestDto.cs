namespace CarCare.API.DTOS.Product.RequestDto
{
    public class ProductRequestDto
    {
        public int Id { get; set; } // Include Id for update scenarios
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}

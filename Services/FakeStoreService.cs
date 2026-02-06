using MinForstaApi.Models;  // Importerar vår Product-modell

namespace MinForstaApi.Services
{
    public class FakeStoreService  // Klass som pratar med externa API:et
    {
        private readonly HttpClient _httpClient;  // Verktyg för att göra HTTP-anrop

        public FakeStoreService(HttpClient httpClient)  // Konstruktor - tar emot HttpClient
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProductsAsync()  // Hämtar produkter från internet
        {
            var response = await _httpClient.GetFromJsonAsync<List<FakeStoreProduct>>(
                "https://fakestoreapi.com/products"  // URL till externa API:et
            );

            // Omvandlar FakeStoreProduct till vår Product
            return response?.Select(p => new Product
            {
                Id = p.Id,
                Name = p.Title,      // Deras "title" = vårt "name"
                Price = p.Price
            }).ToList() ?? new List<Product>();
        }
    }

    // Modell som matchar FakeStoreAPI:s format
    public class FakeStoreProduct
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;  // De kallar det "title"
        public decimal Price { get; set; }
    }
}
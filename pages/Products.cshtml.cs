using Microsoft.AspNetCore.Mvc.RazorPages;  // Razor Pages-funktioner
using MinForstaApi.Models;                   // Vår Product-modell
using MinForstaApi.Services;                 // Vår FakeStoreService

namespace MinForstaApi.Pages
{
    public class ProductsModel : PageModel  // Sidans C#-kod
    {
        private readonly FakeStoreService _fakeStoreService;  // Fack för service

        public List<Product> Products { get; set; } = new();  // Lista att visa på sidan

        public ProductsModel(FakeStoreService fakeStoreService)  // Tar emot service
        {
            _fakeStoreService = fakeStoreService;
        }

        public async Task OnGetAsync()  // Körs när sidan laddas
        {
            Products = await _fakeStoreService.GetProductsAsync();  // Hämtar produkter
        }
    }
}
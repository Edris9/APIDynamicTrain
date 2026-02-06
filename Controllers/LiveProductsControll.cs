using Microsoft.AspNetCore.Mvc;           // Ger oss Controller-funktioner
using MinForstaApi.Services;              // Importerar vår FakeStoreService
using MinForstaApi.Models;                // Importerar Product-modellen

namespace MinForstaApi.Controllers
{
    [ApiController]                        // Markerar som API-controller
    [Route("api/live-products")]           // URL: /api/live-products
    public class LiveProductsController : ControllerBase
    {
        private readonly FakeStoreService _fakeStoreService;  // Fack för vår service

        public LiveProductsController(FakeStoreService fakeStoreService)  // Tar emot service
        {
            _fakeStoreService = fakeStoreService;  // Lägger i facket
        }

        [HttpGet]                          // GET-request
        public async Task<ActionResult<List<Product>>> GetAll()  // Hämta alla produkter
        {
            var products = await _fakeStoreService.GetProductsAsync();  // Hämtar från internet
            return Ok(products);           // Returnerar produkterna
        }
    }
}
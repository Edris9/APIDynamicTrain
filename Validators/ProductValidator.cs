using FluentValidation;           // Importerar FluentValidation
using MinForstaApi.Models;        // Importerar vår Product-modell

namespace MinForstaApi.Validators
{
    public class ProductValidator : AbstractValidator<Product>  // Ärver från AbstractValidator
    {
        public ProductValidator()  // Konstruktor där vi definierar regler
        {
            RuleFor(p => p.Name)                          // Regel för Name
                .NotEmpty().WithMessage("Namn krävs")     // Får inte vara tomt
                .Length(2, 50).WithMessage("Namn måste vara 2-50 tecken");  // Längd 2-50

            RuleFor(p => p.Price)                         // Regel för Price
                .GreaterThan(0).WithMessage("Pris måste vara större än 0")  // Större än 0
                .LessThanOrEqualTo(100000).WithMessage("Pris max 100000");  // Max 100000
        }
    }
}
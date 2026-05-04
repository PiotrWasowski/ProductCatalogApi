using FluentValidation;
using ProductCatalogApi.Models;

namespace ProductCatalogApi.Validators
{
    public class ProductValidator: AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Kod)
                .NotEmpty().WithMessage("Kod is required.")
                .MaximumLength(20).WithMessage("Kod cannot exceed 20 characters.");
            RuleFor(p => p.Nazwa)
                .NotEmpty().WithMessage("Nazwa is required.")
                .MaximumLength(100).WithMessage("Nazwa cannot exceed 100 characters.");
            RuleFor(p => p.Cena)
                .GreaterThan(0).WithMessage("Cena must be greater than zero.");
        }
    }
}

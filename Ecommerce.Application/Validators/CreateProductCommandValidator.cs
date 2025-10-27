using FluentValidation;

namespace Ecommerce.Application.Commands.Products
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Product name is required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be positive");
            RuleFor(x => x.Stock).GreaterThanOrEqualTo(0).WithMessage("Stock must be >= 0");
        }
    }
}
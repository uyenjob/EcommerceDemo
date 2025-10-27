using Ecommerce.Application.Commands.Orders;
using FluentValidation;


namespace Ecommerce.Application.Validators
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.CustomerId)
               .NotEmpty()
               .GreaterThan(0)
               .WithMessage("CustomerId must be greater than 0.");

            RuleFor(x => x.Items)
                .NotEmpty()
                .WithMessage("At least one order item is required.");

            RuleForEach(x => x.Items).ChildRules(item =>
            {
                item.RuleFor(i => i.ProductId).NotEmpty();
                item.RuleFor(i => i.Quantity).GreaterThan(0);
                item.RuleFor(i => i.Price).GreaterThan(0);
            });
        }
    }
}

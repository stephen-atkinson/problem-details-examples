using FluentValidation;

namespace MvcProblems;

public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderRequestValidator()
    {
        RuleFor(r => r.Donuts).NotEmpty();
        RuleFor(r => r.Donuts)
            .Must(d => d.Sum(i => i.Quantity) == 6)
            .WithMessage(d => $"Donuts must be ordered in boxes of 6, not {d.Donuts.Sum(i => i.Quantity)}");
        RuleForEach(r => r.Donuts).SetValidator(new DonutValidator());
    }
}

public class DonutValidator : AbstractValidator<CreateOrderRequest.Donut>
{
    public DonutValidator()
    {
        RuleFor(d => d.Quantity).GreaterThan(0);
    }
}
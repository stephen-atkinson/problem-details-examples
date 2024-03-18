namespace MvcProblems;

public class CreateOrderRequest
{
    public IReadOnlyCollection<Donut> Donuts { get; set; }

    public class Donut
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
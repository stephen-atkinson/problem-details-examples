using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcProblems;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IValidator<CreateOrderRequest> _validator;

    public OrdersController(IValidator<CreateOrderRequest> validator)
    {
        _validator = validator;
    }

    [HttpGet("{id:int}")]
    public IActionResult Read(int id)
    {
        // return Forbid();
        // return BadRequest();
        // return Problem();
        // return ValidationProblem()
        return NotFound();
    }

    [HttpPost]
    public IActionResult Create(CreateOrderRequest request)
    {
        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return ValidationProblem(ModelState);
        }

        return Created();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id) => NoContent();
}
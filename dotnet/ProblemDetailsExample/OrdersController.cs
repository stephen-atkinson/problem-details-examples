using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ProblemDetailsExample;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    [HttpGet("{id:int}")]
    public IActionResult Read(int id)
    {
        // return Forbid();
        // return BadRequest();
        // return Problem();
        // return ValidationProblem()
        return NotFound();
    }
}


// [ApiController]
// [Route("[controller]")]
// public class OrdersController : ControllerBase
// {
//     private readonly IValidator<CreateOrderRequest> _validator;
//
//     public OrdersController(IValidator<CreateOrderRequest> validator)
//     {
//         _validator = validator;
//     }
//     
//     [HttpGet("{id:int}")]
//     public IActionResult Read(int id) => NotFound();
//
//     [HttpPost]
//     public IActionResult Create(CreateOrderRequest request)
//     {
//         var validationResult = _validator.Validate(request);
//
//         if (!validationResult.IsValid)
//         {
//             foreach (var error in validationResult.Errors)
//             {
//                 ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
//             }
//
//             return ValidationProblem(ModelState);
//         }
//
//         return Created();
//     }
// }
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController, Route("[controller]")]
public class CalculatorController : ControllerBase
{
    [HttpGet("Add/{left}/{right}")] public int Get(int left, int right) => new Calculator().Sum(left, right);

    [HttpGet("Product/{left}/{right}")]
    public int Product(int left, int right) => new Calculator().Product(left, right);
}
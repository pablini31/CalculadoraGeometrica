using Microsoft.AspNetCore.Mvc;

namespace CalculadoraGeometrica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreasController : ControllerBase
    {
        [HttpPost("cuadrado")]
        public IActionResult CalcularAreaCuadrado([FromBody] double lado)
        {
            if (lado <= 0)
                return BadRequest("El lado debe ser mayor que 0");

            double area = lado * lado;
            return Ok(new { area });
        }

        [HttpPost("rectangulo")]
        public IActionResult CalcularAreaRectangulo([FromBody] RectanguloRequest request)
        {
            if (request.Base <= 0 || request.Altura <= 0)
                return BadRequest("La base y la altura deben ser mayores que 0");

            double area = request.Base * request.Altura;
            return Ok(new { area });
        }

        [HttpPost("triangulo")]
        public IActionResult CalcularAreaTriangulo([FromBody] TrianguloRequest request)
        {
            if (request.Base <= 0 || request.Altura <= 0)
                return BadRequest("La base y la altura deben ser mayores que 0");

            double area = (request.Base * request.Altura) / 2;
            return Ok(new { area });
        }

        [HttpPost("circulo")]
        public IActionResult CalcularAreaCirculo([FromBody] double radio)
        {
            if (radio <= 0)
                return BadRequest("El radio debe ser mayor que 0");

            double area = Math.PI * radio * radio;
            return Ok(new { area });
        }
    }

    public class RectanguloRequest
    {
        public double Base { get; set; }
        public double Altura { get; set; }
    }

    public class TrianguloRequest
    {
        public double Base { get; set; }
        public double Altura { get; set; }
    }
} 
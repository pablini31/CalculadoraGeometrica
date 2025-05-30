using Microsoft.AspNetCore.Mvc;

namespace CalculadoraGeometrica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VolumenesController : ControllerBase
    {
        [HttpPost("cubo")]
        public IActionResult CalcularVolumenCubo([FromBody] double lado)
        {
            if (lado <= 0)
                return BadRequest("El lado debe ser mayor que 0");

            double volumen = lado * lado * lado;
            return Ok(new { volumen });
        }

        [HttpPost("esfera")]
        public IActionResult CalcularVolumenEsfera([FromBody] double radio)
        {
            if (radio <= 0)
                return BadRequest("El radio debe ser mayor que 0");

            double volumen = (4.0 / 3.0) * Math.PI * radio * radio * radio;
            return Ok(new { volumen });
        }

        [HttpPost("cilindro")]
        public IActionResult CalcularVolumenCilindro([FromBody] CilindroRequest request)
        {
            if (request.Radio <= 0 || request.Altura <= 0)
                return BadRequest("El radio y la altura deben ser mayores que 0");

            double volumen = Math.PI * request.Radio * request.Radio * request.Altura;
            return Ok(new { volumen });
        }

        [HttpPost("prisma")]
        public IActionResult CalcularVolumenPrisma([FromBody] PrismaRequest request)
        {
            if (request.AreaBase <= 0 || request.Altura <= 0)
                return BadRequest("El área de la base y la altura deben ser mayores que 0");

            double volumen = request.AreaBase * request.Altura;
            return Ok(new { volumen });
        }
    }

    public class CilindroRequest
    {
        public double Radio { get; set; }
        public double Altura { get; set; }
    }

    public class PrismaRequest
    {
        public double AreaBase { get; set; }
        public double Altura { get; set; }
    }
} 
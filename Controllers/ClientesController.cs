
using mi_primer_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace mi_primer_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly DbEmpresaContext _context;

        public ClientesController(DbEmpresaContext ctx)
        {
            _context = ctx;
        }

        [HttpGet("ListarClientes")]
        public ActionResult<List<Cliente>> ListarClientes()
        {
            return Ok(_context.Clientes.ToList());
        }

        [HttpGet("ObtenerCliente/{id}")]
        public ActionResult<Cliente> ObtenerCliente(int id)
        {
            var cliente = _context.Clientes
                .FirstOrDefault(c => c.IdCliente == id);

            if (cliente == null)
                return NotFound("Cliente no encontrado");

            return Ok(cliente);
        }

        [HttpPost("AgregarCliente")]
        public IActionResult AgregarCliente([FromBody] Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return Ok("Cliente agregado correctamente");
        }

        [HttpPut("ActualizarCliente/{id}")]
        public IActionResult ActualizarCliente(
            int id, [FromBody] Cliente datos)
        {
            var cliente = _context.Clientes
                .FirstOrDefault(c => c.IdCliente == id);

            if (cliente == null)
                return NotFound("Cliente no encontrado");

            cliente.Nombre = datos.Nombre;

            _context.SaveChanges();

            return Ok("Cliente actualizado correctamente");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Backend.API.RESTful.Data;
using Backend.API.RESTful.Models;
using System.Linq;

namespace Backend.API.RESTful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleVentaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DetalleVentaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Crear un nuevo detalle de venta
        [HttpPost]
        public IActionResult CrearDetalleVenta([FromBody] DetalleVentaModel detalleVenta)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            detalleVenta.CalcularPrecioTotal();
            _context.DetallesVenta.Add(detalleVenta);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ObtenerDetalleVenta), new { id = detalleVenta.Id }, detalleVenta);
        }

        // Obtener un detalle de venta por ID
        [HttpGet("{id}")]
        public IActionResult ObtenerDetalleVenta(int id)
        {
            var detalle = _context.DetallesVenta.FirstOrDefault(d => d.Id == id);

            if (detalle == null)
                return NotFound();

            return Ok(detalle);
        }

        // Obtener todos los detalles de ventas
        [HttpGet]
        public IActionResult ObtenerDetallesVenta()
        {
            var detalles = _context.DetallesVenta.ToList();
            return Ok(detalles);
        }

        // Actualizar un detalle de venta
        [HttpPut("{id}")]
        public IActionResult ActualizarDetalleVenta(int id, [FromBody] DetalleVentaModel detalleVenta)
        {
            if (!ModelState.IsValid || id != detalleVenta.Id)
                return BadRequest();

            var detalleExistente = _context.DetallesVenta.FirstOrDefault(d => d.Id == id);

            if (detalleExistente == null)
                return NotFound();

            detalleExistente.NumeroVenta = detalleVenta.NumeroVenta;
            detalleExistente.Articulo = detalleVenta.Articulo;
            detalleExistente.Cantidad = detalleVenta.Cantidad;
            detalleExistente.PrecioUnitario = detalleVenta.PrecioUnitario;
            detalleExistente.CalcularPrecioTotal();

            _context.DetallesVenta.Update(detalleExistente);
            _context.SaveChanges();

            return NoContent();
        }

        // Eliminar un detalle de venta
        [HttpDelete("{id}")]
        public IActionResult EliminarDetalleVenta(int id)
        {
            var detalle = _context.DetallesVenta.FirstOrDefault(d => d.Id == id);

            if (detalle == null)
                return NotFound();

            _context.DetallesVenta.Remove(detalle);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
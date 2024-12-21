using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CapaDatos.Customs;
using CapaEntidad;

namespace ApiFinancesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly DbPersonalfinancesContext _context;
        public CategoriaController(DbPersonalfinancesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            var lista = await _context.Categoria.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new {value=lista});
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(Categoria objeto)
        {
            var categoria = new Categoria
            {
                Nombre = objeto.Nombre
            };
            await _context.Categoria.AddAsync(categoria);
            await _context.SaveChangesAsync();

            if (objeto.IdCategoria != 0)
                return StatusCode(StatusCodes.Status200OK, new {isSuccess = true});
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });

        }
    }
}

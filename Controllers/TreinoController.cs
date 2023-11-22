using ControleExercicios.Context;
using Microsoft.AspNetCore.Mvc;
using ControleExercicios.Model;
using Microsoft.EntityFrameworkCore;

namespace ControleExercicios.Controller
{
    [Route("FichaTreino")]
    [ApiController]
    public class TreinoController : ControllerBase
    {
        private readonly TreinoContext? _context;

        public TreinoController(TreinoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Treino>>> GetTreino()
        {
            if(_context.Treinos == null)
            {
                return NotFound();
            }

            return await _context.Treinos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Treino>> GetTreino(Guid id)
        {
            if(_context.Treinos == null)
            {
                return NotFound();
            }

            var treino = await _context.Treinos.FindAsync(id);

            if(treino == null)
            {
                return NotFound();
            }

            return treino;
        }

        private bool TreinoExists(Guid id)
        {
            return(_context.Treinos?.Any(treino => treino.ID == id)).GetValueOrDefault();
        }
    }
}
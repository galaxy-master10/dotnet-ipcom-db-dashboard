
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcommerceAdminBackend.API.Data;
using EcommerceAdminBackend.API.Models;

namespace EcommerceAdminBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlePackagingBreakdownController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ArticlePackagingBreakdownController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ArticlePackagingBreakdown
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticlePackagingBreakdown>>> GetArticlePackagingBreakdowns()
        {
            return await _context.ArticlePackagingBreakdowns.ToListAsync();
        }

        // GET: api/ArticlePackagingBreakdown/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticlePackagingBreakdown>> GetArticlePackagingBreakdown(int id)
        {
            var articlePackagingBreakdown = await _context.ArticlePackagingBreakdowns.FindAsync(id);

            if (articlePackagingBreakdown == null)
            {
                return NotFound();
            }

            return articlePackagingBreakdown;
        }

        // PUT: api/ArticlePackagingBreakdown/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticlePackagingBreakdown(int id, ArticlePackagingBreakdown articlePackagingBreakdown)
        {
            if (id != articlePackagingBreakdown.Id)
            {
                return BadRequest();
            }

            _context.Entry(articlePackagingBreakdown).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticlePackagingBreakdownExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ArticlePackagingBreakdown
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArticlePackagingBreakdown>> PostArticlePackagingBreakdown(ArticlePackagingBreakdown articlePackagingBreakdown)
        {
            _context.ArticlePackagingBreakdowns.Add(articlePackagingBreakdown);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticlePackagingBreakdown", new { id = articlePackagingBreakdown.Id }, articlePackagingBreakdown);
        }

        // DELETE: api/ArticlePackagingBreakdown/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticlePackagingBreakdown(int id)
        {
            var articlePackagingBreakdown = await _context.ArticlePackagingBreakdowns.FindAsync(id);
            if (articlePackagingBreakdown == null)
            {
                return NotFound();
            }

            _context.ArticlePackagingBreakdowns.Remove(articlePackagingBreakdown);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArticlePackagingBreakdownExists(int id)
        {
            return _context.ArticlePackagingBreakdowns.Any(e => e.Id == id);
        }
    }
}

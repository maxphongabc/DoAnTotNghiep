using Common.Data;
using Common.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Areas.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentProductApiController : ControllerBase
    {
        private readonly ProjectDPContext _context;
        public CommentProductApiController(ProjectDPContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CommentProduct>>> GetCommemtProduct(int id)
        {
            return await _context.commentsproduct.Include(sp => sp.User).Where(s => s.IdProduct == id).ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<CommentProduct>> PostCommemtProduct(CommentProduct commentProduct)
        {
            _context.commentsproduct.Add(commentProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommemtProduct", new { id = commentProduct.Id }, commentProduct);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommemtProduct(int id, CommentProduct commentProduct)
        {
            if (id != commentProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(commentProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommemtProductExists(id))
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
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommentProduct>> DeleteCommentProduct(int id)
        {
            var commemtLessonModel = await _context.commentsproduct.FindAsync(id);
            if (commemtLessonModel == null)
            {
                return NotFound();
            }

            _context.commentsproduct.Remove(commemtLessonModel);
            await _context.SaveChangesAsync();

            return commemtLessonModel;
        }

        private bool CommemtProductExists(int id)
        {
            return _context.commentsproduct.Any(e => e.Id == id);
        }

    }
}

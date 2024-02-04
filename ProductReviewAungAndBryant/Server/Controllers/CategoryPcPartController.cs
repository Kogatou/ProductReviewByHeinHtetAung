using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductReviewAungAndBryant.Server.Data;
using ProductReviewAungAndBryant.Server.IRepository;
using ProductReviewAungAndBryant.Shared.Domain;

namespace ProductReviewAungAndBryant.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryPcPartController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryPcPartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/CategoryPcPart
        [HttpGet]
        //[Route("GetCategoryPcPart")]
        public async Task<IActionResult> GetCategoryPcPart()
        {
            var CategoryPcPart = await _unitOfWork.CategoryPcPart.GetAll();
            return Ok(CategoryPcPart);
        }

        // GET: api/CategoryPcPart/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            if (_unitOfWork.CategoryPcPart == null)
            {
                return NotFound();
            }
            var Category = await _unitOfWork.CategoryPcPart.Get(g => g.Id == id);

            if (Category == null)
            {
                return NotFound();
            }

            return Category;
        }

        // PUT: api/CategoryPcPart/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _unitOfWork.CategoryPcPart.Update(category);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CategoryExists(id))
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

        // POST: api/CategoryPcPart
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            if (_unitOfWork.CategoryPcPart == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CategoryPcPart'  is null.");
            }
            await _unitOfWork.CategoryPcPart.Insert(category);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/CategoryPcPart/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (_unitOfWork.CategoryPcPart == null)
            {
                return NotFound();
            }
            var Category = await _unitOfWork.CategoryPcPart.Get(g => g.Id == id);
            if (Category == null)
            {
                return NotFound();
            }

            await _unitOfWork.CategoryPcPart.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> CategoryExists(int id)
        {
            Category Category = await _unitOfWork.CategoryPcPart.Get(e => e.Id == id);
            return Category != null;
        }
    }
}

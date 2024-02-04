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
    public class ReviewersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReviewersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Reviewers
        [HttpGet]
        //[Route("GetReviewers")]
        public async Task<IActionResult> GetReviewers()
        {
            var Reviewers = await _unitOfWork.Reviewers.GetAll();
            return Ok(Reviewers);
        }

        // GET: api/Reviewers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reviewer>> GetReviewer(int id)
        {
            if (_unitOfWork.Reviewers == null)
            {
                return NotFound();
            }
            var Reviewer = await _unitOfWork.Reviewers.Get(g => g.Id == id);

            if (Reviewer == null)
            {
                return NotFound();
            }

            return Reviewer;
        }

        // PUT: api/Reviewers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReviewer(int id, Reviewer Reviewer)
        {
            if (id != Reviewer.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Reviewers.Update(Reviewer);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ReviewerExists(id))
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

        // POST: api/Reviewers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reviewer>> PostReviewer(Reviewer Reviewer)
        {
            if (_unitOfWork.Reviewers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Reviewers'  is null.");
            }
            await _unitOfWork.Reviewers.Insert(Reviewer);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetReviewer", new { id = Reviewer.Id }, Reviewer);
        }

        // DELETE: api/Reviewers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReviewer(int id)
        {
            if (_unitOfWork.Reviewers == null)
            {
                return NotFound();
            }
            var Reviewer = await _unitOfWork.Reviewers.Get(g => g.Id == id);
            if (Reviewer == null)
            {
                return NotFound();
            }

            await _unitOfWork.Reviewers.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> ReviewerExists(int id)
        {
            Reviewer Reviewer = await _unitOfWork.Reviewers.Get(e => e.Id == id);
            return Reviewer != null;
        }
    }
}

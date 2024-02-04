using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ProductReviewAungAndBryant.Server.Data;
using ProductReviewAungAndBryant.Server.IRepository;
using ProductReviewAungAndBryant.Shared.Domain;

namespace ProductReviewAungAndBryant.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PcPartsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PcPartsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/PcParts
        [HttpGet]
        //[Route("GetPcParts")]
        public async Task<IActionResult> GetPcParts()
        {
            var pcparts = await _unitOfWork.PcParts.GetAll();

            foreach (var p in pcparts)
            {
                List<PcPartImage> pcPartImages = (List<PcPartImage>)await _unitOfWork.PcPartImages.GetAll(x=> x.PcPartId == p.Id);
                p.PcPartImages = pcPartImages;
            }

            return Ok(pcparts);
        }

        // GET: api/PcParts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PcPart>> GetPcPart(int id)
        {
            if (_unitOfWork.PcParts == null)
            {
                return NotFound();
            }
            var pcpart = await _unitOfWork.PcParts.Get(g => g.Id == id);

            if (pcpart == null)
            {
                return NotFound();
            }

            var categoryPcPart = await _unitOfWork.CategoryPcParts.GetAll(g => g.PcPartId == pcpart.Id);

            if (categoryPcPart != null)
            {

                pcpart.CategoryPcParts = new List<CategoryPcPart>();
                pcpart.CategoryPcParts = (List<CategoryPcPart>)categoryPcPart;

                foreach (var categoryPcPartItem in pcpart.CategoryPcParts)
                {
                    categoryPcPartItem.Category = await _unitOfWork.Categories.Get(x => x.Id == categoryPcPartItem.CategoryId);
                }
            }     

            return pcpart;
        }

        // PUT: api/PcParts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPcPart(int id, PcPart pcpart)
        {
            if (id != pcpart.Id)
            {
                return BadRequest();
            }

            _unitOfWork.PcParts.Update(pcpart);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PcPartExists(id))
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

        // POST: api/PcParts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PcPart>> PostPcPart(PcPart pcpart)
        {
            if (_unitOfWork.PcParts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PcParts'  is null.");
            }
            await _unitOfWork.PcParts.Insert(pcpart);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetPcPart", new { id = pcpart.Id }, pcpart);
        }

        // DELETE: api/PcParts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePcPart(int id)
        {
            if (_unitOfWork.PcParts == null)
            {
                return NotFound();
            }
            var pcpart = await _unitOfWork.PcParts.Get(g => g.Id == id);
            if (pcpart == null)
            {
                return NotFound();
            }

            await _unitOfWork.PcParts.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        // POST: api/PcParts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Shared.Domain.CategoryPcPart>> AddCategoryPcPart(Shared.Domain.CategoryPcPart categoryPcPart)
        {
            if (_unitOfWork.CategoryPcParts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CategoryPcParts'  is null.");
            }
            await _unitOfWork.CategoryPcParts.Insert(categoryPcPart);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetPcPart", new { id = categoryPcPart.Id }, categoryPcPart);
        }

        // GET: api/PcParts/5
        [HttpGet("{pcPartId}")]
        public async Task<IActionResult> GetCategoryByPcPartId(int pcPartId)
        {
            if (_unitOfWork.CategoryPcParts == null)
            {
                return NotFound();
            }
            var categoryPcPart = await _unitOfWork.CategoryPcParts.GetAll(g => g.PcPartId == pcPartId);

            if (categoryPcPart == null)
            {
                return NotFound();
            }

            return Ok(categoryPcPart);
        }

        private async Task<bool> PcPartExists(int id)
        {
            PcPart pcpart = await _unitOfWork.PcParts.Get(e => e.Id == id);
            return pcpart != null;
        }
    }
}

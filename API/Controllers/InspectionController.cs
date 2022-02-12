using API.Data;
using API.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class InspectionController : BaseApiController
    {
        private readonly DataContext _context;
        public InspectionController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inspection>>> GetInspections()
        {
            return Ok(await _context.Inspections.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Inspection>> GetInspection(int id)
        {
            var Inspection = await _context.Inspections.FindAsync(id);

            if (Inspection == null) return NotFound();
            
            return Ok(Inspection);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateInspection(int id, InspectionDto inspectionDto)
        {
            var inspection = await _context.Inspections.FindAsync(id);

            if (inspection == null) return NotFound();

            var updateInspection = new Inspection
            {
                Status = inspectionDto.Status,
                Comments = inspectionDto.Comments,
                InspectionTypeId = inspectionDto.InspectionTypeId
            };

            _context.Inspections.Update(updateInspection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Inspection>> CreateInspection(Inspection inspection)
        {
            _context.Inspections.Add(inspection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInspection", new {id = inspection.Id}, inspection);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInspection(int id)
        {
            var inspection = await _context.Inspections.FindAsync(id);

            if (inspection == null) return NotFound();

            _context.Inspections.Remove(inspection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
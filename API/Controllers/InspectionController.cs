using API.Data;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class InspectionController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public InspectionController(DataContext context, IMapper mapper)
        {
            this._mapper = mapper;
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
        public async Task<ActionResult<InspectionToReturnDto>> UpdateInspection(int id, InspectionDto inspectionDto)
        {
            var inspe = await _context.Inspections.FindAsync(id);

            _mapper.Map(inspectionDto, inspe);

            _context.Entry(inspe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspectionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(inspe);
        }

        [HttpPost]
        public async Task<ActionResult<Inspection>> CreateInspection(Inspection inspection)
        {
            _context.Inspections.Add(inspection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInspection", new { id = inspection.Id }, inspection);
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

        private bool InspectionExists(int id)
        {
            return _context.Inspections.Any(x => x.Id == id);
        }

    }
}
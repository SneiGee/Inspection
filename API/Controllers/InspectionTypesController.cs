using API.Data;
using API.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class InspectionTypesController : BaseApiController
    {
        private readonly DataContext _context;
        public InspectionTypesController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<InspectionType>>> GetInspectionType()
        {
            return Ok(await _context.inspectionTypes.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<InspectionType>> CreateInspectionTypes(InspectionType inspectionType)
        {
            _context.inspectionTypes.Add(inspectionType);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
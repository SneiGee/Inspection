using System.Collections.Generic;
using API.Data;
using API.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class StatusController : BaseApiController
    {
        private readonly DataContext _context;
        public StatusController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Status>>> GetStatus()
        {
            return Ok(await _context.Statuses.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Status>> CreateStatus(Status status)
        {
            _context.Statuses.Add(status);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
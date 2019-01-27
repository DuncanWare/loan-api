using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouLendApi.Models;

namespace YouLendApi.Controllers
{
    [Route("api/loan")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly LoanContext _context;

        public LoanController(LoanContext context)
        {
            _context = context;

            if (_context.LoanFiles.Count() == 0)
            {
                _context.LoanFiles.Add(new LoanFile { BorrowerName = "NewBorrower" });
                _context.SaveChanges();
            }
        }

        // GET: api/Loan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanFile>>> GetLoans()
        {
            return await _context.LoanFiles.ToListAsync();
        }

        // GET: api/Loan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanFile>> GetLoan(long id)
        {
            var loan = await _context.LoanFiles.FindAsync(id);

            if (loan == null)
            {
                return NotFound();
            }

            return loan;
        }

        // POST: api/Loan
        [HttpPost]
        public async Task<ActionResult<LoanFile>> PostLoan(LoanFile loan)
        {
            _context.LoanFiles.Add(loan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoan", new { id = loan.Id }, loan);
        }
        // PUT: api/Loan/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoan(long id, LoanFile loan)
        {
            if (id != loan.Id)
            {
                return BadRequest();
            }

            _context.Entry(loan).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // DELETE: api/Loan/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoanFile>> DeleteLoan(long id)
        {
            var loan = await _context.LoanFiles.FindAsync(id);
            if (loan == null)
            {
                return NotFound();
            }

            _context.LoanFiles.Remove(loan);
            await _context.SaveChangesAsync();

            return loan;
        }
    }
}
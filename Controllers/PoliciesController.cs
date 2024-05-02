using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using insurance.Models;

namespace Insurance.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PolicyController : ControllerBase
	{
		private readonly InsurancesContext _context;

		public PolicyController(InsurancesContext context)
		{
			_context = context;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var policy = await _context.Policies.FirstOrDefaultAsync(x=>x.EmpId==id);
			if (policy == null)
				return NotFound();
			return Ok(policy);	
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Policy policy)
		{
			_context.Policies.Add(policy);
			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(Get), new { id = policy.PolicyId }, policy);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var policy = await _context.Policies.FindAsync(id);
			if (policy == null)
				return NotFound();
			_context.Policies.Remove(policy);
			await _context.SaveChangesAsync();
			return Ok();
		}
	}
}

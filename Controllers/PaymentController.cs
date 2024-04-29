using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using insurance.Models;

namespace APIdb.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaymentController : ControllerBase
	{
		private readonly InsurancesContext _context;

		public PaymentController(InsurancesContext context)
		{
			_context = context;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var payment = await _context.Payments.FindAsync(id);
			if (payment == null)
				return NotFound();
			return Ok(payment);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, Payment payment)
		{
			if (id != payment.PaymentId)
				return BadRequest("Payment ID mismatch");

			_context.Entry(payment).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PaymentExists(id))
					return NotFound();
				else
					throw;
			}

			return NoContent();
		}

		private bool PaymentExists(int id)
		{
			return _context.Payments.Any(e => e.PaymentId == id);
		}
	}
}

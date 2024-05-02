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

		[HttpPost]
		public async Task<IActionResult> Post(Payment payment)
		{
			_context.Payments.Add(payment);
			await _context.SaveChangesAsync();
			return Ok();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var payment = await _context.Payments.Where(x=> x.EmpId==id).ToListAsync();
			if (payment == null)
				return NotFound();
			return Ok(payment);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, Payment payment)
		{
			if (id != payment.PaymentId)
			{
				return BadRequest("Payment ID mismatch");
			}

			var existingPayment = await _context.Payments.FirstOrDefaultAsync(x=>x.PaymentId==id);
			if (existingPayment == null)	
			{
				return NotFound();
			}

			existingPayment.CardHolder = payment.CardHolder;
			existingPayment.CardNumber = payment.CardNumber;
			existingPayment.ExpDate= payment.ExpDate;

			_context.Entry(existingPayment).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PaymentExists(id))
				{
					return NotFound();
				}
				else
				{
					// Log the exception or handle it appropriately
					throw;
				}
			}

			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			if (id < 1)
				return BadRequest();
			var card = await _context.Payments.FirstOrDefaultAsync(m => m.PaymentId == id);
			if (card == null)
				return NotFound();
			_context.Payments.Remove(card);
			await _context.SaveChangesAsync();
			return Ok();

		}
		private bool PaymentExists(int id)
		{
			return _context.Payments.Any(e => e.PaymentId == id);
		}
	}
}

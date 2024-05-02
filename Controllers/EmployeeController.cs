using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using insurance.Models;

namespace Insurance.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly InsurancesContext _context;

		public EmployeeController(InsurancesContext context)
		{
			_context = context;
		}

		[HttpPost]
		public async Task<IActionResult> Post(Employee employee)
		{
			_context.Employees.Add(employee);
			await _context.SaveChangesAsync();
			return Ok();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetEmpById(int id)
		{
			var user=await _context.Employees.FirstOrDefaultAsync(x=>x.EmpId==id);

			if (user == null) return NotFound();
			return  Ok(user);

		}

		[HttpGet]
		[Route("api/users/{username}")]
		public async Task<IActionResult> GetPassword(string username)
		{
			// Retrieve the user from the database based on the provided username
			var user = await _context.Employees.FirstOrDefaultAsync(m => m.Email == username);

			if (user == null)
			{
				return NotFound(); // User not found
			}

			// Return the password in the response
			return Ok(user);
		}
	}
}

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
	}
}

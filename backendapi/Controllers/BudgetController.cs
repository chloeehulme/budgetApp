using Microsoft.AspNetCore.Mvc;
using backendApi.Models;
using backendApi.Persistence;

namespace backendApi.Controllers
{

    [ApiController]
    [Route("api/budget")]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetDataAccess _budgetRepo;
        public BudgetController(IBudgetDataAccess budgetRepo)
        {
            _budgetRepo = budgetRepo;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public IActionResult GetAllBudgetItems()
        {
            var items = _budgetRepo.GetAllBudgetItems();
            return Ok(items);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public IActionResult AddBudgetItem([FromBody] BudgetItem newItem)
        {
            if (newItem is not null)
            {
                _budgetRepo.AddBudgetItem(newItem);

                return CreatedAtAction(nameof(AddBudgetItem), new { id = newItem.Id }, newItem);
            }

            return BadRequest();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalorieKing.Models;

namespace CalorieKing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly MealContext _context;

        public MealsController(MealContext context)
        {
            _context = context;

            if (_context.MealItems.Count() == 0)
            {
                _context.MealItems.Add(new MealItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MealItem>>> GetMealItems()
        {
            return await _context.MealItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MealItem>> GetMealItem(long id)
        {
            var mealItem = await _context.MealItems.FindAsync(id);

            if (mealItem == null)
            {
                return NotFound();
            }

            return mealItem;
        }

        [HttpPost]
        public async Task<ActionResult<MealItem>> PostMealItem(MealItem item)
        {
            _context.MealItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostMealItem), new {
                userId = item.UserId,
                name = item.Name,
                calories = item.Calories,
                date = DateTime.Now
            }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMealItem(long id, MealItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchMealItem(long id, MealItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMealItem(long id)
        {
            var mealItem = await _context.MealItems.FindAsync(id);

            if (mealItem == null){
                return NotFound();
            }

            _context.MealItems.Remove(mealItem);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
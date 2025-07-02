using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RBACWebAPI.Data;
using RBACWebAPI.Models;
using System.Security.Claims;

namespace RBACWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize] // Requires user to be authenticated
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetCategoriesForUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Get groups the user belongs to
            var userGroups = await _context.UserGroups
                .Where(ug => ug.UserId == userId)
                .Select(ug => ug.GroupId)
                .ToListAsync();

            // If no groups → show "No data"
            if (!userGroups.Any())
            {
                return Ok(new { message = "No data", categories = new List<Category>() });
            }

            // Check if user is a premium user
            var isPremium = await _context.PremiumUsers.AnyAsync(p => p.UserId == userId);

            // Get category IDs user has access to via groups
            var categoryIds = await _context.GroupCategories
                .Where(gc => userGroups.Contains(gc.GroupId))
                .Select(gc => gc.CategoryId)
                .Distinct()
                .ToListAsync();

            // If premium → add Mobile Phones category
            if (isPremium)
            {
                var premiumCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Name == "Mobile Phones");
                if (premiumCategory != null && !categoryIds.Contains(premiumCategory.Id))
                {
                    categoryIds.Add(premiumCategory.Id);
                }
            }

            // Get categories + include products
            var categories = await _context.Categories
                .Where(c => categoryIds.Contains(c.Id))
                .Include(c => c.Products)
                .ToListAsync();

            return Ok(new { categories });
        }
    }
}

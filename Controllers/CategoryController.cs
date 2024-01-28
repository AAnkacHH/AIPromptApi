using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PromptAPI.Model.Request;
using PromptAPI.Service;
using PromptAPI.Service.Database;

namespace PromptAPI.Controllers;

[ApiController]
[Route("/[controller]")]
public class CategoryController(CategoryService categoryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await categoryService.FindAllCategoriesAsync();
        return Ok(categories);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory(int id)
    {
        var category = await categoryService.GetCategoryResponseById(id);
        if (category == null) return NotFound();
        return Ok(category);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
    {
        var category = await categoryService.CreateCategoryAsync(request);
        return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] CreateCategoryRequest request)
    {
        try {
            await categoryService.UpdateCategoryAsync(id, request);
        } catch (Exception e) {
            return NotFound(e.Message);
        }
        return NoContent(); 
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        try {
            await categoryService.DeleteCategoryAsync(id);
        } catch (Exception e) {
            return NotFound(e.Message);
        }

        return NoContent(); // 204 No Content
    }
}

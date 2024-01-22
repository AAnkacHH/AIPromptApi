using Microsoft.AspNetCore.Mvc;
using PromptAPI.Model.Request;
using PromptAPI.Service;

namespace PromptAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PromptsController(PromptService promptService) : ControllerBase
{

    [HttpPost]
    [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreatePrompt(CreatePromptRequest request)
    {
        var prompt = await promptService.AddPromptAsync(request);
        return CreatedAtAction(
           actionName: nameof(GetPrompts),
           routeValues: new { id = prompt.Id },
           value: prompt
        );
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
    public async Task<IActionResult> GetPrompts()
    {
        var prompts = await promptService.FindAllPrompts();
        return Ok(prompts);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
    public async Task<IActionResult> GetPrompts(int id)
    {
        var prompt = await promptService.FindPromptByIdAsync(id);
        return Ok(prompt);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePrompt(int id)
    {
        try {
            promptService.DeletePrompt(id);
        } catch (Exception e) {
            return NotFound(e.Message);
        }

        return NoContent(); // 204 No Content
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
    public async Task<IActionResult> UpdatePrompt(int id, CreatePromptRequest request)
    {
        try {
            await promptService.UpdatePrompt(id, request);
        } catch (Exception e) {
            return NotFound(e.Message);
        }
        return NoContent(); 
    }
}



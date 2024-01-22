using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PromptAPI.Model.Entity;
using PromptAPI.Model.Request;
using PromptAPI.Service.Database;

namespace PromptAPI.Service;

public class PromptService(PromptDbContext context, IMapper mapper)
{
    public async Task<Prompt> AddPromptAsync(CreatePromptRequest request)
    {
        var prompt = mapper.Map<Prompt>(request);
        context.Prompts.Add(prompt);
        await context.SaveChangesAsync();
        return prompt;
    }

    public async Task<Prompt?> FindPromptByIdAsync(int id)
    {
        return await context.Prompts
            .Include(p => p.Author)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Prompt>> FindPromptsByAuthorIdAsync(int authorId)
    {
        return await context.Prompts // DbSet<Prompt>
            .Where(p => p.Author.Id == authorId)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Prompt>> FindAllPrompts()
    {
        return await context.Prompts // DbSet<Prompt>
            .ToListAsync();
    }

    public async Task DeletePrompt(int id)
    {
        var prompt = await FindPromptByIdAsync(id);
        if (prompt == null)
        {
            throw new Exception("Prompt not found");
        }

        context.Prompts.Remove(prompt);
        await context.SaveChangesAsync();
    }
    
    public async Task UpdatePrompt(int id, CreatePromptRequest request)
    {
        var prompt = await FindPromptByIdAsync(id);
        if (prompt == null) {
            throw new Exception("Prompt not found");
        }

        prompt = mapper.Map(request, prompt);
        prompt.ModifiedAt = DateTime.UtcNow;
        prompt.Version += 1;
        context.Prompts.Update(prompt);
        await context.SaveChangesAsync();
    }
}

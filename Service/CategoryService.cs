using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PromptAPI.Model.Entity;
using PromptAPI.Model.Mapping;
using PromptAPI.Model.Request;
using PromptAPI.Model.Response;
using PromptAPI.Service.Database;

namespace PromptAPI.Service;

public class CategoryService
{
    private readonly PromptDbContext _context;
    private readonly IMapper _mapper;

    public CategoryService(PromptDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<CategoryResponse>> FindAllCategoriesAsync()
    {
        return await _mapper.ProjectTo<CategoryResponse> (_context.Categories.AsQueryable()).ToListAsync();
    }

    public async Task<Category?> FindCategoryByIdAsync(int id)
    {
        return await _context.Categories
            .FirstOrDefaultAsync(p => p.Id == id);;
    }

    public async Task<CategoryResponse?> GetCategoryResponseById(int id)
    {
        return _mapper.Map<CategoryResponse>(await FindCategoryByIdAsync(id));
    }

    public async Task<Category> CreateCategoryAsync(CreateCategoryRequest request)
    {
        var category = _mapper.Map<Category>(request);
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task UpdateCategoryAsync(int id, CreateCategoryRequest request)
    {
        var category = await FindCategoryByIdAsync(id);
        if (category == null) throw new Exception("Category not found");
        category = _mapper.Map(request, category);
        category.ModifiedAt = DateTime.UtcNow;
        _context.Entry(category).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCategoryAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null) throw new Exception("Category not found");
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }
}

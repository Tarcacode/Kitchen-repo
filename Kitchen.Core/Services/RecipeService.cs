using Kitchen.Core.Models;

namespace Kitchen.Core.Services;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepo _recipeRepo;

    public RecipeService(IRecipeRepo recipeRepo)
    {
        _recipeRepo = recipeRepo;
    }

    public async Task<List<Recipe>> GetRecipesAsync(int limit, DateTime fromDate)
    {
        if (limit > 25)
            limit = 25;

        List<Recipe> recipes = await _recipeRepo.GetRecipesAsync(limit, fromDate);

        return recipes;
    }

    public async Task<Recipe> GetRecipeByIdAsync(Guid id)
    {
        Recipe recipe = await _recipeRepo.GetRecipeByIdAsync(id);

        return recipe;
    }

    public async Task<Recipe> CreateRecipe(CreateRecipeModel createRecipeModel)
    {
        Recipe recipe = new()
        {
            Id = Guid.NewGuid(),
            Title = createRecipeModel.Title,
            Description = createRecipeModel.Description,
            RecipeCategoryId = createRecipeModel.RecipeCategoryId,
            CreatedOn = DateTime.UtcNow
        };

        bool isCreated = await _recipeRepo.CreateRecipeAsync(recipe);

        if (isCreated == false)
            return null;
        else
            return recipe;
    }
}

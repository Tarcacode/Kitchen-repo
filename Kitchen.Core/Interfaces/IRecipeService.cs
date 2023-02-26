﻿namespace Kitchen.Core.Interfaces;

public interface IRecipeService
{
    Task<List<Recipe>> GetRecipesAsync(int limit, DateTime fromDate);
}
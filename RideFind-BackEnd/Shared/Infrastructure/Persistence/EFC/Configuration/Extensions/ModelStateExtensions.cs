using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RideFind_BackEnd.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelStateExtensions
{
    public static List<string> GetErrorMessage(this ModelStateDictionary dictionary)
    {
        return dictionary
            .SelectMany(m => m.Value!.Errors)
            .Select(m => m.ErrorMessage)
            .ToList();
    }
}

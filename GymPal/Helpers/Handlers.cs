using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GymPal.Helpers;

public static class Handlers
{
    public static async Task<ObjectResult> RequestHandler(Func<Task<ObjectResult>> action)
    {
        try
        {
            return await action();
        }
        catch (Exception ex)
        {
            return new ObjectResult(ex.Message) { StatusCode = 500 };
        }
    }
    
}
using Microsoft.Extensions.Options;

namespace MvcProblems;

public class ProblemDetailsConfigOptions : IConfigureOptions<ProblemDetailsOptions>
{
    public void Configure(ProblemDetailsOptions options)
    {
        options.CustomizeProblemDetails = c =>
            c.ProblemDetails.Instance = c.HttpContext.Request.Path;
    }
}
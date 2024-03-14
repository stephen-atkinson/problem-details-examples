using Microsoft.Extensions.Options;

namespace ProblemDetailsExample;

public class ProblemDetailsConfigOptions : IConfigureOptions<ProblemDetailsOptions>
{
    public void Configure(ProblemDetailsOptions options)
    {
        options.CustomizeProblemDetails = c =>
            c.ProblemDetails.Instance = c.HttpContext.Request.Path;
    }
}
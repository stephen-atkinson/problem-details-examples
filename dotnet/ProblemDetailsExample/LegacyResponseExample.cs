// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace ProblemDetailsExample;

public class ResponseResult
{
    public IReadOnlyCollection<ResultError> Errors { get; set; }
    public object Data { get; set; }
    public object Meta { get; set; }
}

public class ResultError
{
    public int Code { get; set; }
    public string Description { get; set; }
    public string Message { get; set; }
    public string Reference { get; set; }
}
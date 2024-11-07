using System.Net;
using System.Net.Http.Json;

namespace Deiarts.Common.Client.ProblemDetails;

[Serializable]
public class ProblemDetailsException : Exception
{
    public string Type { get; private set; }
    public string Title { get; private set; }
    public HttpStatusCode Status { get; private set; }
    public string? Detail { get; private set; }
    public Dictionary<string, string[]>? Errors { get; private set; }

    public ProblemDetailsException(
        string type,
        string title,
        HttpStatusCode status,
        string? detail,
        Dictionary<string, string[]>? errors) : base(detail ?? title)
    {
        Type = type;
        Title = title;
        Status = status;
        Detail = detail;
        Errors = errors;
    }

    public static async Task ThrowIfNotOk(HttpResponseMessage httpResponseMessage)
    {
        if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
        {
            var problemDetailsException = await httpResponseMessage
                .Content
                .ReadFromJsonAsync(Default.ProblemDetailsException);

            throw problemDetailsException!;
        }
    }

}

using System.Text;
using System.Text.Json.Nodes;

namespace Deiarts.Common.Client.Services.Endpoints;

public static class QueryStringHelper
{
    public static string ToQueryString<TValue>(TValue value, JsonTypeInfo<TValue> jsonTypeInfo)
    {
        var jsonNode = JsonSerializer.SerializeToNode(value, jsonTypeInfo);
        Throw.When.Null(jsonNode, $"Não foi possível serializar o objeto {typeof(TValue).Name} para um jsonNode.");

        StringBuilder query = new();

        foreach (var (jsonPropertyKey, jsonPropertyValue) in jsonNode.AsObject())
        {
            if (jsonPropertyValue is JsonArray jsonArray)
            {
                foreach (var jsonValue in jsonArray)
                {
                    if (jsonValue is null) { continue; }
                    query.Append($"{Uri.EscapeDataString(jsonPropertyKey)}={Uri.EscapeDataString(jsonValue.ToString())}&");
                }
            }
            else
            {
                if (jsonPropertyValue is null) { continue; }
                query.Append($"{Uri.EscapeDataString(jsonPropertyKey)}={Uri.EscapeDataString(jsonPropertyValue.ToString())}&");
            }
        }

        return query.ToString().TrimEnd('&');
    }
}

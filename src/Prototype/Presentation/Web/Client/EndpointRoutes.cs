namespace Deiarts.Prototype.Presentation.Web.Client;

public static class EndpointRoutes
{
    public const string Base = "api";
    
    public static class Materials
    {
        public const string Group = "materials";
        
        public const string GetAll = "";
        
        public const string Get = "{id:guid}";
        
        public const string Editor = "";
    }
    
    public static string Create(string group, string endpoint) => $"{Base}/{group}/{endpoint}";
    public static string Create(string group) => $"{Base}/{group}";
    
    public static string BuildGetEndpointWithPath(string group, string pathValue)
    {
        return $"{Base}/{group}/{pathValue}";
    }
    
    public static string CreateGetRouteWithPaths(string group, params string[] pathValues)
    {
        return $"{Base}/{group}/{string.Join("/", pathValues)}";
    }

    public static string CreatePostEndpoint(string group)
    {
        return $"{Base}/{group}";
    }
}
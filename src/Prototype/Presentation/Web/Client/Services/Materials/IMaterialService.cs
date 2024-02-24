using System.Net.Http.Json;
using Deiarts.Prototype.Application.Shared.Materials;

namespace Deiarts.Prototype.Presentation.Web.Client.Services.Materials;

public interface IMaterialService
{
    Task<MaterialDto[]> GetAllAsync();
    Task<MaterialDto> GetAsync(Guid id);
    Task EditorAsync(EditorMaterialRequest request);
}

public class MaterialService(HttpClient httpClient) : IMaterialService
{
    public async Task<MaterialDto[]> GetAllAsync()
    {
        var endpoint = EndpointRoutes.Create(EndpointRoutes.Materials.Group);
        
        var materials = await httpClient.GetFromJsonAsync<MaterialDto[]>(endpoint);
        return materials ?? [];
    }

    public async Task<MaterialDto> GetAsync(Guid id)
    {
        var endpoint = EndpointRoutes.BuildGetEndpointWithPath(EndpointRoutes.Materials.Group, id.ToString());
        
        var material = await httpClient.GetFromJsonAsync<MaterialDto>(endpoint);
        return material ?? throw new Exception("Material não encontrado.");
    }

    public async Task EditorAsync(EditorMaterialRequest request)
    {
        var endpoint = EndpointRoutes
            .CreatePostEndpoint(EndpointRoutes.Materials.Group);
        
        await httpClient.PostAsJsonAsync(endpoint, request);
    }
}
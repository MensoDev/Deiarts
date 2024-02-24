using Deiarts.Prototype.Application.Materials;
using Deiarts.Prototype.Application.Shared.Materials;
using Deiarts.Prototype.Presentation.Web.Client;

namespace Deiarts.Prototype.Presentation.Web.Endpoints.Materials;

public static class MaterialEndpoints
{
    public static RouteGroupBuilder MapMaterialsEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup(EndpointRoutes.Materials.Group);
        
        group.MapGet(EndpointRoutes.Materials.GetAll, ListMaterialsHandler.HandleAsync);
        group.MapGet(EndpointRoutes.Materials.Get, GetMaterialByIdHandler.HandleAsync);
        
        group
            .MapPost(EndpointRoutes.Materials.Editor, EditorMaterialHandler.HandleAsync)
            .AddValidator<EditorMaterialValidator, EditorMaterialRequest>();

        return group;
    }
}
using Deiarts.Prototype.Application.Shared.Materials;
using Deiarts.Prototype.Domain.Entities;
using Menso.Tools.Exceptions;

namespace Deiarts.Prototype.Application.Materials;

public static class EditorMaterialHandler
{
    public static async Task HandleAsync(EditorMaterialRequest request, IMaterialRepository materialRepository)
    {
        Material? material;

        if (request.Id is not null)
        {
            material = await materialRepository.GetAsync(request.Id.Value);
            Throw.Http.NotFound.When.Null(material, "Material não encontrado.");
            material.Update(request.Name!, request.PricePerUnit, request.Description!);
        }
        else
        {
            material = new Material(request.Name!, request.PricePerUnit, request.Description!);
            materialRepository.Add(material);
        }
        
        await materialRepository.SaveChangesAsync();
    }
}
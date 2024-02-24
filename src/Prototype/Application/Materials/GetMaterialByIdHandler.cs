using Deiarts.Prototype.Application.Shared.Materials;
using Menso.Tools.Exceptions;

namespace Deiarts.Prototype.Application.Materials;

public static class GetMaterialByIdHandler
{
    public static async Task<MaterialDto> HandleAsync(Guid id, IMaterialRepository materialRepository)
    {
        var material = await materialRepository
            .GetQueryable()
            .Where(m => m.Id == id)
            .Select(m => new MaterialDto
            {
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                PricePerUnit = m.PricePerUnit
            })
            .FirstOrDefaultAsync();
        
        Throw.Http.NotFound.When.Null(material, "Material não encontrado.");

        return material;
    }
}
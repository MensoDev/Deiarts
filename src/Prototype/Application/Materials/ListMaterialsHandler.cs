using Deiarts.Prototype.Application.Shared.Materials;

namespace Deiarts.Prototype.Application.Materials;

public static class ListMaterialsHandler
{
    public static async Task<MaterialDto[]> HandleAsync(IMaterialRepository materialRepository)
    {
        var materials = await materialRepository
            .GetQueryable()
            .Select(m => new MaterialDto
            {
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                PricePerUnit = m.PricePerUnit
            })
            .ToArrayAsync();

        return materials;
    }
}
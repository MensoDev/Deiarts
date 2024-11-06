using Deiarts.Domain.RawMaterials;

namespace Deiarts.Application.RawMaterials.Edit;

public class EditRawMaterialEndpoint() : CommandEndpoint<EditRawMaterialRequest>(
    Default.EditRawMaterialRequest,
    validator: new EditRawMaterialValidator(),
    allowAnonymous: true)
{
    internal static async Task ExecuteAsync(
        EditRawMaterialRequest request, 
        IRawMaterialRepository repository,
        IUnitOfWork unitOfWork)
    {
        RawMaterial? rawMaterial;

        if (request.Id is null)
        {
            rawMaterial = new RawMaterial(request.Name, request.Description);
            repository.Add(rawMaterial);
        }
        else
        {
            rawMaterial = await repository.GetAsync(request.Id.Value);
            Throw.Http.NotFound.When.Null(rawMaterial, "Matéria-prima não encontrada.");
            rawMaterial.Update(request.Name, request.Description);
        }

        await unitOfWork.SaveChangesAsync();
    }
}
using Deiarts.Domain.RawMaterials;

namespace Deiarts.Application.RawMaterials.Remove;

public class RemoveRawMaterialEndpoint() : CommandEndpoint<ValueRequest<RawMaterialId>>(
    Default.ValueRequestRawMaterialId,
    allowAnonymous: true)
{
    internal static async Task ExecuteAsync(
        ValueRequest<RawMaterialId> request, 
        IRawMaterialRepository repository,
        IUnitOfWork unitOfWork)
    {
        var rawMaterial = await repository.GetAsync(request.Value);
        Throw.Http.NotFound.When.Null(rawMaterial, "Matéria prima não encontrada.");
        
        //TODO: Verificar se a matéria prima está sendo utilizada em algum produto.
        
        repository.Remove(rawMaterial);
        await unitOfWork.SaveChangesAsync();
    }
}
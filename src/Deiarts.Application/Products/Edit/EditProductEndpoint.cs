using Deiarts.Domain.Products;

namespace Deiarts.Application.Products.Edit;

public class EditProductEndpoint() : CommandEndpoint<EditProductRequest>(
    Default.EditProductRequest,
    validator: new EditProductValidator(),
    allowAnonymous: true)
{
    internal static async Task ExecuteAsync(EditProductRequest request, IProductRepository repository,
        IUnitOfWork unitOfWork)
    {
        Product product;

        if (request.Id.HasValue)
        {
            var productFounded = await repository.GetAsync(request.Id.Value);
            Throw.Http.NotFound.When.Null(productFounded, "Produto não encontrado.");
            product = productFounded;
            product.Update(request.Name, request.Description);
        }
        else
        {
            product = new Product(request.Name, request.Description);
            repository.Add(product);
        }

        var currentCompositionIds = product.Compositions.Select(c => c.Id).ToArray();
        
        var currentCompositionRequestIds = request.Compositions
            .Where(composition => composition.Id.HasValue)
            .Select(composition => composition.Id.GetValueOrDefault())
            .ToArray();

        var compositionIdsForRemove = currentCompositionIds.Except(currentCompositionRequestIds).ToArray();

        product.RemoveCompositions(compositionIdsForRemove);

        foreach (var compositionRequest in request.Compositions)
        {
            product.ChangeComposition(
                compositionRequest.RawMaterialId.GetValueOrDefault(),
                compositionRequest.Description,
                compositionRequest.Quantity.GetValueOrDefault());
        }

        await unitOfWork.SaveChangesAsync();
    }
}
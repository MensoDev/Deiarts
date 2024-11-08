using Deiarts.Domain.RawMaterials;
using Microsoft.AspNetCore.Http;

namespace Deiarts.Application.RawMaterials.Get;

public class GetRawMaterialEndpoint() : QueryEndpoint<GetRawMaterialResponse, ValueRequest<RawMaterialId>>(
    Default.GetRawMaterialResponse,
    Default.ValueRequestRawMaterialId,
    allowAnonymous: true)
{
    internal static async Task<GetRawMaterialResponse> ExecuteAsync(
        [AsParameters] ValueRequest<RawMaterialId> request,
        IRawMaterialQueries queries)
    {
        var response = await queries.GetAsync(request.Value);
        Throw.Http.NotFound.When.Null(response, "Matéria prima não encontrada.");
        return response;
    }

    
}
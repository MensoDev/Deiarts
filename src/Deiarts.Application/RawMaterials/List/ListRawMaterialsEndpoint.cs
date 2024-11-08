using Microsoft.AspNetCore.Http;

namespace Deiarts.Application.RawMaterials.List;

public class ListRawMaterialsEndpoint() : QueryEndpoint<ListRawMaterialsResponseItem[], ListRawMaterialRequest>(
    Default.ListRawMaterialsResponseItemArray,
    Default.ListRawMaterialRequest,
    allowAnonymous: true)
{
    internal static async Task<ListRawMaterialsResponseItem[]> ExecuteAsync(
        [AsParameters] ListRawMaterialRequest request,
        IRawMaterialQueries queries)
    {
        return await queries.ListAsync(request.Term);
    }
}
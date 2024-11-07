namespace Deiarts.Application.RawMaterials.List;

public class ListRawMaterialsEndpoint() : QueryEndpoint<ListRawMaterialsResponseItem[]>(
    Default.ListRawMaterialsResponseItemArray,
    allowAnonymous: true)
{
    internal static async Task<ListRawMaterialsResponseItem[]> ExecuteAsync(IRawMaterialQueries queries)
    {
        return await queries.ListAsync();
    }
}
namespace Deiarts.Prototype.Application.Shared.Materials;

public class EditorMaterialRequest
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public decimal PricePerUnit { get; set; }
}
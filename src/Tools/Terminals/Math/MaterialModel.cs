namespace Deiarts.Tools.Terminals.MathBudget;

public readonly record struct MaterialModel(
    int Id,
    string Name,
    string Description,
    decimal PricePerUnit, 
    int Amount);
namespace Deiarts.Tools.Terminals.MathBudget;

public class BudgetDetails
{
    public required int Id { get; init; }
    public required string Product { get; init; }
    public required int TimeServiceInMinutes { get; init; }
    public required int Amount { get; init; }
    public required MaterialModel[] Materials { get; init; }
    
    
    public decimal TotalService => TimeServiceInMinutes * Settings.ServicePerMinute * Amount;
    public decimal TotalMaterial => Materials.Sum(x => x.PricePerUnit * x.Amount);
    
    public decimal TotalItem => TotalService + TotalMaterial;
    public decimal Total => (TotalService + TotalMaterial) * Amount;
    
    public decimal TotalMin => Amount * (TotalItem + TotalItem / 2);
    public decimal TotalMax => Amount * TotalItem * 2;
    public decimal TotalMiddle => (TotalMin + TotalMax) / 2;
    
    public decimal TotalMinPerItem => TotalMin / Amount;
    public decimal TotalMaxPerItem => TotalMax / Amount;
    public decimal TotalMiddlePerItem => TotalMiddle / Amount;
}
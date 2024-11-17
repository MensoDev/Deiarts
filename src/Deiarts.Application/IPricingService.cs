namespace Deiarts.Application;

internal interface IPricingService
{
    Task<decimal> CalculatePriceAsync(ProductId productId, int quantity);
}
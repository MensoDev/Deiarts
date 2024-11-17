using Deiarts.Domain.Enums;

namespace Deiarts.Application.Quotations.List;

public class ListQuotationsResponseItem
{
    public required QuotationId Id { get; init; }
    
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required decimal Price { get; init; }
    
    public required QuotationStatus Status { get; init; }
    public required DateTimeOffset? ValidUntil { get; init; }
    
    public required string CustomerName { get; init; }
    public required string CustomerEmail { get; init; }
    
}
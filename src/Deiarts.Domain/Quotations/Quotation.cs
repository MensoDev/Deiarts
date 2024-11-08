using Deiarts.Domain.Enums;

namespace Deiarts.Domain.Quotations;

[HasPrivateEmptyConstructor]
internal partial class Quotation : Entity<QuotationId>, IAggregateRoot
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    
    public QuotationStatus Status { get; private set; }
    
    public decimal? Price { get; private set; }
}
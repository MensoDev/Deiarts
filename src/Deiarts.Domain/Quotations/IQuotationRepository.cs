namespace Deiarts.Domain.Quotations;

internal interface IQuotationRepository
{
    Task<Quotation?> GetAsync(QuotationId id);
    void Add(Quotation quotation);
}
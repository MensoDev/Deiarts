namespace Deiarts.Application.Quotations.Create;

public class CreateQuotationRequest
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public CustomerId? CustomerId { get; set; }
}
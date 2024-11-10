using System.ComponentModel.DataAnnotations;

namespace Deiarts.Domain.Enums;

public enum QuotationStatus
{
    [Display(Name = "Em Rascunho")]
    Draft = 1,
    
    [Display(Name = "Enviada/Em Análise")]
    Sent = 11,
    
    [Display(Name = "Aprovada/Em Produção")]
    Approve = 21,
    
    [Display(Name = "Rejeitada")]
    Rejected = 31,
    
    [Display(Name = "Cancelada")]
    Canceled = 41
}
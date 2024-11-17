using Deiarts.Domain.Quotations;

namespace Deiarts.Infrastructure.Repositories;

internal class QuotationRepository(DeiartsDbContext db) : BaseRepository<Quotation, QuotationId>(db), IQuotationRepository;
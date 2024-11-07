global using StronglyTypedIds;
global using Cblx.Blocks;
global using Deiarts.Common.Domain.Entities;
using System.Runtime.CompilerServices;


[assembly: StronglyTypedIdDefaults(Template.Guid, "guid-efcore")]

[assembly: InternalsVisibleTo("Deiarts.Application")]
[assembly: InternalsVisibleTo("Deiarts.Infrastructure")]
[assembly: InternalsVisibleTo("Deiarts.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
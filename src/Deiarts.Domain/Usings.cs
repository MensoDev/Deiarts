global using StronglyTypedIds;
using System.Runtime.CompilerServices;


[assembly: StronglyTypedIdDefaults(Template.Guid, "guid-efcore")]

[assembly: InternalsVisibleTo("Deiarts.Application")]
[assembly: InternalsVisibleTo("Deiarts.Infrastructure")]
[assembly: InternalsVisibleTo("Deiarts.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
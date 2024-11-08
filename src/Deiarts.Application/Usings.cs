global using Deiarts.Common.Application.Endpoints;
global using Deiarts.Common.Application;
global using Deiarts.Domain;
global using FluentValidation;
global using Menso.Tools.Exceptions;
global using Microsoft.AspNetCore.Http;

global using static Deiarts.Application.DeiartsSerializationContext;

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Deiarts.Infrastructure")]
[assembly: InternalsVisibleTo("Deiarts.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
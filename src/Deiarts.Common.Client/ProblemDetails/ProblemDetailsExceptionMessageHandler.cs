using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace Deiarts.Common.Client.ProblemDetails;

public class ProblemDetailsExceptionMessageHandler(NavigationManager navigationManager) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var httpResponseMessage = await base.SendAsync(request, cancellationToken);

        if (httpResponseMessage.StatusCode == HttpStatusCode.OK) return httpResponseMessage;

        if (httpResponseMessage.Content.Headers.ContentType?.MediaType == "application/problem+json")
        {
            var problemDetailsException = await httpResponseMessage
                .Content
                .ReadFromJsonAsync(Default.ProblemDetailsException, cancellationToken: cancellationToken);
            
            throw problemDetailsException!;
        }

        var title = httpResponseMessage.StatusCode switch
        {
            HttpStatusCode.Unauthorized => "É necessário autenticar para realizar esta operação",
            HttpStatusCode.BadRequest => "Operação inválida",
            HttpStatusCode.Forbidden => "Sem permissão para realizar esta operação",
            HttpStatusCode.NotFound => "A operação solicitada não existe",
            _ => "Ocorreu um erro inesperado"
        };
        
        var detail = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
        detail = string.IsNullOrEmpty(detail) ? "Nehum detalhe adicional sobre o erro." : detail;
        
        // Se chamou uma API sem ter autorização, redireciona para a tela de login
        if (httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized)
        {
            if (navigationManager.Uri.Contains("login")) { return httpResponseMessage; }
            navigationManager.NavigateTo("/login", forceLoad: true);
            return httpResponseMessage;
        }
        
        throw new ProblemDetailsException("0", title, httpResponseMessage.StatusCode, detail, null);
    }
}

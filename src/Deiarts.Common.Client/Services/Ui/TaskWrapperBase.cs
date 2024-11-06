using System.Text;
using Deiarts.Common.Client.ProblemDetails;
using Microsoft.AspNetCore.Components;

namespace Deiarts.Common.Client.Services.Ui;

internal abstract class TaskWrapperBase<TChild>(IUiUtils ui) : ITaskWrapperBase<TChild> where TChild : class, ITaskWrapperBase<TChild>
{
    private bool _showError;
    private string? _errorMessage;
    private bool _showSuccess;
    private string? _successMessage;
    private bool _showBusy;
    private string? _busyMessage;

    public TChild ShowBusy(string? busyMessage = null)
    {
        _showBusy = true;
        _busyMessage = busyMessage;
        return (this as TChild)!;
    }

    public TChild ShowSuccess(string? successMessage = null)
    {
        _showSuccess = true;
        _successMessage = successMessage;
        return (this as TChild)!;
    }

    public TChild ShowError(string? errorMessage = null)
    {
        _showError = true;
        _errorMessage = errorMessage;
        return (this as TChild)!;
    }

    protected async Task<TValue> ExecuteCore<TValue>(Func<Task<TValue>> func)
    {
        try
        {
            if (_showBusy)
            {
                await ui.ShowBusyAsync(_busyMessage ?? "Carregando...");
            }
            var value = await func();
            if (_showSuccess)
            {
                await ui.NotifySuccessAsync(_successMessage ?? "Operação realizada com sucesso.");
                
            }
            return value;
        }
        catch (ProblemDetailsException ex)
        {
            await HandleProblemDetailsException(ex);
            throw;
        }
        catch (Exception ex)
        {
            await HandleException(ex);
            throw;
        }
        finally
        {
            if (_showBusy)
            {
                await ui.HideBusyAsync();
            }
        }
    }

    private async Task HandleProblemDetailsException(ProblemDetailsException ex)
    {
        if (_showError)
        {
            var title = ex.Title.Replace("One or more validation errors occurred.", "Por favor, revise as informações enviadas.");
            var sb = new StringBuilder("<div>");
            if(ex.Errors is null)
            {
                sb.AppendLine($"<p>{ex.Detail ?? ex.Title}</p>");
            }
            else
            {
                foreach (var error in ex.Errors.SelectMany(err => err.Value))
                {
                    sb.AppendLine($"<p>{error}</p>");
                }
            }
            sb.AppendLine("</div>");
            await ui.ShowErrorAsync(new MarkupString(sb.ToString()), title);
        }
    }

    private async Task HandleException(Exception ex)
    {
        if (_showError)
        {
            await ui.ShowErrorAsync(_errorMessage ?? ex.Message, "Erro");
        }
    }
}
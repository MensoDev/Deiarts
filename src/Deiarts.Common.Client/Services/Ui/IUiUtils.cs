using Microsoft.AspNetCore.Components;

namespace Deiarts.Common.Client.Services.Ui;
public interface IUiUtils
{
    internal event Action OnBusyChanged;
    internal bool IsBusy { get; }
    internal string BusyMessage { get; }
    Task<bool> ConfirmAsync(string message);
    Task ShowBusyAsync(string message = "Por favor, aguarde...");
    Task HideBusyAsync();
    Task NotifyWarningAsync(string message);
    Task NotifySuccessAsync(string message);
    ITaskWrapper Wrap(Task task);
    ITaskWrapper<T> Wrap<T>(Task<T> task);
    Task ShowErrorAsync(string message, string title);
    Task ShowErrorAsync(MarkupString markupMessage, string title);
}

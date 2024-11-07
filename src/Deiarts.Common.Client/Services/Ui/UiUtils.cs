using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Deiarts.Common.Client.Services.Ui;

public class UiUtils(IDialogService dialogService, ISnackbar snackbar) : IUiUtils
{
    public event Action? OnBusyChanged;
    public bool IsBusy { get; private set; }
    public string BusyMessage { get; private set; } = string.Empty;

    public async Task<bool> ConfirmAsync(string message)
    {
        var result = await dialogService.ShowMessageBox(
            "Confirmação",
            message,
            yesText: "Sim",
            noText: "Não");

        return result is true;
    }

    public async Task ShowErrorAsync(string message, string title)
    {
        await dialogService.ShowMessageBox(title, message);
    }

    public async Task ShowErrorAsync(MarkupString markupMessage, string title)
    {
        await dialogService.ShowMessageBox(title, markupMessage);
    }

    public async Task NotifySuccessAsync(string message)
    {
        snackbar.Add(message, severity: Severity.Success);
        await Task.CompletedTask;
    }

    public async Task NotifyWarningAsync(string message)
    {
        snackbar.Add(message, severity: Severity.Warning);
        await Task.CompletedTask;
    }

    public async Task ShowBusyAsync(string message = "Por favor, aguarde...")
    {
        await Task.CompletedTask;
        BusyMessage = message;
        IsBusy = true;
        OnBusyChanged?.Invoke();
    }

    public async Task HideBusyAsync()
    {
        await Task.CompletedTask;
        IsBusy = false;
        OnBusyChanged?.Invoke();
    }

    public ITaskWrapper Wrap(Task task) => new TaskWrapper(task, this);
    public ITaskWrapper<T> Wrap<T>(Task<T> task) => new TaskWrapper<T>(task, this);
}
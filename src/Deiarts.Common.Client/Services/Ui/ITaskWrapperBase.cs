namespace Deiarts.Common.Client.Services.Ui;

public interface ITaskWrapperBase<out TChild> where TChild : ITaskWrapperBase<TChild>
{
    TChild ShowBusy(string? busyMessage = null);
    TChild ShowError(string? errorMessage = null);
    TChild ShowSuccess(string? successMessage = null);
}
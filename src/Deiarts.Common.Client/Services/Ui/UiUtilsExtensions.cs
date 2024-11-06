namespace Deiarts.Common.Client.Services.Ui;

public static class UiUtilsExtensions
{
    public static ITaskWrapper<T> Use<T>(this Task<T> task, IUiUtils utils) => utils.Wrap(task);
    public static ITaskWrapper Use(this Task task, IUiUtils utils) => utils.Wrap(task);
}
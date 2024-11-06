using System.Runtime.CompilerServices;

namespace Deiarts.Common.Client.Services.Ui;

public interface ITaskWrapper : ITaskWrapperBase<ITaskWrapper>
{
    TaskAwaiter GetAwaiter();
}

public interface ITaskWrapper<T> : ITaskWrapperBase<ITaskWrapper<T>>
{
    TaskAwaiter<T> GetAwaiter();
}

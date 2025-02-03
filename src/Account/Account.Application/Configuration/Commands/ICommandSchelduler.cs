using Account.Application.Contracts;

namespace Account.Application.Configuration.Commands;

public interface ICommandSchelduler
{
    Task EnqueueAsync(ICommand command);
    Task EnqueueAsync<T>(ICommand<T> command);
}
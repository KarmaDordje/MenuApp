using MediatR;

namespace Account.Application.Contracts;

public interface IQuery<out TResult> : IRequest<TResult>
{
    
}
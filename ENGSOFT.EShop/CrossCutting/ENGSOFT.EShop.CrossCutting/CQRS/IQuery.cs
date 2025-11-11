using MediatR;

namespace ENGSOFT.EShop.CrossCutting.CQRS
{
    public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull
    {

    }
}

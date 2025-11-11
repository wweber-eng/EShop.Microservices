using MediatR;

namespace ENGSOFT.EShop.CrossCutting.CQRS
{

    public interface ICommand : ICommand<Unit>{}
    
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {

    }
}

using MediatR;

namespace MechanicShop.Application.Common.Interfaces;

public interface ICachesQuery
{
    string CacheKey { get; }
    string[] Tags { get; }

    TimeSpan Expiration { get; }
}

public interface ICachesQuery<TResponse> : IRequest<TResponse>, ICachesQuery
{
}
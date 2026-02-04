using System.Security;
using MechanicShop.Application.Common.Interfaces;
using MechanicShop.Domain.Common.Results;
using MediatR;

using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Logging;
namespace MechanicShop.Application.Common.Behaviours;

public class CachingBehavior<TRequest, TResponse>(
    HybridCache cache,
    ILogger<CachingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public HybridCache _cache { get; } = cache;
    public ILogger<CachingBehavior<TRequest, TResponse>> _logger { get; } = logger;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if(request is not ICachesQuery<TResponse> cacheableRequest)
        {
            _logger.LogInformation("Request {RequestType} is not cacheable. Proceeding without caching.", typeof(TRequest).Name);
            return await next(cancellationToken);
        }
        _logger.LogInformation("Handling cacheable request {RequestType} with cache key {CacheKey}.", typeof(TRequest).Name, cacheableRequest.CacheKey);

        var result = await _cache.GetOrCreateAsync(key: cacheableRequest.CacheKey, factory: async ct =>
        {
            var innerResult = await next(ct);
            if(innerResult is IResult r && r.IsSuccess)
            {
                return innerResult;
            }
            
            return default!; // Do not cache errors (failures)
        },
        options: new HybridCacheEntryOptions
        {
            Expiration = cacheableRequest.Expiration
        },
        tags: cacheableRequest.Tags,
        cancellationToken: cancellationToken);

        return result;

    }
}
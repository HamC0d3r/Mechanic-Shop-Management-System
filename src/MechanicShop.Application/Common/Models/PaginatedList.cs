namespace MechanicShop.Application.Common.Models;

public class PaginatedList<T>
{
    public IReadOnlyCollection<T> Items { get; init; }
    public int TotalCount { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }

    public PaginatedList(List<T> items, int totalCount, int pageIndex, int pageSize)
    {
        Items = items;
        TotalCount = totalCount;
        PageIndex = pageIndex;
        PageSize = pageSize;
    }
}
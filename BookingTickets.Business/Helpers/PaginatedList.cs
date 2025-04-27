namespace BookingTickets.Business.Helpers;

public class PaginatedList<T> : List<T>
{
    public int PageCount { get; private set; }
    public int CurrentPage { get; private set; }
    public bool HasNext => CurrentPage < PageCount;
    public bool HasPrevious => CurrentPage > 1;
    public int Start { get; private set; }
    public int End { get; private set; }

    private PaginatedList(List<T> items, int pageCount, int currentPage)
    {
        this.AddRange(items);
        PageCount = pageCount;
        CurrentPage = currentPage;
        SetPageRange();
    }

    private void SetPageRange()
    {
        int range = 2;  
        int start = Math.Max(1, CurrentPage - range);
        int end = Math.Min(PageCount, CurrentPage + range);

       
        if (end - start < range * 2)
        {
            start = Math.Max(1, end - range * 2);
        }

        Start = start;
        End = end;
    }

    public static PaginatedList<T> Create(IQueryable<T> query, int page, int pageSize)
    {
        int totalCount = query.Count();
        var pageCount = (int)Math.Ceiling((double)totalCount / pageSize);

        page = Math.Max(1, Math.Min(page, pageCount));

        var items = query.Skip((page - 1) * pageSize)
                         .Take(pageSize)
                         .ToList();

        return new PaginatedList<T>(items, pageCount, page);
    }
}

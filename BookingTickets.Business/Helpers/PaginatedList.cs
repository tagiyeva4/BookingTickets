namespace BookingTickets.Business.Helpers;

public class PaginatedList<T> : List<T>
{
    public int PageCount { get; private set; }
    public int CurrentPage { get; private set; }
    public bool HasNext => CurrentPage < PageCount;
    public bool HasPrevious => CurrentPage > 1;
    public int Start { get; private set; }
    public int End { get; private set; }

    // Constructor
    private PaginatedList(List<T> items, int pageCount, int currentPage)
    {
        this.AddRange(items);
        PageCount = pageCount;
        CurrentPage = currentPage;
        SetPageRange();
    }

    // Sets the page range for pagination controls
    private void SetPageRange()
    {
        int range = 2;  // This defines how many page links to show
        int start = Math.Max(1, CurrentPage - range);
        int end = Math.Min(PageCount, CurrentPage + range);

        // Adjust if the current page is near the beginning or end
        if (end - start < range * 2)
        {
            start = Math.Max(1, end - range * 2);
        }

        Start = start;
        End = end;
    }

    // Factory method to create PaginatedList
    public static PaginatedList<T> Create(IQueryable<T> query, int page, int pageSize)
    {
        int totalCount = query.Count();
        var pageCount = (int)Math.Ceiling((double)totalCount / pageSize);

        // Ensure that page is within bounds
        page = Math.Max(1, Math.Min(page, pageCount));

        var items = query.Skip((page - 1) * pageSize)
                         .Take(pageSize)
                         .ToList();

        return new PaginatedList<T>(items, pageCount, page);
    }
}

namespace DriveLog.WebAPI.Models.Pagination;

/// <summary>
/// Generic paginated response containing data and pagination metadata.
/// </summary>
/// <typeparam name="T">Type of items in the response.</typeparam>
public record PaginatedResponse<T> {
    /// <summary>
    /// Collection of items for the current page.
    /// </summary>
    public IReadOnlyList<T> Data { get; init; } = [];

    /// <summary>
    /// Total count of items before pagination.
    /// </summary>
    public int Total { get; init; }
}

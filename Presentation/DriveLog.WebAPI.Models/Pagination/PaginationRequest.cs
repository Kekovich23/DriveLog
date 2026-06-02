namespace DriveLog.WebAPI.Models.Pagination;

/// <summary>
/// Pagination request parameters.
/// </summary>
public record PaginationRequest {
    /// <summary>
    /// Number of records to skip (default: 0).
    /// </summary>
    public int Skip { get; init; } = 0;

    /// <summary>
    /// Number of records to take (default: 10, max: 100).
    /// </summary>
    public int Take { get; init; } = 10;

    /// <summary>
    /// Validates pagination parameters and returns corrected values.
    /// </summary>
    public PaginationRequest Validate() => new() { Skip = Skip < 0 ? 0 : Skip, Take = Take < 1 ? 10 : Take > 100 ? 100 : Take };
}

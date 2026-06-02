namespace DriveLog.Application.Models.Pagination;

public record PaginatedResponse<T>(IReadOnlyList<T> Data, int Total);
namespace DriveLog.Application.Models.Pagination;

public record PaginationRequest(int Skip = 0, int Take = 10) {
    public PaginationRequest Validate() => new(Skip < 0 ? 0 : Skip, Take < 1 ? 10 : Take > 100 ? 100 : Take);
}

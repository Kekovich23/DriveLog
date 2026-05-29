namespace DriveLog.Domain.Entities.Base;

public abstract class AggregateEntity<T> : BaseEntity<T> where T : notnull;

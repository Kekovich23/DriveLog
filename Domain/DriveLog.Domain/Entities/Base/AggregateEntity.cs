namespace DriveLog.Domain.Entities.Base;

public abstract class AggregateEntity<T> : BaseEntity<T> where T : notnull {
    public AggregateEntity(T id) : base(id) { }

    public AggregateEntity() : base() { }
}
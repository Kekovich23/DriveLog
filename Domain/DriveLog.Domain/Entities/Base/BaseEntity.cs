namespace DriveLog.Domain.Entities.Base;

public abstract class BaseEntity<T> where T : notnull {
    public T Id { get; set; }

    public BaseEntity(T id) => Id = id;

    public BaseEntity() => Id = default!;
}

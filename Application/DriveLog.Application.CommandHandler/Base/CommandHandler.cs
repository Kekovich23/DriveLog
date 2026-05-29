namespace DriveLog.Application.CommandHandler.Base;

public interface ICommandHandler<T> {
    Task HandleAsync(T command, CancellationToken cancellationToken = default);
}

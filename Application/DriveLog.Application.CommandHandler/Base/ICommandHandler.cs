namespace DriveLog.Application.CommandHandler.Base;

public interface ICommandHandler<T> {
    Task HandleAsync(T command, CancellationToken cancellationToken = default);
}

public interface ICommandHandler<TIn, TOut> {
    Task<TOut> HandleAsync(TIn command, CancellationToken cancellationToken = default);
}

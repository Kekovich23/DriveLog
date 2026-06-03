using DriveLog.Application.Models.Base;

namespace DriveLog.Application.Models.Car;

public record CarModel(Guid Id, int Number) : IModel<Guid>;

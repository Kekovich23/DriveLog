using DriveLog.Application.Models.Base;

namespace DriveLog.Application.Models.Driver;

public record DriverModel(Guid Id, string FirstName, string LastName, int Number) : IModel<Guid>;

using DriveLog.Application.Models.Base;

namespace DriveLog.Application.Models.Driver;

public record DriverCreateModel(string FirstName, string LastName, int Number) : ICreateModel;
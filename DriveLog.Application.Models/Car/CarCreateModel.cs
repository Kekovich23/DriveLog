using DriveLog.Application.Models.Base;

namespace DriveLog.Application.Models.Car;

public record CarCreateModel(int Number) : ICreateModel;

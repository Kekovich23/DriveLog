using DriveLog.ValueObjects.Exceptions.Base;

namespace DriveLog.ValueObjects.Exceptions;

public class DriverNotRegisteredException(Guid driverId, Guid raceId) : DomainException($"Driver {driverId} is not registered for race {raceId}.");

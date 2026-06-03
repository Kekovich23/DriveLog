using DriveLog.ValueObjects.Exceptions.Base;

namespace DriveLog.ValueObjects.Exceptions;

public class DriverAlreadyRegisteredException(Guid driverId, Guid raceId) : DomainException($"Driver {driverId} is already registered for race {raceId}.");

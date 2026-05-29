using DriveLog.ValueObjects.Exceptions.Base;

namespace DriveLog.ValueObjects.Exceptions;

public class CarAlreadyRegisteredException(Guid carId, Guid raceId) : DomainException($"Car {carId} is already registered for race {raceId}.") {
}
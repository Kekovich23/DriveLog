using DriveLog.Domain.Entities.Base;

namespace DriveLog.Domain.Entities;

public class RaceLap(Race race, Driver driver, Car car, int lapNumber, TimeSpan lapTime) : BaseEntity<Guid> {
    public Guid RaceId { get; private set; } = race.Id;
    public int LapNumber { get; private set; } = lapNumber;
    public TimeSpan LapTime { get; private set; } = lapTime;
    public Guid DriverId { get; private set; } = driver.Id;
    public Guid CarId { get; private set; } = car.Id;

    public Race Race { get; private set; } = race;
    public Driver Driver { get; private set; } = driver;
    public Car Car { get; private set; } = car;
}

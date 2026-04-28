using DriveLog.Domain.Entities.Base;

namespace DriveLog.Domain.Entities;

public class RaceLap : BaseEntity<Guid> {
    public RaceLap(Race race, Driver driver, Car car, int lapNumber, TimeSpan lapTime) {
        RaceId = race.Id;
        LapNumber = lapNumber;
        LapTime = lapTime;
        DriverId = driver.Id;
        CarId = car.Id;
        Race = race;
        Driver = driver;
        Car = car;
    }

    protected RaceLap() { }

    public Guid RaceId { get; private set; }
    public int LapNumber { get; private set; }
    public TimeSpan LapTime { get; private set; }
    public Guid DriverId { get; private set; }
    public Guid CarId { get; private set; }

    public Race Race { get; private set; } = null!;
    public Driver Driver { get; private set; } = null!;
    public Car Car { get; private set; } = null!;
}

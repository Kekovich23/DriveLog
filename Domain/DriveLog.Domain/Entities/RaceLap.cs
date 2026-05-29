using DriveLog.Domain.Entities.Base;

namespace DriveLog.Domain.Entities;

public class RaceLap : BaseEntity<Guid> {
    public RaceLap(Guid raceId, Guid driverId, Guid carId, int lapNumber, TimeSpan lapTime) {
        RaceId = raceId;
        LapNumber = lapNumber;
        LapTime = lapTime;
        DriverId = driverId;
        CarId = carId;
    }

    protected RaceLap() { }

    public Guid RaceId { get; private set; }
    public int LapNumber { get; private set; }
    public TimeSpan LapTime { get; private set; }
    public Guid DriverId { get; private set; }
    public Guid CarId { get; private set; }
    public Race? Race { get; private set; }
    public Driver? Driver { get; private set; }
    public Car? Car { get; private set; }

    public void ChangeRace(Guid raceId) => RaceId = raceId;
    public void ChangeLapNumber(int lapNumber) => LapNumber = lapNumber;
    public void ChangeLapTime(TimeSpan lapTime) => LapTime = lapTime;
    public void ChangeDriver(Guid driverId) => DriverId = driverId;
    public void ChangeCar(Guid carId) => CarId = carId;
}

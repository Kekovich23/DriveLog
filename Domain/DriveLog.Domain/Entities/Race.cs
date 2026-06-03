using DriveLog.Domain.Entities.Base;
using DriveLog.Domain.Enums;
using DriveLog.ValueObjects;
using DriveLog.ValueObjects.Exceptions;

namespace DriveLog.Domain.Entities;

public class Race : AggregateEntity<Guid> {
    public Race(Guid id, Guid trackId, RaceDate date) : base(id) {
        TrackId = trackId;
        Date = date;
    }

    protected Race() { }

    public Guid TrackId { get; private set; }
    public RaceStatus Status { get; private set; } = RaceStatus.Created;
    public DateTimeOffset? ActualStartTime { get; private set; }
    public DateTimeOffset? ActualEndTime { get; private set; }
    public RaceDate Date { get; private set; } = null!;

    private readonly List<RaceEntry> _entries = [];
    public IReadOnlyCollection<RaceEntry> Entries => _entries.AsReadOnly();

    public void RegisterDriver(Guid driverId, Guid carId) {
        if (Status != RaceStatus.Created) {
            throw new InvalidOperationException("Cannot register driver for a race that is not in created status.");
        }

        if (_entries.Any(x => x.DriverId == driverId)) {
            throw new DriverAlreadyRegisteredException(driverId, Id);
        }

        if (_entries.Any(x => x.CarId == carId)) {
            throw new CarAlreadyRegisteredException(carId, Id);
        }

        _entries.Add(new RaceEntry(Guid.CreateVersion7(), driverId, carId));
    }

    public void StartRace(DateTimeOffset startTime) {
        if (Status != RaceStatus.Created) {
            throw new InvalidOperationException("Cannot start a race that is not in created status.");
        }

        if (_entries.Count == 0) {
            throw new InvalidOperationException("Cannot start a race with no registered drivers.");
        }

        Status = RaceStatus.InProgress;
        ActualStartTime = startTime;
    }

    public void FinishRace(DateTimeOffset endTime) {
        if (Status != RaceStatus.InProgress) {
            throw new InvalidOperationException("Cannot finish a race that is not in progress.");
        }

        Status = RaceStatus.Finished;
        ActualEndTime = endTime;
    }

    public void RecordLapTime(Guid driverId, LapTime time) {
        if (Status != RaceStatus.InProgress) {
            throw new InvalidOperationException("Cannot record lap time for a race that is not in progress.");
        }

        var entry = _entries.FirstOrDefault(x => x.DriverId == driverId) ?? throw new DriverNotRegisteredException(driverId, Id);

        entry.AddLap(time);
    }
}

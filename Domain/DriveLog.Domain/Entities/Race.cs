using DriveLog.Domain.Entities.Base;
using DriveLog.Domain.Enums;
using DriveLog.ValueObjects;
using DriveLog.ValueObjects.Exceptions;

namespace DriveLog.Domain.Entities;

public class Race : AggregateEntity<Guid> {
    public Race(Guid id, Track track, RaceDate date) {
        Id = id;
        Track = track;
        Date = date;
    }

    protected Race() { }

    public Track Track { get; private set; } = null!;
    public RaceStatus Status { get; private set; } = RaceStatus.Created;
    public DateTimeOffset? ActualStartTime { get; private set; }
    public DateTimeOffset? ActualEndTime { get; private set; }
    public RaceDate Date { get; private set; } = null!;

    private readonly List<RaceEntry> _entries = [];
    public IReadOnlyCollection<RaceEntry> Entries => _entries.AsReadOnly();

    public void RegisterDriver(Driver driver, Car car) {
        if (Status != RaceStatus.Created) {
            throw new InvalidOperationException("Cannot register driver for a race that is not in created status.");
        }

        if (_entries.Any(x => x.Driver.Id == driver.Id)) {
            throw new DriverAlreadyRegisteredException(driver.Id, Id);
        }

        if (_entries.Any(x => x.Car.Id == car.Id)) {
            throw new CarAlreadyRegisteredException(car.Id, Id);
        }

        _entries.Add(new RaceEntry(Guid.CreateVersion7(), driver, car, this));
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

    public void RecordLapTime(Driver driver, LapTime time) {
        if (Status != RaceStatus.InProgress) {
            throw new InvalidOperationException("Cannot record lap time for a race that is not in progress.");
        }

        var entry = _entries.FirstOrDefault(x => x.Driver.Id == driver.Id) ?? throw new DriverNotRegisteredException(driver.Id, Id);

        entry.AddLap(time);
    }
}

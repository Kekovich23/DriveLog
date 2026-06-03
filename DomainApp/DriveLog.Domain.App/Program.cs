using DriveLog.Domain.Entities;

var driver = new Driver(Guid.CreateVersion7(), new("John", "Doe"), new(23));
Console.WriteLine("Created driver " + driver.Name);
var car = new Car(Guid.CreateVersion7(), new(5));
Console.WriteLine("Created car " + car.Number.Value);
var track = new Track(Guid.CreateVersion7(), new("Silverstone"));
Console.WriteLine("Created track " + track.Name.Value);

var race = new Race(Guid.CreateVersion7(), track.Id, new(DateTimeOffset.UtcNow));
Console.WriteLine($"Created race for track \"{track.Name.Value}\" at {race.Date:d}");

Console.WriteLine();

var rnd = new Random();

race.RegisterDriver(driver.Id, car.Id);
race.StartRace(DateTimeOffset.Now);

for (var i = 0; i < 3; i++) {
    race.RecordLapTime(driver.Id, new(TimeSpan.FromMilliseconds(90000 + rnd.Next(30000))));
    var raceLap = race.Entries.First(e => e.DriverId == driver.Id).Laps.Last();
    Console.WriteLine($"Driver \"{driver.Number.Value} {driver.Name}\"" +
        $" on car \"{car.Number.Value}\" completed lap {raceLap.Id.Value}" +
        $" in {raceLap.Time.Duration:g}");
}

race.FinishRace(DateTimeOffset.Now);

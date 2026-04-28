using DriveLog.Domain.Entities;

var driver = new Driver("John", "Doe", 23);
Console.WriteLine("Created driver " + driver.FullName);
var car = new Car(5);
Console.WriteLine("Created car " + car.Number.Value);
var track = new Track("Silverstone");
Console.WriteLine("Created track " + track.Name.Value);

var race = new Race(track, DateTime.UtcNow);
Console.WriteLine($"Created race for track \"{race.Track.Name.Value}\" at {race.Date:d}");

Console.WriteLine();

var rnd = new Random();
for (var i = 0; i < 3; i++) {
    var raceLap = new RaceLap(race, driver, car, i + 1, TimeSpan.FromMilliseconds(90000 + rnd.Next(30000)));
    Console.WriteLine($"Driver \"{raceLap.Driver.Number.Value} {raceLap.Driver.FullName}\"" +
        $" on car \"{car.Number.Value}\" completed lap {raceLap.LapNumber}" +
        $"in {raceLap.LapTime:g}");
}
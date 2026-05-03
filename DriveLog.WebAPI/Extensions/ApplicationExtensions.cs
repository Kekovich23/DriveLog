using DriveLog.Application.Services;
using DriveLog.Application.Services.Contracts;
using DriveLog.Domain.Contracts;
using DriveLog.Domain.Contracts.Repositories;
using DriveLog.Infrastructure;
using DriveLog.Infrastructure.Repositories;
using DriveLog.WebAPI.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DriveLog.WebAPI.Extensions;

public static class ApplicationExtensions {
    public static void AddApplicationServices(this WebApplicationBuilder builder) {
        builder.Services.AddDbContext<DriveLogDbContext>(opt => {
            opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));

            if (builder.Environment.IsDevelopment()) {
                opt.EnableSensitiveDataLogging();
                opt.EnableDetailedErrors();
            }
        });

        builder.Services.AddScoped<IUnitOfWork, DriveLogDbContext>();

        builder.Services.AddScoped<ICarRepository, CarRepository>();
        builder.Services.AddScoped<IDriverRepository, DriverRepository>();
        builder.Services.AddScoped<IRaceRepository, RaceRepository>();
        builder.Services.AddScoped<ITrackRepository, TrackRepository>();
        builder.Services.AddScoped<IRaceLapRepository, RaceLapRepository>();

        builder.Services.AddScoped<ICarApplicationService, CarApplicationService>();
        builder.Services.AddScoped<IDriverApplicationService, DriverApplicationService>();
        builder.Services.AddScoped<IRaceApplicationService, RaceApplicationService>();
        builder.Services.AddScoped<ITrackApplicationService, TrackApplicationService>();
        builder.Services.AddScoped<IRaceLapApplicationService, RaceLapApplicationService>();

        builder.Services.AddAutoMapper(config => config.AddProfile<ApplicationProfile>());
    }
}

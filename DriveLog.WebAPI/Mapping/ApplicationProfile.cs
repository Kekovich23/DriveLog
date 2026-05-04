using AutoMapper;
using DriveLog.Application.Models.Car;
using DriveLog.Application.Models.Driver;
using DriveLog.Application.Models.Race;
using DriveLog.Application.Models.RaceLap;
using DriveLog.Application.Models.Track;
using DriveLog.Domain.Entities;
using DriveLog.WebAPI.Models.Requests;
using DriveLog.WebAPI.Models.Responses;

namespace DriveLog.WebAPI.Mapping;

public class ApplicationProfile : Profile {
    public ApplicationProfile() {
        CreateMap<Car, CarModel>()
            .ForCtorParam(nameof(CarModel.Number), opt => opt.MapFrom(src => src.Number.Value));

        CreateMap<Driver, DriverModel>()
            .ForCtorParam(nameof(DriverModel.FirstName), opt => opt.MapFrom(src => src.FullName.FirstName))
            .ForCtorParam(nameof(DriverModel.LastName), opt => opt.MapFrom(src => src.FullName.LastName))
            .ForCtorParam(nameof(DriverModel.Number), opt => opt.MapFrom(src => src.Number.Value));

        CreateMap<Race, RaceModel>();
        CreateMap<RaceLap, RaceLapModel>();
        CreateMap<Track, TrackModel>()
            .ForCtorParam(nameof(TrackModel.Name), opt => opt.MapFrom(src => src.Name.Value));

        CreateMap<CarRequestModel, CarModel>();
        CreateMap<DriverRequestModel, DriverModel>();
        CreateMap<RaceRequestModel, RaceModel>();
        CreateMap<RaceLapRequestModel, RaceLapModel>();
        CreateMap<TrackRequestModel, TrackModel>();

        CreateMap<CarRequestModel, CarCreateModel>();
        CreateMap<DriverRequestModel, DriverCreateModel>();
        CreateMap<RaceRequestModel, RaceCreateModel>();
        CreateMap<RaceLapRequestModel, RaceLapCreateModel>();
        CreateMap<TrackRequestModel, TrackCreateModel>();

        CreateMap<CarModel, CarResponseModel>();
        CreateMap<DriverModel, DriverResponseModel>();
        CreateMap<RaceModel, RaceResponseModel>();
        CreateMap<RaceLapModel, RaceLapResponseModel>();
        CreateMap<TrackModel, TrackResponseModel>();
    }
}

using AutoMapper;
using Google.Protobuf.Collections;
using System.Globalization;
using System;
using WorkTimeTracker.Grpc.Entities;
using WorkTimeTracker.Grpc.Protos;

namespace WorkTimeTracker.Grpc.Mapper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CompletedShift, CompletedShiftGetModel>()
            .ForMember(d => d.StartTime, o => o.MapFrom(s => s.ShiftStart.ToString(CultureInfo.InvariantCulture)))
            .ForMember(d => d.EndTime, o => o.MapFrom(s => s.ShiftEnd.ToString(CultureInfo.InvariantCulture)))
            .ForMember(d => d.NumberOfHours, o => o.MapFrom(s => s.NumberOfHours));

        CreateMap<RepeatedField<CompletedShiftGetModel>, GetCompletedShiftsResponse>()
            .ForMember(d => d.CompletedShifts, o => o.MapFrom(s => s));

        CreateMap<CompletedShiftPostModel, CompletedShift>()
            .ForMember(d => d.ShiftStart, o => o.MapFrom(s => ConvertStringToDate(s.StartTime)))
            .ForMember(d => d.ShiftEnd, o => o.MapFrom(s => ConvertStringToDate(s.EndTime)));
    }

    private DateTime? ConvertStringToDate(string value)
    {
        return DateTime.TryParseExact
            (value, "yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'", 
                CultureInfo.InvariantCulture, DateTimeStyles.None, out var result) ?
                result : throw new ArgumentException("Wrong date format");
    }
}
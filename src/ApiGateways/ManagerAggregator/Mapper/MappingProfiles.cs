using System.Globalization;
using AutoMapper;
using Google.Protobuf.Collections;
using ManagerAggregator.Models;
using WorkTimeTracker.Grpc.Protos;

namespace ManagerAggregator.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CompletedShiftGetModel, CompletedShiftModel>()
                .ForMember(d => d.ShiftStart, o => o.MapFrom(s => ConvertStringToDate(s.StartTime)))
                .ForMember(d => d.ShiftEnd, o => o.MapFrom(s => ConvertStringToDate(s.EndTime)));
        }

        private DateTime? ConvertStringToDate(string value)
        {
            return DateTime.TryParseExact
            (value, "MM/dd/yyyy HH:mm:ss",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out var result) ?
                result : throw new ArgumentException("Wrong date format");
        }
    }
}

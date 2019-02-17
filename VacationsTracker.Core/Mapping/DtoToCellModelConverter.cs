using AutoMapper;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.DTO;
using VacationsTracker.Core.Presentation.ViewModels;

namespace VacationsTracker.Core.Mapping
{
    internal class DtoToCellModelConverter : ITypeConverter<VacationDto,VacationCellViewModel>
    {
        public VacationCellViewModel Convert(VacationDto source, VacationCellViewModel destination, ResolutionContext context)
        {
            var result = new VacationCellViewModel
            {
                Id = source.Id,
                Start = source.Start,
                End = source.End,
                Status = source.VacationStatus,
                Type = source.VacationType
            };

            return result;
        }
    }
}
using AutoMapper;
using VacationsTracker.Core.DTO;
using VacationsTracker.Core.Presentation.ViewModels;

namespace VacationsTracker.Core.Mapping
{
    internal class CellToDtoModelConverter : ITypeConverter<VacationCellViewModel,VacationDto>
    {
        public VacationDto Convert(VacationCellViewModel source,VacationDto destination, ResolutionContext context)
        {
            var result = new VacationDto
            {
                Id = source.Id,
                Start = source.Start,
                End = source.End,
                VacationStatus = source.Status,
                VacationType = source.Type,
                CreatedBy = string.Empty
            };

            return result;
        }
    }
}
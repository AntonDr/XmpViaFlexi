using System.Data;
using AutoMapper;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.DTO;
using VacationsTracker.Core.Presentation.ViewModels;

namespace VacationsTracker.Core.Mapping
{
    internal class VacationCellViewModelMappingProfile : Profile
    {
        public VacationCellViewModelMappingProfile()
        {
            CreateMap<VacationDto, Vacation>();

            CreateMap<Vacation, VacationDto>();

            CreateMap<VacationDto,VacationCellViewModel>()
                .ConvertUsing<DtoToCellModelConverter>();

            CreateMap<VacationCellViewModel,VacationDto>()
                .ConvertUsing<CellToDtoModelConverter>();
        }
    }
}

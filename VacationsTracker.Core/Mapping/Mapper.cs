using System;
using System.Collections.Generic;
using System.Text;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.DTO;
using VacationsTracker.Core.Presentation.ViewModels;

namespace VacationsTracker.Core.Mapping
{
    internal static class MappingExtension
    {
        public static Vacation ToVacationModel(this VacationDto vacationDto)
        {
            return AutoMapper.Mapper.Map<VacationDto, Vacation>(vacationDto);
        }

        public static VacationDto ToVacationDto(this Vacation vacationModel)
        {
            return AutoMapper.Mapper.Map<Vacation, VacationDto>(vacationModel);
        }

        public static VacationCellViewModel ToVacationCellViewModel(this VacationDto vacationDto)
        {
            return AutoMapper.Mapper.Map<VacationDto, VacationCellViewModel>(vacationDto);
        }

        public static VacationDto ToVacationDto(this VacationCellViewModel viewModel)
        {
            return AutoMapper.Mapper.Map<VacationCellViewModel, VacationDto>(viewModel);
        }
    }
}

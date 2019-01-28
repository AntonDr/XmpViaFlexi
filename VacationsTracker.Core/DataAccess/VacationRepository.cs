using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Presentation.ViewModels;

namespace VacationsTracker.Core.DataAccess
{
    public class VacationRepository : IVacationsRepository
    {
        private readonly Vacation[] _vacations =
        {
            new Vacation
            {
                Start = new DateTime(2019, 3, 20),
                End = new DateTime(2019, 3, 31),
                Status = VacationStatus.Approved,
                Type = VacationType.Regular
            },
            new Vacation
            {
                Start = new DateTime(2018, 12, 26),
                End = new DateTime(2018, 12, 30),
                Status = VacationStatus.Closed,
                Type = VacationType.Regular
            },
            new Vacation
            {
                Start = new DateTime(2018, 11, 2),
                End = new DateTime(2018, 11, 4),
                Status = VacationStatus.Closed,
                Type = VacationType.SickDays
            },
            new Vacation
            {
                Start = new DateTime(2018, 07, 11),
                End = new DateTime(2018, 07, 13),
                Status = VacationStatus.Closed,
                Type = VacationType.ExceptionalLeave
            },
            new Vacation
            {
                Start = new DateTime(2018, 02, 6),
                End = new DateTime(2018, 02, 7),
                Status = VacationStatus.Closed,
                Type = VacationType.Overtime
            }
        };

        public int Count => _vacations.Length;

        public Vacation this[int i] => _vacations[i];

        public Task<IEnumerable<VacationCellViewModel>> GetVacationsAsync()
        {
            return Task.FromResult<IEnumerable<VacationCellViewModel>>(new List<VacationCellViewModel>
            {
                new VacationCellViewModel
                {
                    StartDate = new DateTime(2019, 3, 20),
                    EndDate = new DateTime(2019, 3, 31),
                    Status = VacationStatus.Approved,
                    VacationType = VacationType.Regular
                },
                new VacationCellViewModel
                {
                    StartDate = new DateTime(2018, 12, 26),
                    EndDate = new DateTime(2018, 12, 30),
                    Status = VacationStatus.Closed,
                    VacationType = VacationType.ExceptionalLeave
                },
                new VacationCellViewModel
                {
                    StartDate = new DateTime(2018, 11, 2),
                    EndDate = new DateTime(2018, 11, 4),
                    Status = VacationStatus.Closed,
                    VacationType = VacationType.SickDays
                },
                new VacationCellViewModel
                {
                    StartDate = new DateTime(2018, 07, 11),
                    EndDate = new DateTime(2018, 07, 13),
                    Status = VacationStatus.Closed,
                    VacationType = VacationType.ExceptionalLeave
                },
                new VacationCellViewModel
                {
                    StartDate = new DateTime(2018, 02, 6),
                    EndDate = new DateTime(2018, 02, 8),
                    Status = VacationStatus.Closed,
                    VacationType = VacationType.Overtime
                },
                new VacationCellViewModel
                {
                    StartDate = new DateTime(2018, 10, 2),
                    EndDate = new DateTime(2018, 10, 4),
                    Status = VacationStatus.Closed,
                    VacationType = VacationType.SickDays
                },
                new VacationCellViewModel
                {
                    StartDate = new DateTime(2018, 11, 16),
                    EndDate = new DateTime(2018, 11, 19),
                    Status = VacationStatus.Closed,
                    VacationType = VacationType.Overtime
                },
                new VacationCellViewModel
                {
                    StartDate = new DateTime(2018, 12, 22),
                    EndDate = new DateTime(2018, 12, 24),
                    Status = VacationStatus.Closed,
                    VacationType = VacationType.SickDays
                },
                new VacationCellViewModel
                {
                    StartDate = new DateTime(2018, 12, 22),
                    EndDate = new DateTime(2018, 12, 23),
                    Status = VacationStatus.Approved,
                    VacationType = VacationType.SickDays
                },
                new VacationCellViewModel
                {
                    StartDate = new DateTime(2019, 3, 21),
                    EndDate = new DateTime(2019, 3, 25),
                    Status = VacationStatus.Closed,
                    VacationType = VacationType.ExceptionalLeave
                }
            });
        }
    }
}
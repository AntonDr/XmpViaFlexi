using System;

namespace VacationsTracker.Core.Domain
{
    public class Vacation
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public VacationStatus Status { get; set; }

        public VacationType Type { get; set; }
    }
}
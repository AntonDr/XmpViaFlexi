using System;

namespace VacationsTracker.Core.Domain
{
    public static class VacationStatusExtensions
    {
        public static string ToFriendlyString(this VacationStatus status)
        {
            switch (status)
            {
                case VacationStatus.Approved:
                    return "Approved";
                case VacationStatus.Closed:
                    return "Closed";
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }
        }
    }
}
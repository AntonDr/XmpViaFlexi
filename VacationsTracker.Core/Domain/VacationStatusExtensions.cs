using System;

namespace VacationsTracker.Core.Domain
{
    public static class VacationStatusExtensions
    {
        public static string ToFriendlyString(this VacationStatus status)
        {
            switch (status)
            {
                case VacationStatus.Pending:
                    return "Pending";
                case VacationStatus.Approved:
                    return "Approved";
                case VacationStatus.Rejected:
                    return "Rejected";
                case VacationStatus.Closed:
                    return "Closed";
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }
        }
    }
}
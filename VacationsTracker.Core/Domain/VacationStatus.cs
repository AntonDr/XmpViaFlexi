using System;

namespace VacationsTracker.Core.Domain
{
    public enum VacationStatus
    {
        Approved,
        Closed
    }

    public static class VacationStatusExtension
    {
        public static string ToFriendlyString(this VacationStatus type)
        {
            switch (type)
            {
                case VacationStatus.Approved:
                    return "Approved";
                case VacationStatus.Closed:
                    return "Closed";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
using System;

namespace VacationsTracker.Core.Domain
{
    public enum VacationType
    {
        Regular,
        SickDays,
        ExceptionalLeave,
        Overtime
    }

    public static class VacationTypeExtension
    {
        public static string ToFriendlyString(this VacationType type)
        {
            switch (type)
            {
                case VacationType.Regular:
                    return "Regular";
                case VacationType.SickDays:
                    return "Sick days";
                case VacationType.ExceptionalLeave:
                    return "Exceptional leave";
                case VacationType.Overtime:
                    return "Overtime";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace VacationsTracker.Core.DTO
{
    public enum BaseClassCode
    {
        [EnumMember(Value = "OK")]
        OK,

        [EnumMember(Value = "ValidationFailed")]
        ValidationFailed,

        [EnumMember(Value = "NotFound")]
        NotFound
    }
}

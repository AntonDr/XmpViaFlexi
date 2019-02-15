using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace VacationsTracker.Core.DTO
{
    public class BaseResult
    {
        [JsonProperty("code")]
        public BaseClassCode Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}

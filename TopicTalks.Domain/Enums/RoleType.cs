using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TopicTalks.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RoleType
    {

        Student = 1,
        Teacher = 2,
        Moderator = 3
    }
}

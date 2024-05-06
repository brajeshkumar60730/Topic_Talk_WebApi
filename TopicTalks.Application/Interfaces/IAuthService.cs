using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicTalks.Domain.Entities;

namespace TopicTalks.Application.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(User user);
    }
}

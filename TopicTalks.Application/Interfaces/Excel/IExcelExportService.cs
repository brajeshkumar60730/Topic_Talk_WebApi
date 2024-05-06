using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicTalks.Application.Dtos;

namespace TopicTalks.Application.Interfaces.Excel
{
    internal  interface IExcelExportService
    {
        ExcelFile UserListExcel(IEnumerable<UserDto> users);
    }
}

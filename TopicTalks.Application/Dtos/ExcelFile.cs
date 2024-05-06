﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopicTalks.Application.Dtos
{
    public record ExcelFile(byte[] Bytes, string ContentType, string Name)
    {
        public ExcelFile(byte[] bytes) : this(
        bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        $"UsersExport-{DateTime.Now:yyyyMMddHHmmss}.xlsx"
    )
        { }
    }
}

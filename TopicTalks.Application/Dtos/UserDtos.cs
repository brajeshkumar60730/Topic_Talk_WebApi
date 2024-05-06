﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicTalks.Domain.Enums;

namespace TopicTalks.Application.Dtos
{
    public record UserBasicInfoDto(
    long UserId,
    string Email
);

    public record UserDto(
        long UserId,
        string Email,
        DateTime CreatedAt,
        UserDetailDto? UserDetails,
        List<RoleType> Roles
    );

    public record UserDetailDto(
        string Name,
        string InstituteName,
        string IdCardNumber
    );

    public record UserRoleDto(
        long UserRoleId,
        long RoleId
    );
}

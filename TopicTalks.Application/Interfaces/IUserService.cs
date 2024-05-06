﻿using ErrorOr;
using TopicTalks.Application.Dtos;

namespace TopicTalks.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> IsEmailExists(string email);
        Task<bool> IsUserExists(long userId);
        Task<ErrorOr<RegistrationResponse>> Register(RegistrationRequest request);
        Task<ErrorOr<LoginResponse>> Login(LoginRequest request);
        Task<ErrorOr<UserDto>> GetWithDetailsAsync(long userId);
        Task<ExcelFile> UserListExcelFile();
        Task<ErrorOr<Success>> ChangePassword(long userId, PasswordChangeRequest request);
        Task Login(Microsoft.AspNetCore.Identity.Data.LoginRequest request);
    }
}

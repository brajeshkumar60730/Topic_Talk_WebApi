﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicTalks.Application.Dtos;
using TopicTalks.Domain.Entities;

namespace TopicTalks.Application.Extensions
{
    public static class EntityExtensions
    {
        public static QuestionResponseDto ToDto(this Question question)
        {
            return new QuestionResponseDto(
                QuestionId: question.QuestionId,
                Topic: question.Topic,
                Explanation: question.Explanation,
                UserInfo: question.User is null ? null : new UserBasicInfoDto(
                    UserId: question.User.UserId,
                    Email: question.User.Email
                ),
                CreatedAt: question.CreatedAt,
                UpdatedAt: question.UpdatedAt
            );
        }

        public static UserDetailDto? ToDto(this UserDetail? userDetail)
        {
            return userDetail == null
                ? null
                : new UserDetailDto(
                    Name: userDetail.Name,
                    InstituteName: userDetail.InstituteName,
                    IdCardNumber: userDetail.IdCardNumber
                );
        }

        public static AnswerResponseDto ToDto(this Answer answer)
        {
            return new AnswerResponseDto(
                AnswerId: answer.AnswerId,
                ParentAnswerId: answer.ParentAnswerId,
                QuestionId: answer.QuestionId,
                Explanation: answer.Explanation,
                CreatedAt: answer.CreatedAt,
                UserInfo: answer.User == null ? null
                    : new UserBasicInfoDto(
                        UserId: answer.User.UserId,
                        Email: answer.User.Email
                    )
                );
        }
    }
}

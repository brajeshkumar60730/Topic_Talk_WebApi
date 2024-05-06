﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicTalks.Application.Interfaces.Pdf;
using TopicTalks.Application.Interfaces;
using ErrorOr;
using TopicTalks.Application.Dtos;
using TopicTalks.Domain;
using TopicTalks.Domain.Entities;
using TopicTalks.Application.Extensions;
using TopicTalks.Domain.Enums;

namespace TopicTalks.Application.Services
{
    internal class QuestionService(IUnitOfWork unitOfWork, IAnswerService answerService, IPdfService pdfService) : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IAnswerService _answerService = answerService;
        private readonly IPdfService _pdfService = pdfService;

        public async Task<QuestionResponseDto> CreateAsync(QuestionCreateDto dto, long userId)
        {
            var question = new Question
            {
                Topic = dto.Topic,
                Explanation = dto.Explanation,
                UserId = userId
            };

            await _unitOfWork.Question.AddAsync(question);
            await _unitOfWork.CommitAsync();

            var response = await GetWithUserAsync(question.QuestionId);

            return response.Value;
        }

        public async Task<List<QuestionResponseDto>> GetAsync()
        {
            var questions = await _unitOfWork.Question.GetWithUser();

            return questions.Select(q => q.ToDto()).ToList();
        }

        public async Task<ErrorOr<QuestionResponseDto>> GetAsync(long questionId)
        {
            var question = await _unitOfWork.Question.GetAsync(questionId);
            return question is null
                ? Error.NotFound()
                : question.ToDto();
        }

        public async Task<ErrorOr<QuestionResponseDto>> GetWithUserAsync(long questionId)
        {
            var question = await _unitOfWork.Question.GetWithUser(questionId);

            return question is null ? Error.NotFound()
                : new QuestionResponseDto(
                    QuestionId: question.QuestionId,
                    Topic: question.Topic,
                    Explanation: question.Explanation,
                    UserInfo: question.User is null
                        ? null
                        : new UserBasicInfoDto(question.User.UserId, question.User.Email),
                    CreatedAt: question.CreatedAt,
                    UpdatedAt: question.UpdatedAt
                );
        }

        public async Task<List<QuestionResponseDto>> SearchAsync(string? searchText)
        {
            var questions = await _unitOfWork.Question.SearchAsync(searchText?.Trim());

            var responseDtos = questions.Select(q => q.ToDto()).ToList();

            return responseDtos;
        }

        public async Task<List<QuestionResponseDto>> GetByUserIdAsync(long userId)
        {
            var questions = await _unitOfWork.Question.GetByUserId(userId);

            return questions.Select(q => q.ToDto()).ToList();
        }

        public async Task<List<QuestionResponseDto>> GetByUserResponsesAsync(long userId)
        {
            var questions = await _unitOfWork.Question.GetByUserResponses(userId);

            return questions.Select(q => q.ToDto()).ToList();
        }

        public async Task<ErrorOr<QuestionWithAnswersDto>> GetWithAnswersAsync(long questionId)
        {
            var question = await _unitOfWork.Question.GetWithAnswers(questionId);
            var answers = await _answerService.GetAnswersWithRepliesAsync(questionId);

            return question is null
                ? Error.NotFound()
                : new QuestionWithAnswersDto(
                    QuestionId: question.QuestionId,
                    Topic: question.Topic,
                    Explanation: question.Explanation,
                    HasTeachersResponse: question.Answers
                        .Any(answer => answer.User is not null && answer.User.UserRoles
                            .Any(ur => ur.Role.RoleName == nameof(RoleType.Teacher))),
                    UserInfo: question.User is null
                        ? null
                        : new UserBasicInfoDto(question.User.UserId, question.User.Email),
                    Answers: answers,
                    CreatedAt: question.CreatedAt,
                    UpdatedAt: question.UpdatedAt
                );
        }

        public async Task<ErrorOr<QuestionResponseDto>> UpdateAsync(QuestionUpdateDto dto, long userId, string role)
        {
            var question = await _unitOfWork.Question.GetWithUser(dto.QuestionId);

            if (question is null)
            {
                return Error.NotFound();
            }

            if (question.UserId != userId && role is not nameof(RoleType.Moderator))
            {
                return Error.Unauthorized();
            }

            question.Topic = dto.Topic;
            question.Explanation = dto.Explanation;
            question.UpdatedAt = DateTime.Now;

            await _unitOfWork.CommitAsync();

            return question.ToDto();
        }

        public async Task<ErrorOr<Success>> DeleteAsync(long questionId, string role, long userId)
        {
            var question = await _unitOfWork.Question.GetAsync(questionId);

            if (question is null)
            {
                return Error.NotFound();
            }

            if (question.UserId != userId && role is not nameof(RoleType.Moderator))
            {
                return Error.Unauthorized();
            }

            _unitOfWork.Question.Remove(question);

            var deletes = await _unitOfWork.CommitAsync();

            return deletes == 0
                ? Error.Unexpected()
                : Result.Success;
        }

        public async Task<ErrorOr<byte[]>> GeneratePdfAsync(long questionId)
        {
            var question = await GetWithAnswersAsync(questionId);

            return question.IsError
                ? question.Errors
                : _pdfService.GenerateQuestionPdf(question.Value);
        }
    }
}

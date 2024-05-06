﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicTalks.Domain.Entities;

namespace TopicTalks.Domain.Interfaces
{
    public interface  IAnswerRepository : IRepository<Answer>
    {
        Task<Answer?> GetWithUserAsync(long answerId);
        Task<List<Answer>> GetParentAnswersAsync(long questionId, long parentAnswerId);
        Task<Answer?> GetRepliesAsync(long questionId, long answerId, long parentAnswerId);
        Task<bool> HasTeachersAnswerAsync(int questionId);
        Task<bool> IsQuestionOrParentExists(long questionId, long? parentAnswerId);
    }
}

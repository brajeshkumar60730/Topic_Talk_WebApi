using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicTalks.Domain.Entities;

namespace TopicTalks.Domain.Interfaces
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Task<List<Question>> SearchAsync(string? searchText);
        Task<List<Question>> GetWithUser();
        Task<Question?> GetWithUser(long questionId);
        Task<List<Question>> GetByUserId(long userId);
        Task<List<Question>> GetByUserResponses(long userId);
        Task<Question?> GetWithAnswers(long questionId);
    }
}

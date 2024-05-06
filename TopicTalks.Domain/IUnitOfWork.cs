using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicTalks.Domain.Interfaces;

namespace TopicTalks.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        IAnswerRepository Answer { get; }
        IQuestionRepository Question { get; }

        Task<int> CommitAsync();
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicTalks.Domain.Entities;

namespace TopicTalks.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> IsEmailExists(string email);
        Task<bool> IsUserExists(long? userId);
        Task<List<User>> GetWithDetailsAsync();
        Task<User?> GetWithDetailsAsync(string email, long roleId);
        Task<User?> GetWithDetailsAsync(long userId);
    }
}

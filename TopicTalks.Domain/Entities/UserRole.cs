using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopicTalks.Domain.Entities
{
    public class UserRole
    {
        public long UserId { get; set; }

        public long RoleId { get; set; }

        public User User { get; set; } = null!;

        public Role Role { get; set; } = null!;
    }
}

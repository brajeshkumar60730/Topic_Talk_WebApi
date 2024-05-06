using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopicTalks.Application.Interfaces
{
    internal interface IPasswordService
    {
        (string hashedPassword, string salt) HashPasswordWithSalt(string password);
        bool VerifyPassword(string hashedPasswordFromDatabase, string saltFromDatabase, string rawPassword);
    }
}

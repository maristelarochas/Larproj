using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Larproj.Domain.Entities;

public class User
{
    public int UserId { get; private set; }
    public string UserName { get; private set; }
    public string UserEmail { get; private set; }
    public string UserHashPassword { get; private set; }

    public User(int userId, string userName, string userEmail, string userHashPassword)
    {
        UserId = userId;
        UserName = userName;
        UserEmail = userEmail;
        UserHashPassword = userHashPassword;
    }
}
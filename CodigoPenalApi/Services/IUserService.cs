using CodigoPenalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodigoPenalApi.Services
{
    public interface IUserService
    { // Users
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsersByName(string name);
        Task CreateUser(User user);
    }
}

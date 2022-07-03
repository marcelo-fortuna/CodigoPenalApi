using CodigoPenalApi.Context;
using CodigoPenalApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodigoPenalApi.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        // Users //

        public async Task<IEnumerable<User>> GetUsers()
        {
            try
            {
                return await _context.User.AsNoTracking()
                                          .ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsersByName(string name)
        {
            IEnumerable<User> users;
            if (string.IsNullOrWhiteSpace(name))
            {
                users = await _context.User.Where(n => n.UserName.Contains(name)).ToListAsync();
            } else {
                users = await GetUsers();
            }
            return users;
        }

        public async Task CreateUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }

    }
}

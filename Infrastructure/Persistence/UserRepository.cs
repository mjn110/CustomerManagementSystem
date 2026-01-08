using Application.Common.Interface.Persistence;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly CustomerOrderManagementContext _context;
    public UserRepository(CustomerOrderManagementContext context)
    {
        _context = context;
    }
    //private static readonly List<User> _users = new();
    public void Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public User GetUserByEmail(string email)
    {
        return _context.Users.SingleOrDefault(u => u.Email == email);
    }
}

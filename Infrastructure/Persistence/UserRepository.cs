using Application.Common.Interface.Persistence;
using Application.DTO;
using Application.DTO.Authentication;
using Azure.Core;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    public UserRepository(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    //private static readonly List<User> _users = new();
    public async Task<IdentityResult> Add(string firstName, string lastName, string Email, string Password)
    {
        var newUser = new User
        {
            UserName = Email,
            Email = Email,
            FirstName = firstName,
            LastName = lastName
        };
        return await _userManager.CreateAsync(newUser, Password);
    }

    public async Task<IdentityResult> AssignUserRole(User user)
    {
        return await _userManager.AddToRoleAsync(user, Roles.User);
    }

    public async Task<IdentityResult> AssignAdminRole(User user)
    {
        return await _userManager.AddToRoleAsync(user, Roles.Admin);
    }

    public User GetUserByEmail(string email)
    {
        return _userManager.Users.SingleOrDefault(u => u.Email == email);
    }

    public async Task<SignInResult> LoginAsync(string email, string password)
    {
        return await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);
    }
}

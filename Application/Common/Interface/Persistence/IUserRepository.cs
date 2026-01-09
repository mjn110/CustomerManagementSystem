using Application.DTO.Authentication;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Common.Interface.Persistence;

public interface IUserRepository
{
    Task<IdentityResult> Add(string firstName, string lastName, string Email, string Password);
    Task<IdentityResult> AssignUserRole(User user);
    Task<IdentityResult> AssignAdminRole(User user);
    User GetUserByEmail(string email);
    Task<SignInResult> LoginAsync(string email, string password);
}
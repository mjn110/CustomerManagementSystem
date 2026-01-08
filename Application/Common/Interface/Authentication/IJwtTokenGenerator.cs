using Domain.Entities;

namespace Application.Common.Interface.Authentication;
public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
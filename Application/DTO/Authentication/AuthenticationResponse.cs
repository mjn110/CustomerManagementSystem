using Domain.Entities;

namespace Application.DTO.Authentication;

public record AuthenticationResponse(
    User User,
    string Token);


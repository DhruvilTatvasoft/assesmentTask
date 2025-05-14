using System.Security.Claims;

public interface IJwtTokenGenService{
            string GenerateJwtToken(LoginDetailsModel model);
             ClaimsPrincipal? ValidateToken(string token);
}
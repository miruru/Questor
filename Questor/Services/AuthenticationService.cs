using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NetDevPack.Security.JwtSigningCredentials.Interfaces;
using Questor.Extensions;
using QuestorApi.Dto;
using QuestorApi.Extensions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuestorApi.Services
{
    public class AuthenticationService
    {
        private readonly IConfiguration _config;

        public AuthenticationService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<LoginDto> GerarJwt(string email)
        {
            var encodedToken = CodificarToken();

            var refreshToken = await GerarRefreshToken(email);

            return ObterRespostaToken(encodedToken, email, refreshToken);
        }

        private string CodificarToken()
        {
            var _secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Jwt:Key"]));
            var _issuer = _config["Jwt:Issuer"];
            var _audience = _config["Jwt:Audience"];

            var signinCredentials = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: signinCredentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return tokenString;
        }
        private async Task<RefreshToken> GerarRefreshToken(string email)
        {
            var refreshToken = new RefreshToken
            {
                Username = email,
                ExpirationDate = DateTime.UtcNow.AddHours(Convert.ToDouble(_config["AppTokenSettings:RefreshTokenExpiration"]))
            };

            return refreshToken;
        }


        private LoginDto ObterRespostaToken(string encodedToken, String email, RefreshToken refreshToken)
        {
            return new LoginDto
            {
                AccessToken = encodedToken,
                RefreshToken = refreshToken.Token,
                ExpiresIn = TimeSpan.FromMinutes(2).TotalSeconds,
                UserToken = new UserTokenDto { Email = email }
            };
        }

        public async Task<RefreshToken> ObterRefreshToken(Guid refreshToken)
        {
            return null;
        }
    }
}

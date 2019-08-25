using Konfio.API.DTO_s;
using Konfio.API.Models;
using Konfio.API.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Konfio.API.Services.Imp
{
    public class AuthenticateService : IAuthenticateService
    {
        protected IRepository<User> _userRepository;

        public AuthenticateService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public bool IsAuthenticated(AuthenticateRequestDTO request, out AuthenticateResponseDTO response)
        {
            response = new AuthenticateResponseDTO();
            var user = _userRepository.FindBy(u => u.Rfc == request.Rfc).SingleOrDefault();

            if (user == null)
            {
                throw new Exception("invalid credentials");
            }

            if (user.Password != request.Password)
            {
                throw new Exception("invalid credentials");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Rfc),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };


            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("YiQeYPB9qH5Yxb65AkfhS5w9YzJOCnZb"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var now = DateTime.Now;
            var expires = DateTime.Now.AddSeconds(Convert.ToDouble(864000));

            var jwtToken = new JwtSecurityToken(
                issuer: "/konfio",
                audience: "konfio",
                claims: claims,
                expires: expires,
                signingCredentials: credentials
            );

            response.AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            response.TokenType = JwtBearerDefaults.AuthenticationScheme;
            response.ExpiresIn = Convert.ToInt32(jwtToken.Claims.ToList()[2].Value);
            response.UserId = user.Id;

            return true;
        }
    }
}

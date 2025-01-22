using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services
{
    public class AuthService
    {
        private readonly JwtService _jwtService;
        private readonly IConfiguration _configuration;

        public AuthService(JwtService jwtService, IConfiguration configuration)
        {
            _jwtService = jwtService;
            _configuration = configuration;
        }

        public async Task<string> AuthenticateAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            if (username == _configuration["Auth:Username"] && password == _configuration["Auth:Password"])
            {
                return _jwtService.GenerateToken(username, password);
            }

            return null;
        }
    }
}

using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using life_manager_backend.Entities;
using life_manager_backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace life_manager_backend.Controllers
{
    [Route("api/authenticate")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IFoodRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public class AuthenticationRequestBody
        {
            public string? Username { get; set; }
            public string? Password { get; set; }
        }

        public AuthenticationController(IFoodRepository _repository, IConfiguration _configuration, IWebHostEnvironment _env)
        {
            this._repository = _repository ?? throw new ArgumentNullException(nameof(_repository));
            this._configuration = _configuration ?? throw new ArgumentNullException(nameof(_configuration));
            this._env = _env ?? throw new ArgumentNullException(nameof(_env));
        }

        [HttpPost]
        public async Task<ActionResult<string>> Authenticate(
            AuthenticationRequestBody authenticationRequestBody)
        {
            string secretForKey;
            string issuer;
            string audience;

            if (_env.IsDevelopment())
            {
                secretForKey = _configuration["Authentication:SecretForKey"];
                issuer = _configuration["Authentication:Issuer"];
                audience = _configuration["Authentication:Audience"];
            }
            else
            {
                secretForKey = GetSecretForKey();
                issuer = _configuration["WEBSITE_HOSTNAME"];
                audience = _configuration["WEBSITE_SITE_NAME"];
            }
            var user = await ValidateUserCredentials(
                authenticationRequestBody.Username,
                authenticationRequestBody.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(secretForKey));

            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.Id.ToString()));
            claimsForToken.Add(new Claim("email", user.Email.ToString()));
            
            var jwtSecurityToken = new JwtSecurityToken(
                 issuer,
                 audience,
                 claimsForToken,
                 DateTime.UtcNow,
                 DateTime.UtcNow.AddHours(24),
                 signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);

        }

        private async Task<ApiUser?> ValidateUserCredentials(
            string? username, string? password)
        {
            if (username == null || password == null)
            {
                return null;
            }
            return await _repository.GetApiUserAsync(username, password);            
        }

        private string GetSecretForKey()
        {
            SecretClientOptions options = new SecretClientOptions()
            {
                Retry =
                    {
                        Delay= TimeSpan.FromSeconds(2),
                        MaxDelay = TimeSpan.FromSeconds(16),
                        MaxRetries = 5,
                        Mode = RetryMode.Exponential
                     }
            };
            var client = new SecretClient(new Uri("https://guitar-app-kv.vault.azure.net/"), new DefaultAzureCredential(), options);

            KeyVaultSecret secretForKey = client.GetSecret("lifemgr-secret-for-key");
            return secretForKey.Value;
        }
    }
}
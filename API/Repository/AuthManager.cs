using AutoMapper;
using Hunter.API.Contracts;
using Hunter.API.Data;
using Hunter.API.DTOs.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hunter.API.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;
        private ApiUser _user;

        public AuthManager(IMapper mapper, UserManager<ApiUser> userManager, IConfiguration configuration)
        {
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<AuthResponseDto> Login(LoginDto loginDto)
        {
            var _user = await _userManager.FindByNameAsync(loginDto.UserName);
            bool isValidUser = await _userManager.CheckPasswordAsync(_user, loginDto.Password);

            if (_user is null || isValidUser is false) return null;

            var token = GenerateToken();

            return new AuthResponseDto
            {
                Token = token.Result,
                UserId = _user.Id
            };
        }

        public async Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto)
        {
            var user = _mapper.Map<ApiUser>(userDto);
            user.UserName = userDto.UserName;

            var result = await _userManager.CreateAsync(_user, userDto.Password);

            if (result.Succeeded)
            {
                IEnumerable<string> selectedRoles = new[] { "USER", "VISITOR" };
                await _userManager.AddToRolesAsync(_user, selectedRoles);
            }
            
            return result.Errors;
        }

        public Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request)
        {
            throw new NotImplementedException();
        }

        private async Task<string> GenerateToken()
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));

            var credentials = new SigningCredentials(securitykey,SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(_user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims = await _userManager.GetClaimsAsync(_user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, _user.Email),
            //  new Claim("LicenseType", "valuegoeshere")
            }
            .Union(userClaims).Union(roleClaims);

            double hours = Convert.ToDouble(_configuration["JwtSettings:DurationInHours"]);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Key"],
                audience: _configuration["JwtSettings:Key"],
                claims: claims,
                expires: DateTime.Now.AddHours(hours),
                signingCredentials: credentials
                ); ;

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

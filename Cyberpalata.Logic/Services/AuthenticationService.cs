using AutoMapper;
using Azure.Core;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Configuration;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IApiUserRepository _userRepository;
        private readonly IUserRefreshTokenRepository _refreshTokenRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthenticationService(IApiUserRepository userRepository, IUserRefreshTokenRepository refreshTokenRepository, IConfiguration configuration, IMapper mapper)
        {
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<Result<ApiUserDto>> ValidateUserAsync(AuthenticateRequest request)
        {
            var user = await _userRepository.ReadAsync(request.Email);
            if (user.Password == request.Password)
                return Result.Ok(_mapper.Map<ApiUserDto>(user));
            return (Result<ApiUserDto>)Result.Fail("Email or password is incorrect!!!");
        }

        public async Task<TokenDto> GenerateTokenAsync(ApiUserDto user)
        {
            var accessToken = GenerateAccessToken(user);
            var refreshToken = GenerateRefreshToken();

            // to get by email / automapper doesn't work
            var apiUser = await _userRepository.ReadAsync(user.Email);

            await _refreshTokenRepository.CreateAsync(new UserRefreshToken { User = apiUser,Expiration = DateTime.Now.AddDays(2), RefreshToken = refreshToken });

            return new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        //Maybe
        //add read by refreshToken 
        //

        public async Task<Result<TokenDto>> RefreshTokenAsync(TokenDto tokenDto)
        {
            try
            {

                //????????????
                var handler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = handler.ReadJwtToken(tokenDto.AccessToken);
                var userId = new Guid(jwtSecurityToken.Claims.First(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
                //????????????

                //Maybe
                UserRefreshToken refreshTokenOrNothing = await _refreshTokenRepository.ReadAsync(tokenDto.RefreshToken);

                if(refreshTokenOrNothing.User.Id != userId)
                    throw new ArgumentException("Invalid user's id!", nameof(userId));

                var isExpired = DateTime.Now.AddMinutes(5) >= refreshTokenOrNothing.Expiration;
                if (isExpired)
                    return Result.Ok(await GenerateTokenAsync(_mapper.Map<ApiUserDto>(refreshTokenOrNothing.User)));
                else
                {
                    return Result.Ok(new TokenDto
                    {
                        AccessToken = GenerateAccessToken(_mapper.Map<ApiUserDto>(refreshTokenOrNothing.User)),
                        RefreshToken = tokenDto.RefreshToken
                    });
                }

            }
            catch(Exception ex)
            {
                return (Result<TokenDto>)Result.Fail(ex.Message);
            }
        }


        private string GenerateAccessToken(ApiUserDto user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                //???? 
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.Email, user.Email),
            };
            var accessToken = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials);
           
            return new JwtSecurityTokenHandler().WriteToken(accessToken);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}

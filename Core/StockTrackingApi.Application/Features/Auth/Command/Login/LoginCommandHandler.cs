﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.Tokens;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.Auth.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly ITokenService tokenService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;

        public LoginCommandHandler(UserManager<User> userManager, IMapper mapper, IConfiguration configuration, ITokenService tokenService, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.configuration = configuration;
            this.tokenService = tokenService;
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                
                bool isPasswordCorrect = await userManager.CheckPasswordAsync(user, request.Password);
                if (isPasswordCorrect)
                {
            
                    IList<string> roles = await userManager.GetRolesAsync(user);
                    JwtSecurityToken token = await tokenService.CreateToken(user, roles);
                    string refreshToken = tokenService.GenerateRefreshToken();

                    
                    _ = int.TryParse(configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);
                    user.RefreshToken = refreshToken;
                    user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

                    
                    await userManager.UpdateAsync(user);
                    await userManager.UpdateSecurityStampAsync(user);

                    
                    string _token = new JwtSecurityTokenHandler().WriteToken(token);
                    await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);

                
                    return new LoginCommandResponse
                    {
                        Token = _token,
                        RefreshToken = refreshToken,
                        Expiration = token.ValidTo
                    };
                }
            }

            
            throw new UnauthorizedAccessException("Kullanıcı adı veya şifre yanlış.");
        }
    }
}

using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using KodlamaIoDevs.Application.Features.Languages.Rules;
using KodlamaIoDevs.Application.Features.OperationClaims.Rules;
using KodlamaIoDevs.Application.Features.Socials.Rules;
using KodlamaIoDevs.Application.Features.Technologies.Rules;
using KodlamaIoDevs.Application.Features.UserOperationClaims.Rules;
using KodlamaIoDevs.Application.Features.Users.Rules;
using KodlamaIoDevs.Application.Services.AuthService;
using KodlamaIoDevs.Application.Services.OperationClaimService;
using KodlamaIoDevs.Application.Services.UserService;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application
{
   

    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient<LanguageBusinessRules>();
            services.AddTransient<TechnologyBusinessRules>();
            services.AddTransient<UserBusinessRules>();
            services.AddTransient<SocialAccountBusinessRules>();
            services.AddTransient<OperationClaimBusinessRules>();
            services.AddTransient<UserOperationClaimBusinessRules>();



            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IOperationClaimService, OperationClaimManager>();



            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            return services;

        }
    }
}

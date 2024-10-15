//using Microsoft.Azure.Functions.Extensions.DependencyInjection;
//using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
//using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.OpenApi.Models;
//using System.Collections.Generic;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.Extensions.Configuration;
//using System;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc.Authorization;
//using Microsoft.AspNetCore.Http;
//using System.Threading.Tasks;

////[assembly: FunctionsStartup(typeof(FuncAppApim.Startup))]

//namespace FuncAppApim
//{
//    public class Startup : FunctionsStartup
//    {
//        public override void Configure(IFunctionsHostBuilder builder)
//        {
//            var configuration = new ConfigurationBuilder()
//                .SetBasePath(Environment.CurrentDirectory)
//                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
//                .AddEnvironmentVariables()
//                .Build();

//            builder.Services.AddSingleton<IOpenApiConfigurationOptions>(_ =>
//            {
//                var options = new DefaultOpenApiConfigurationOptions()
//                {
//                    Info = new OpenApiInfo()
//                    {
//                        Version = "1.0.0",
//                        Title = "My Function App API",
//                        Description = "API documentation for my Azure Function App"
//                    },
//                    Servers = new List<OpenApiServer>()
//            {
//                new OpenApiServer() { Url = "http://localhost:7071" },
//                new OpenApiServer() { Url = "https://webapidbconnect20240729184116.azurewebsites.net" }
//            }
//                };

//                return options;
//            });

//            // Configure JWT authentication
//            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//                .AddJwtBearer(options =>
//                {
//                    var tenantId = configuration["AzureAd:TenantId"];
//                    options.Authority = $"https://login.microsoftonline.com/{tenantId}/v2.0";
//                    options.TokenValidationParameters = new TokenValidationParameters
//                    {
//                        ValidateIssuer = true,
//                        ValidIssuer = $"https://sts.windows.net/{tenantId}/",
//                        ValidateAudience = true,
//                        ValidAudience = $"api://{configuration["AzureAd:Audience"]}",
//                        ValidateLifetime = true,
//                        ValidateIssuerSigningKey = true
//                    };
//                });

//            // Add authorization policy
//            builder.Services.AddAuthorization(options =>
//            {
//                options.AddPolicy("Swagger", policy =>
//                {
//                    policy.RequireAuthenticatedUser();
//                });
//            });

//            // Apply authorization policy to Swagger UI
//            builder.Services.AddMvc(options =>
//            {
//                var policy = new AuthorizationPolicyBuilder()
//                    .RequireAuthenticatedUser()
//                    .Build();
//                options.Filters.Add(new AuthorizeFilter(policy));
//            });

//            // Apply middleware
//            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//            builder.Services.AddTransient<SwaggerAuthMiddleware>();
//        }
//    }

 

//}

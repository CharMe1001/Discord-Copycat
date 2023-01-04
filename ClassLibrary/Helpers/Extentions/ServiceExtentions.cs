﻿using ClassLibrary.Helpers.UOW;
using ClassLibrary.Repositories.ChatRep;
using ClassLibrary.Repositories.ServerRep;
using ClassLibrary.Repositories.UserRep;
using ClassLibrary.Services.ChatService;
using ClassLibrary.Services.ServerService;
using ClassLibrary.Services.UserService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Helpers.Extentions
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IServerRepository, ServerRepository>();
            services.AddTransient<IChatRepository, ChatRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IServerService, ServerService>();
            services.AddTransient<IChatService, ChatService>();

            return services;
        }
    }
}

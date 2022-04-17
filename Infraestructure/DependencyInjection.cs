using Application.Common.Behaviours;
using Application.Common.Interfaces;
using FluentValidation;
using Infraestructure.Repository;
using Infraestructure.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    /// <summary>
    /// Injected dependencies for this layer
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, MemoryUnitOfWork>();
            services.AddScoped<ICommandRepository<Domain.Entities.Item>, CommandMemoryRepositoryItem>();
            services.AddScoped<IQueryRepository<Domain.Entities.Item>, QueryMemoryRepositoryItem>();
            services.AddScoped<ICommandRepository<Domain.Aggregate.Inventory>, CommandMemoryRepositoryInventory>();
            services.AddScoped<IQueryRepository<Domain.Aggregate.Inventory>, QueryMemoryRepositoryInventory>();
            services.AddScoped<IContext, Context>();
            services.AddSingleton<IEventNotificationService, NotificationService>();
            return services;
        }

    }
}

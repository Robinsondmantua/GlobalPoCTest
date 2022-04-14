using Application.Common.Behaviours;
using Application.Common.Interfaces;
using FluentValidation;
using Infraestructure.Repository;
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
            services.AddTransient<IUnitOfWork, MemoryUnitOfWork>();
            services.AddSingleton<ICommandRepository<Domain.Entities.Item>, CommandMemoryRepositoryItem>();
            services.AddSingleton<IQueryRepository<Domain.Entities.Item>, QueryMemoryRepositoryItem>();
            services.AddSingleton<ICommandRepository<Domain.Aggregate.Inventory>, CommandMemoryRepositoryInventory>();
            services.AddSingleton<IQueryRepository<Domain.Aggregate.Inventory>, QueryMemoryRepositoryInventory>();
            services.AddSingleton<IContext, Context>();
            return services;
        }

    }
}

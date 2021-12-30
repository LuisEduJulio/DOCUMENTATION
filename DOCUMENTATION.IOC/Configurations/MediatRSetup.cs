using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DOCUMENTATION.IOC.Configurations
{
    public static class MediatRSetup
    {
        public static void AddMediatRSetup(this IServiceCollection services)
        {
            var assemblies = new System.Reflection.Assembly[]
            {
                AppDomain.CurrentDomain.Load("DOCUMENTATION.APPLICATION")
            };

            services.AddMediatR(assemblies);
        }
    }
}
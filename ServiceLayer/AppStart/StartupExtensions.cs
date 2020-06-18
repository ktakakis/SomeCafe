// Copyright (c) 2019 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT license. See License.txt in the project root for license information.

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;

namespace ServiceLayer.AppStart
{
    public static class StartupExtensions
    {
        public static void ServiceLayerRegister(this IServiceCollection services)
        {
            //This registers the classes in the current assembly that end in "Service" and have a public interface
            services.RegisterAssemblyPublicNonGenericClasses(Assembly.GetExecutingAssembly())
                .Where(c => c.Name.EndsWith("Service"))
                .AsPublicImplementedInterfaces();
        }
    }
}
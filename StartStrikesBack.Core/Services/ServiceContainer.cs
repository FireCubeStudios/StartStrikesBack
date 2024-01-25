using Microsoft.Extensions.DependencyInjection;
using StartStrikesBack.Core.Interfaces.Services;
using StartStrikesBack.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartStrikesBack.Core.Services
{
    public static class ServiceContainer
    {
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        public static IServiceProvider? Services { get; internal set; }

        public static IServiceProvider ConfigureServices(ServiceCollection container) => Services = container.BuildServiceProvider();
    }
}

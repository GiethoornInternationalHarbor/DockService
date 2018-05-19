using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DockService.Core;
using DockService.Core.Messaging;
using DockService.Core.Services;
using DockService.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DockService.Infrastructure.DI
{
	public static class DIHelper
    {   
        public static void Setup(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDockService, Services.DockService>();

            services.AddSingleton<IEventHandler, RMQMessageHandler>((provider) => new RMQMessageHandler(configuration.GetSection("AMQP").Value));
            services.AddTransient<IEventPublisher, RMQMessagePublisher>((provider) => new RMQMessagePublisher(configuration.GetSection("AMQP").Value));
        }

        public static void OnServicesSetup(IServiceProvider serviceProvider)
        {
            Console.WriteLine("Running..");
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DockService.Core;
using DockService.Core.Messaging;
using DockService.Core.Services;
using DockService.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using DockService.Core.Repositories;
using DockService.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using DockService.Infrastructure.Repositories;

namespace DockService.Infrastructure.DI
{
	public static class DIHelper
    {   
        public static void Setup(IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddDbContext<DockDbContext>(options => options.UseSqlServer(configuration.GetSection("DB_CONNECTION_STRING").Value));

            services.AddTransient<IShipRepository, ShipRepository>();
            services.AddTransient<IDockService, Services.DockService>();

            services.AddSingleton<IEventHandler, RMQMessageHandler>((provider) => new RMQMessageHandler(configuration.GetSection("AMQP_URL").Value));
            services.AddTransient<IEventPublisher, RMQMessagePublisher>((provider) => new RMQMessagePublisher(configuration.GetSection("AMQP_URL").Value));

        }

        public static void OnServicesSetup(IServiceProvider serviceProvider)
        {
            Console.WriteLine("Connecting to Db and checking for migrations");
            var dbContext = serviceProvider.GetService<DockDbContext>();
            dbContext.Database.Migrate();
            Console.WriteLine("Connecting succesful");
        }
    }
}

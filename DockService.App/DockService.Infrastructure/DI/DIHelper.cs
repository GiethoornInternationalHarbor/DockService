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
            #region ---optional. persistance---
            //services.AddDbContext<DockDbContext>(options => options.UseSqlServer(configuration.GetSection("DB_CONNECTION_STRING").Value));     
            // services.AddTransient<IShipRepository, ShipRepository>();
            #endregion
            services.AddTransient<IDockService, Services.DockService>();

            services.AddSingleton<IEventHandler, RMQMessageHandler>((provider) => new RMQMessageHandler(configuration.GetSection("AMQP").Value));
            services.AddTransient<IEventPublisher, RMQMessagePublisher>((provider) => new RMQMessagePublisher(configuration.GetSection("AMQP").Value));
        }

        public static void OnServicesSetup(IServiceProvider serviceProvider)
        {
            Console.WriteLine("Data persistance not enabled");//because I dont think i need to save ships since we do nothing with them..
            /*
            Console.WriteLine("Connecting to Database");
            var dbContext = serviceProvider.GetService<DockDbContext>();
            dbContext.Database.Migrate();
            Console.WriteLine("Database migration.. Done");
            */
        }
    }
}

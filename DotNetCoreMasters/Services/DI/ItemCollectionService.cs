using Microsoft.Extensions.DependencyInjection;
using Repositories.DataContext;
using Repositories.DataContext.Interface;
using Repositories.Implementation;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DI
{
    public static class ItemCollectionService
    {
        public static IServiceCollection AddItemService(this IServiceCollection services) //extend IServiceCollection 
        {
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IDataContext, DataContext>();

            return services; // By convention return IServiceCollection to allow method chaining
        }
    }
}

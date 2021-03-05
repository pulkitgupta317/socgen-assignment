using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManagement.DataLayer
{
    public static class ServiceExtension
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContactManagementContext>(opts => opts.UseSqlServer(configuration["ConnectionString:ContactManagementDb"]));
        } 
    }
}

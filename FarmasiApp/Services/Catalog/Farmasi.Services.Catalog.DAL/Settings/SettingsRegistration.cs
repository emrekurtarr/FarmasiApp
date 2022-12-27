using Farmasi.Services.Catalog.DAL.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Farmasi.Services.Catalog.DAL.Settings
{
    public static class SettingsRegistration { 
    //{
    //    public static IServiceCollection RegisterDbSettings(this IServiceCollection services, IConfiguration configure)
    //    {
    //        configure.GetRequiredSection(configure.GetSection("DatabaseSettings"));
    //        services.AddSingleton<IDatabaseSettings>(sp =>
    //        {
    //            return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
    //        });
    //    }

    }
}

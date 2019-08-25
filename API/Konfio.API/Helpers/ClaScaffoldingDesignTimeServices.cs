using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Konfio.API.Helpers
{
    public class ClaScaffoldingDesignTimeServices : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
        {
            var options = ReverseEngineerOptions.DbContextAndEntities;
            serviceCollection.AddHandlebarsScaffolding(options);
        }
    }
}

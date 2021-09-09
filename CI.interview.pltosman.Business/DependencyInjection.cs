using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CI.interview.pltosman.Business.Mappers;
using CI.interview.pltosman.Business.Abstract;
using CI.interview.pltosman.Business.Concrete;
using System.Reflection;

namespace CI.interview.pltosman.Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
          

            #region Configure Mapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<FixerServiceMappingProfile>();
            });
            var mapper = config.CreateMapper();
            #endregion



            services.AddSingleton<IExcelService, ExcelService>();

            return services;
        }
    }
}

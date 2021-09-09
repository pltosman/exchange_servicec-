using System;
using Autofac;
using CI.interview.pltosman.Business.Abstract;
using CI.interview.pltosman.Business.Concrete;
using CI.interview.pltosman.DataAccess.Abstract;
using CI.interview.pltosman.DataAccess.Concrete;

namespace CI.interview.pltosman.Business.DependecyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FixerRateManager>().As<IFixerRateService>();
            builder.RegisterType<EfFixerRateDal>().As<IFixerRateDal>();

            builder.RegisterType<ExcelDataManager>().As<IExcelDataService>();
            builder.RegisterType<EfExcelDataDal>().As<IExcelDataDal>();

            builder.RegisterType<FixerDetailService>().As<IFixerDetailService>();
       

        }
    }
}

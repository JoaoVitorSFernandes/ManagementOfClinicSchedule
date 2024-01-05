using Autofac;
using ManagementOfClinicSchedule.Application;
using ManagementOfClinicSchedule.Application.Interfaces;
using ManagementOfClinicSchedule.Application.Interfaces.Mapper;
using ManagementOfClinicSchedule.Application.Mapper;
using ManagementOfClinicSchedule.Domain.Core.Interfaces.Repositories;
using ManagementOfClinicSchedule.Domain.Core.Interfaces.Services;
using ManagementOfClinicSchedule.Domain.Services;
using ManagementOfClinicSchedule.Infrastructure.Data.Repositories;

namespace ManagementOfClinicSchedule.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IApplicationServiceRule>().As<ApplicationServiceRule>();

            builder.RegisterType<IServiceServiceRule>().As<ServiceServiceRule>();

            builder.RegisterType<IRepositoryServiceRule>().As<RepositoryServiceRule>();

            builder.RegisterType<IMapperServiceRule>().As<MapperServiceRule>();
        }
    }
}

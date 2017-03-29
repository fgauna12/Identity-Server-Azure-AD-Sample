using System;
using Autofac;
using Tourney.Application.Services.Company;
using Tourney.Application.Services.Facility;

namespace Tourney.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CompanyService>().As<ICompanyService>();
            builder.RegisterType<FacilityService>().As<IFacilityService>();
        }
    }
}
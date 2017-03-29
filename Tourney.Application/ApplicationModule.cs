using System;
using Autofac;
using Tourney.Application.Services.Company;

namespace Tourney.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CompanyService>().As<ICompanyService>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Quartz;
using Quartz.Impl;
using Finary.Jobs;

namespace Finary
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DomainInfo.init();


            IScheduler schedulerSetting = StdSchedulerFactory.GetDefaultScheduler();
            schedulerSetting.Start();

            IJobDetail jobSetting = JobBuilder.Create<AvailableCurrencies>().Build();

            ITrigger triggerSetting = TriggerBuilder.Create().WithSimpleSchedule(x => x.WithIntervalInMinutes(1).RepeatForever()).WithDescription("AvailableCurrenciesTask").Build();
            schedulerSetting.ScheduleJob(jobSetting, triggerSetting);
        }
    }
}

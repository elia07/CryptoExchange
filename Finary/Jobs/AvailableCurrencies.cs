using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using RestSharp.Authenticators;
using Finary.Models;
using System.Threading;
using Finary.DomainUtils;

namespace Finary.Jobs
{
    public class AvailableCurrencies : IJob
    {
        private static int Worker = 0;
        public async void Manage()
        {

            var availCurrencies = await new Changenow().GetAvailableCurrencies();
            if (availCurrencies.Count()!=0)
            {
                foreach(var item in availCurrencies.OrderBy(x=>x.name).Where(x => x.isFiat == false))
                {
                    //item.image = item.image.Replace("https://changenow.io/", DomainInfo.DomainAddress.AbsoluteUri);
                    item.image = "";
                    DomainInfo.AvailableCurrencies.AddOrUpdate(item.name, item, (key, oldValue) => item);
                }
                    
            }
        }
        void IJob.Execute(IJobExecutionContext context)
        {
            Worker++;
            if (Worker > 1)
            {
                Worker--;
                return;
            }
            try
            {
                Manage();
            }
            catch(Exception e) { }
            Worker--;
        }
    }
}
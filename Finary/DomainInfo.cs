using Finary.Core.Models;
using Finary.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Finary
{
    public static partial class DomainInfo
    {
        public static string LogAddress = AppDomain.CurrentDomain.BaseDirectory + "log.txt";
        public static string LogAdminName = "WebClient Log";
        public static Setting Setting = null;
        public static string UserSessionName = "User";
        public static ConcurrentDictionary<string,AvailableCurrencyModel> AvailableCurrencies = new ConcurrentDictionary<string,AvailableCurrencyModel>();
        public static Uri DomainAddress = new Uri("http://localhost:56203/");
        public static string ChangenowApiKey = "";

        static DomainInfo()
        {

        }

        public static void init()
        {
            ChangenowApiKey = ConfigurationManager.AppSettings.Get("ChangenowApiKey");
            Setting = new Setting();


            //DomainInfo.ControllerMentionFields = new Dictionary<string, List<MentionField>>();
            //List<MentionField> temp = new List<MentionField>();

            /*temp = new List<MentionField>();
            temp.Add(new MentionField("xType", "نوع", typeof(AdminType)));
            temp.Add(new MentionField("xEmail", "عنوان", typeof(string)));
            temp.Add(new MentionField("xName", "نام", typeof(string)));
            DomainInfo.ControllerMentionFields.Add("Admin", temp);

            temp = new List<MentionField>();
            DomainInfo.ControllerMentionFields.Add("User", temp);


            temp = new List<MentionField>();
            DomainInfo.ControllerMentionFields.Add("History", temp);


            temp = new List<MentionField>();
            temp.Add(new MentionField("xUserID", "", typeof(Int64), false));
            DomainInfo.ControllerMentionFields.Add("Ticket", temp);

            temp = new List<MentionField>();
            temp.Add(new MentionField("xUserID", "", typeof(Int64), false));
            DomainInfo.ControllerMentionFields.Add("Voucher", temp);

            temp = new List<MentionField>();
            //temp.Add(new MentionField("xUserID", "", typeof(Int64), false));
            temp.Add(new MentionField("xStartDate", "از تاریخ", typeof(DateTime), false));
            temp.Add(new MentionField("xEndDate", "تا تاریخ", typeof(DateTime), false));
            temp.Add(new MentionField("xCode", "کد", typeof(string), false));
            DomainInfo.ControllerMentionFields.Add("Income", temp);

            temp = new List<MentionField>();
            temp.Add(new MentionField("xUserID","",typeof(Int64),false));
            DomainInfo.ControllerMentionFields.Add("Withdrawal", temp);

            temp = new List<MentionField>();
            temp.Add(new MentionField("xUserID", "", typeof(Int64), false));
            DomainInfo.ControllerMentionFields.Add("BankAccount", temp);

            temp = new List<MentionField>();
            temp.Add(new MentionField("xUserID", "", typeof(Int64), false));
            DomainInfo.ControllerMentionFields.Add("ActivationHistory", temp);*/



        }

    }
}